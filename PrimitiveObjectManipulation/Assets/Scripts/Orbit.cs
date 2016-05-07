using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

	public float degrees = 1;
	public GameObject target;
	public Vector3 axis = Vector3.up;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.RotateAround (target.transform.position, axis, degrees);
	}
}
