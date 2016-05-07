using UnityEngine;
using System.Collections;

public class GenereateRandomInArea : MonoBehaviour {


	public int count;
	public GameObject Parent;
	public GameObject Spawn;

	private Vector3 MaxRange;
	private Vector3 MinRange;

	// Use this for initialization
	void Start () 
	{
		this.GenerateSpawn ();
	}

	private void FindMaxMinRange ()
	{
		Vector3 streamSize =  this.transform.localScale;
		Vector3 streamPos = this.transform.position;
		
		MaxRange = streamSize / 2;//( Vector3.Scale(area.size , area.transform.localScale)) /2;
		MinRange = MaxRange * -1;
		
		MaxRange += streamPos;
		MinRange += streamPos;
	}

	private void GenerateSpawn()
	{
		this.FindMaxMinRange ();
		//Doesn't account of Cubes that have already been spawned!
		Vector3 position = new Vector3 ();

		GameObject Group;

		if (Parent == null) 
		{
			Group = new GameObject(this.name + "_Parent");
			Instantiate (Group, this.transform.position, Quaternion.identity);
		}
		else
			Group = GameObject.Find(Parent.name);
		
		for (int i=0; i< count; ++i) 
		{
			position.x = Random.Range(MinRange.x, MaxRange.x);
			position.y = Random.Range(MinRange.y, MaxRange.y);
			position.z = Random.Range(MinRange.z, MaxRange.z);
			
			
			GameObject temp = Instantiate (Spawn, position, Quaternion.identity) as GameObject;
			temp.transform.parent = Group.transform;
		}
	}
	
	public void getMaxMin (ref Vector3 Max, ref Vector3 Min)
	{
		Max = MaxRange;
		Min = MinRange;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
