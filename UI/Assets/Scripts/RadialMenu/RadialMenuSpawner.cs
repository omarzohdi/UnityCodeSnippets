using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenuSpawner : MonoBehaviour {

    RadialMenu currMenu;

    public void SpawnMenu(Interactable Options)
    {
        currMenu = RadialMenuFactories.CreateRadialMenu(Options.title);
        currMenu.SpawnButtons(Options);
    }

}
