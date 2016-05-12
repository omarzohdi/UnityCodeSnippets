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

	void OnMouseDown()
    {
        //tell Canvas to Spawn a Menu;
    }
}
