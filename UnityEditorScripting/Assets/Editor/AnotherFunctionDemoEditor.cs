using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(AnotherFunctionDemo))]
public class AnotherFunctionDemoEditor : Editor
{
    private string[] ignoreMethods = new string[] { "Start", "Update" };
    private List<string> allMethods;

    private SerializedObject m_Object;
    private SerializedProperty m_gameobject;
    private SerializedProperty m_function;

    

    public void OnEnable()
    {
        allMethods = new List<string>();
        m_Object = new SerializedObject(target);
        m_gameobject = m_Object.FindProperty("selgameobject");
        m_function = m_Object.FindProperty("function");
    }

    public override void OnInspectorGUI()
    {
        m_Object.Update();

        EditorGUILayout.PropertyField(m_gameobject, new GUIContent("Game Object"));
      
        //Get the value inside the Property and Cast it to a GameObject
        GameObject selectedObject = (GameObject)m_gameobject.objectReferenceValue;
        
        if (selectedObject != null)
        { 
            //Get All Components inside the GameObject
            Component[] components = selectedObject.GetComponents<Component>() as Component[];

            //this will always be more than 0 (transform) but maybe limit it to user scripts only (is it even possible?)
            if (components.Length > 0) 
            {
                string[] Compmethods;
                allMethods.Clear();
                foreach (Component component in components)
                {
//                    Debug.Log(component.GetType().ToString());
                    
                    if (component.GetType() != typeof(Transform))
                    {

                        Compmethods = component.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) // Instance methods, both public and private/protected
                                .Where(x => x.DeclaringType == component.GetType())
                                .Where(x => x.GetParameters().Length == 0) // Make sure we only get methods with zero argumenrts
                                .Where(x => !ignoreMethods.Any(n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
                                .Select(x => x.Name)
                                .ToArray();

                        foreach (string func in Compmethods)
                            allMethods.Add(func);
                            
                    }                
                }
                
                //Create a DropDown Menu for all the methods in the Components.
                //I have to filter by component. Maybe use a Hashmap to retrive it.
                if (allMethods.Count > 0)
                {
                    int selected = 0;
                    
                    selected = EditorGUILayout.Popup("Functions", selected, allMethods.ToArray());

                    m_function.stringValue = allMethods[selected];
                }
            }
        }
        m_Object.ApplyModifiedProperties();
    }

}