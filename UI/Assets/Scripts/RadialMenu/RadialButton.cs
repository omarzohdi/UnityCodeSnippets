using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image circle;
    public Image icon;
    public string title;
    public RadialMenu myMenu; //not sure I need a ref back to the menu (it's technically a parent anyway)

    Color defaultColor;

    public float speed = 8f;    //animation speed

    public void SelectAction ()
    {
        Debug.Log("Action is in Effect");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selected = this;
        defaultColor = circle.color;
        circle.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selected = null;
        circle.color = defaultColor;
    }
}
