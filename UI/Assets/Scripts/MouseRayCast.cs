 using UnityEngine;
using System.Collections;

public class MouseRayCast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");
            RayCast3D();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
            RayCast2D();
        }
    }

    //Ray Cast to a Sprite!
    public static bool RayCast2D()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
      
        if (hit)
        {
            return true;
        }

        return false;
    }

    //Ray Cast to a 3d Object
    public static bool RayCast3D()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return true;
        }

        return false;
    }
}
