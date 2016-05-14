using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor( typeof (UIManager)) ]
public class UIManagerEditor : Editor
{
    private SerializedObject m_Object;

    //Standard Variables
    private SerializedProperty m_eventSystem;

    //Radial Menu
    private SerializedProperty m_radmenucanvas;
    private SerializedProperty m_radialmenu;
    private SerializedProperty m_radialbutton;

    //Foldout bools
    private bool ShowUIProperties = true;
    private bool ShowRadialMenuProperties = true;

    public void OnEnable()
    {
        m_Object = new SerializedObject(target);

        m_eventSystem = m_Object.FindProperty("eventSystem");
        m_radmenucanvas = m_Object.FindProperty("radMenuCanvas");
        m_radialmenu = m_Object.FindProperty("RadialMenuPrefab");
        m_radialbutton = m_Object.FindProperty("RadialButtonPrefab");


    }
    public override void OnInspectorGUI()
    {

        m_Object.Update();

        int defaultindentlevel = EditorGUI.indentLevel;

        EditorGUI.indentLevel++;
        ShowUIProperties = EditorGUILayout.Foldout(ShowUIProperties, "UI Properties");

        if (ShowUIProperties)
        { 
            EditorGUILayout.PropertyField(m_eventSystem);
        }


        ShowRadialMenuProperties = EditorGUILayout.Foldout(ShowRadialMenuProperties, "Radial Menu Properties");

        if (ShowRadialMenuProperties)
        {
            EditorGUILayout.PropertyField(m_radmenucanvas);
            EditorGUILayout.PropertyField(m_radialmenu);
            EditorGUILayout.PropertyField(m_radialbutton);
        }

        m_Object.ApplyModifiedProperties();
      
       // base.OnInspectorGUI();
    }

}
