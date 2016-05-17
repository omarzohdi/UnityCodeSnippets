using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(AnotherFunctionDemo))]
public class AnotherFunctionDemoEditor : Editor
{
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
        
        /*
        Component[] components = Selection.activeGameObject.GetComponents<Component>() as Component[];
        //If the length of components is > 0 (always WILL be, since every GameObject is
        //guarenteed to have a Transform Component at the very minimum
        if (components.Length > 0)
        {
            //Print all the components to console
            foreach (Component component in components)
                Debug.Log(component);
            //Set the current selection to the components
            Selection.objects = (Object[])components;
        }*/


        m_Object.ApplyModifiedProperties();
    }
}