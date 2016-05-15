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

    public void Start()
    {
        parentmenu = this.transform.parent.GetComponent<RadialMenu>();
        defaultColor = circle.color;
    }
    public virtual void SelectAction ()
    {
        Debug.Log("Action is in Effect");
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
