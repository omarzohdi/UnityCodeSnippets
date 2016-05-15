using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIManager : MonoBehaviour {

    private static GameObject UIContainer;
    private static UIManager _instance;
    public GameObject eventSystem;

    #region Initialization
    public static UIManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
                if (!_instance)
                {
                    UIContainer = new GameObject();
                    UIContainer.name = "UIContainer";
                    _instance = UIContainer.AddComponent(typeof(UIManager)) as UIManager;
                }
            }

            return _instance;
        }
    }

    private void SetupUIContainer()
    {
        UIContainer = GameObject.Find("UIContainer");
        if (UIContainer == null)
        {
            UIContainer = new GameObject();
            UIContainer.name = "UIContainer";
        }
    }
    private void SetupEventSystem()
    {
        EventSystem _eventSystem = FindObjectOfType<EventSystem>();
        if (_eventSystem == null)
        {
            eventSystem = new GameObject();
            eventSystem.name = "EventSystem";
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        else
            eventSystem = _eventSystem.gameObject;

        eventSystem.transform.SetParent(UIContainer.transform);
    }

    public void Initialize()
    {
        this.SetupUIContainer();
        this.SetupEventSystem();
        this.SetupRadialMenuCanvas();
    }
    #endregion

    #region RadialMenus

    public GameObject radMenuCanvas;
    public RadialButton RadialButtonPrefab;
    public RadialMenu RadialMenuPrefab;
    private GameObject radialMenuObject;

    private void SetupRadialMenuCanvas ()
    {
        RadialMenuSpawner MenuSpawn = FindObjectOfType<RadialMenuSpawner>();
        if (MenuSpawn == null)
            radMenuCanvas = Instantiate(radMenuCanvas) as GameObject;
        else
            radMenuCanvas = MenuSpawn.gameObject;

        radMenuCanvas.transform.SetParent(UIContainer.transform);     
    }

    public void SpawnRadialMenu(Interactable menuOptions)
    {
        radMenuCanvas.GetComponent<RadialMenuSpawner>().SpawnMenu(menuOptions);
    }

    public void KillRadialMenu ()
    {
        radMenuCanvas.GetComponent<RadialMenuSpawner>().KillMenu();
    }
    #endregion

    void Awake()
    {
        this.Initialize(); 
    }
}