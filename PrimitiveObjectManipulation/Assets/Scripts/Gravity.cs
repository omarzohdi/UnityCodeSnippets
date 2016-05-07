using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public float gravity = -10.0f;


	private GameObject ground;
	private Mesh _mesh;


	public void ApplyGravity(Transform inBody)
	{
		Vector3 bodyUp = inBody.up;

		inBody.GetComponent<Rigidbody>().AddForce (this.transform.up * this.gravity);
	
		Quaternion GravRotation = Quaternion.FromToRotation (bodyUp, this.transform.up) * inBody.rotation;

		inBody.rotation = Quaternion.Slerp (inBody.rotation, GravRotation, 50 * Time.deltaTime);

	}

	// Use this for initialization
	void Start () {

		this._mesh = this.GetComponent<MeshFilter> ().mesh;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_mesh.RecalculateNormals ();
	}
}
