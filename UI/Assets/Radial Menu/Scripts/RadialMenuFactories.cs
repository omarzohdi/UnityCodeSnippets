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

    public static RadialButton CreateRadialButton (Action action, RadialMenu menu)
    {
        RadialButton newButton = Instantiate(UIManager.Instance.RadialButtonPrefab) as RadialButton;
        newButton.transform.SetParent(menu.transform, false);

		newButton.ExecuteAction = action.ExecuteAction;
        newButton.circle.color = action.color;
        newButton.icon.sprite = action.sprite;
        newButton.title = action.title;

        return newButton;
    }

}
