using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using System.Collections;

[System.Serializable]    //make editable in inspector
public class Action: IEventSystemHandler
{
	[System.Serializable]  
	public class ActionTrigger : UnityEvent {}

    public Color color;
    public Sprite sprite;
    public string title;
	public bool triggered;
	public bool triggerOnce;

	[SerializeField]
	private ActionTrigger afterTrigger = new ActionTrigger();
	
	public void ExecuteAction()
	{
		if (!triggered)
		{
			afterTrigger.Invoke();
			if (triggerOnce) { triggered = true; }
		}
	}
}

[RequireComponent(typeof(Animator))]
public class Interactable : MonoBehaviour {
    
    public Action[] options;
    public string title;

    void Start()
    {
        if (title.Length == 0 || title == null)
            title = gameObject.name;
    }

	void OnMouseDown()
    {
        UIManager.Instance.SpawnRadialMenu(this);
    }

    void OnMouseUp()
    {
        UIManager.Instance.KillRadialMenu();
    }
}
