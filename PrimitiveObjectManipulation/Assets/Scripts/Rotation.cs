using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float degrees;
	public Vector3 axis;

	// Use this for initialization
	void Start () 
	{
		degrees = 1.0f;
		while (axis.Equals(Vector3.zero)) {
			axis.x = (float)Random.Range (0, 2);
			axis.y = (float)Random.Range (0, 2);
			axis.z = (float)Random.Range (0, 2);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Rotate (degrees * axis.x, degrees * axis.y, degrees * axis.z);
	}
}
