using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravBody : MonoBehaviour {

	public Gravity GravSource;
	
	// Use this for initialization
	void Awake () {
		this.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		this.gameObject.GetComponent<Rigidbody> ().useGravity = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		GravSource.ApplyGravity (this.transform);
	}
}
