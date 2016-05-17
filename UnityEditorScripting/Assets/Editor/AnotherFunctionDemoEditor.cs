using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System.Collections;

[CustomEditor(typeof(AnotherFunctionDemo))]
public class AnotherFunctionDemoEditor : Editor
{
    string[] ignoreMethods = new string[] { "Start", "Update" };



    private SerializedObject m_Object;
    private SerializedProperty m_test;

    public void OnEnable()
    {
        m_Object = new SerializedObject(target);
        m_test = m_Object.FindProperty("test");
    }

    public override void OnInspectorGUI()
    {
        m_Object.Update();
        
        EditorGUILayout.PropertyField(m_test);
      
        //Get the value inside the Property and Cast it to a GameObject
        GameObject selectedObject = (GameObject) m_test.objectReferenceValue;
        
        //Get All Components inside the GameObject
        Component[] components = selectedObject.GetComponents<Component>() as Component[];

        //this will always be more than 0 (transform) but maybe limit it to user scripts only (is it even possible?)
        if (components.Length > 0) 
        {
            foreach (Component component in components)
            {
                //Debug.Log(component.gameObject.name);

                string[] methods;

                methods = component.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) // Instance methods, both public and private/protected
                        .Where(x => x.DeclaringType == component.GetType())
                        .Where(x => x.GetParameters().Length == 0) // Make sure we only get methods with zero argumenrts
                        .Where(x => !ignoreMethods.Any(n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
                        .Select(x => x.Name)
                        .ToArray();

             /*   foreach(string s in methods)
                    Debug.Log(s);*/



            }
        }

       m_Object.ApplyModifiedProperties();
    }

}