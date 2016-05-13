using UnityEngine;
using System.Collections;

public class RadialMenuSpawner : MonoBehaviour {

    public static RadialMenuSpawner instance;
    public RadialMenu menuPrefab;

    void Awake()
    {
        if (null == instance)
            instance = this;
    }
    
    public void SpawnMenu()
    {
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        newMenu.transform.SetParent(transform, false);
        newMenu.transform.position = Input.mousePosition;
    }

}
