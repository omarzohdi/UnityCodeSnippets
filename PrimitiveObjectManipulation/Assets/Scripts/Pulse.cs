using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	private Vector3 startScale;
	private Vector3 currentScale;
	private Vector3 endScale;

	public float speed = 0.7f;
	// Use this for initialization
	void Start () 
	{
		startScale = this.transform.localScale;
		currentScale = startScale;
		endScale = new Vector3 (0.5f, 0.5f, 0.5f);

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (AlmostEqual(currentScale, endScale, 0.1f))
			SwitchScaleDirecion ();
	
		currentScale =  Vector3.Lerp (currentScale, endScale, Time.deltaTime * speed);

		this.transform.localScale= currentScale;
		//if (currentScale.Equals(startScale))

	}

	private void SwitchScaleDirecion()
	{
		Vector3 Temp;
		Temp = startScale;
		startScale = endScale;
		endScale = Temp;
	}

	private bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
	{
		bool equal = true;
		
		if (Mathf.Abs (v1.x - v2.x) > precision) equal = false;
		if (Mathf.Abs (v1.y - v2.y) > precision) equal = false;
		if (Mathf.Abs (v1.z - v2.z) > precision) equal = false;
		
		return equal;
	}

}
