using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenuSpawner : MonoBehaviour {

    public static RadialMenuSpawner instance;
    public RadialMenu menuPrefab;

    void Awake()
    {
        if (null == instance)
            instance = this;
    }
    
    public void SpawnMenu(Interactable obj)
    {
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        newMenu.transform.SetParent(transform, false);
        newMenu.transform.position = Input.mousePosition;
        newMenu.label.text = obj.title.ToUpper();
        newMenu.SpawnButtons(obj);
    }

}
