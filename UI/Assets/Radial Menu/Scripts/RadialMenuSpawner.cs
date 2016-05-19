using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenuSpawner : MonoBehaviour {

    RadialMenu currMenu;

    public void SpawnMenu(Interactable Options)
    {
        if (currMenu == null)
        { 
            currMenu = RadialMenuFactories.CreateRadialMenu(Options.title);
            currMenu.SpawnButtons(Options);
        }
    }

    public void KillMenu ()
    {
        currMenu.Destroy();
    }

}
