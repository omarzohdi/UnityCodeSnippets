using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image circle;
    public Image icon;
    public string title;

    private RadialMenu parentmenu;
    private Color defaultColor;

	[HideInInspector]
	public delegate void ActionDelegate();
	public ActionDelegate ExecuteAction;

	
    public void Start()
    {
        parentmenu = this.transform.parent.GetComponent<RadialMenu>();
        defaultColor = circle.color;
    }
    public void SelectAction ()
    {
		this.ExecuteAction();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        parentmenu.selected = this;
        circle.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        parentmenu.selected = null;
        circle.color = defaultColor;
    }
}
