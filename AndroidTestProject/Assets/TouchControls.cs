using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

    private Touch touch;

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update ()
    {
        touch = Input.GetTouch(0);
        
        Vector3 temp = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(touch.position);

        this.GetComponent<BoxCollider>().bounds.Contains(temp);
       
    }
}
