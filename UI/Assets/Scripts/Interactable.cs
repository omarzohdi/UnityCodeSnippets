using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    [System.Serializable] //make editable in inspector
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string title;
    }

    public Action[] options;
    public string title;

    void Start()
    {
        if (title.Length == 0 || title == null)
        {
            title = gameObject.name;
        }
    }

	void OnMouseDown()
    {
        RadialMenuSpawner.instance.SpawnMenu(this);
    }
}
