using UnityEngine;
using System.Collections;

public class RadialMenuFactories : MonoBehaviour
{
    public static RadialMenu CreateRadialMenu (string title )
    {
        RadialMenu newMenu = Instantiate(UIManager.Instance.RadialMenuPrefab) as RadialMenu;
        newMenu.transform.SetParent(UIManager.Instance.radMenuCanvas.transform, false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.label.text = title.ToUpper();

        return newMenu;
    }

    public static RadialButton CreateRadialButton ()
    {
        return null;
    }

}
