using UnityEngine;
using System.Reflection;
using System.Collections;

public class AnotherFunctionDemo : MonoBehaviour {

	public GameObject selgameobject;
	public Component comp;
	public string function;

	void Start()
	{
        selgameobject.SendMessage(function);
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
