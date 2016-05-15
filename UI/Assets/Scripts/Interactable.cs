using UnityEngine;
using System.Collections;

[System.Serializable]    //make editable in inspector
public class Action
{
    public Color color;
    public Sprite sprite;
    public string title;
}

[RequireComponent(typeof(Animator))]
public class Interactable : MonoBehaviour {
    
    public Action[] options;
    public string title;

    void Start()
    {
        if (title.Length == 0 || title == null)
            title = gameObject.name;
    }

	void OnMouseDown()
    {
        UIManager.Instance.SpawnRadialMenu(this);
    }

    void OnMouseUp()
    {
        UIManager.Instance.KillRadialMenu();
    }
}
