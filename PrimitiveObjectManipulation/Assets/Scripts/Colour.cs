using UnityEngine;
using System.Collections;

public class Colour : MonoBehaviour {
	
	public float speed;
	
	private Color currentColor;
	private Color endColor;

	// Use this for initialization
	void Start () 
	{

		currentColor = gameObject.GetComponent<Renderer>().material.color;
		UpdateEndcolor ();
		speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!AlmostEqual(currentColor,endColor, 0.05f) ) 
		{
			currentColor = Color.Lerp (currentColor, endColor, Time.deltaTime * speed);
			gameObject.GetComponent<Renderer> ().material.color = currentColor;
		}
		else
			UpdateEndcolor ();


	}

	void UpdateEndcolor()
	{
		endColor = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
	}

	private bool AlmostEqual(Color c1, Color c2, float precision)
	{
		bool equal = true;
		
		if (Mathf.Abs (c1.r - c2.r) > precision) equal = false;
		if (Mathf.Abs (c1.g - c2.g) > precision) equal = false;
		if (Mathf.Abs (c1.b - c2.b) > precision) equal = false;
		
		return equal;
	}

}
