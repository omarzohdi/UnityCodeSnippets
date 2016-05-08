using UnityEngine;
using System.Collections;

public class ChangeColorOnGaze : MonoBehaviour {

    private Color startColor;
    private Color endColor;

    // Use this for initialization
    void Start ()
    {
        startColor = gameObject.GetComponent<Renderer>().material.color;
        endColor = Color.red;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ChangeColorOnEnter ()
    {
        gameObject.GetComponent<Renderer>().material.color = endColor;
    }

    public void ChangeColorOnExit()
    {
        gameObject.GetComponent<Renderer>().material.color = startColor;
    }
}

