using UnityEngine;
using System.Collections;
using System.Reflection;

public class FunctionDemo : MonoBehaviour
{
	public string MethodToCall;
	
	void Start()
	{
		typeof(FunctionDemo)
			.GetMethod(MethodToCall, BindingFlags.Instance |BindingFlags.NonPublic | BindingFlags.Public)
				.Invoke(this, new object[0]);
	}
	
	void Update()
	{

        Component x = (Component)this;

            	
	}
	
	void Foo()
	{
		Debug.Log("Foo - Foo");
	}
	
	void Bar()
	{
		Debug.Log("Bar");
	}

	void Potato()
	{
		Debug.Log ("Potato");
	}
}