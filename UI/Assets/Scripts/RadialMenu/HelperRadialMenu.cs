using UnityEngine;
using System.Collections;

public class HelperRadialMenu
{
    public static Vector3 GetNextButtonPosition( int idx, int length)
    {
        float theta = (2 * Mathf.PI / length) * idx;
        float xpos = Mathf.Sin(theta);
        float ypos = Mathf.Cos(theta);

        return (new Vector3(xpos, ypos, 0f) * 100f);
    }
}
