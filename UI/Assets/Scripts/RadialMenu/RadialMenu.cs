using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RadialMenu : MonoBehaviour {

    public RadialButton selected;
    public Text label;

    private Interactable GameObjectRef;

    private List<GameObject> buttonList;

    // Use this for initialization
    public void SpawnButtons(Interactable obj)
    {
        GameObjectRef = obj;
        StartCoroutine(AnimateButtons(obj));
    }

    IEnumerator AnimateButtons(Interactable obj)
    {
        buttonList = new List<GameObject>();

        for (int i = 0; i < obj.options.Length; ++i)
        {
            RadialButton newButton = Instantiate(UIManager.Instance.RadialButtonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);

            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xpos = Mathf.Sin(theta);
            float ypos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xpos, ypos, 0f) * 100f;

            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;

            buttonList.Add(newButton.gameObject);

            yield return new WaitForSeconds(0.06f);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                selected.SelectAction();
            }

            StartCoroutine(DestoryButtons());
        }
    }


    void OnDestroy()
    {
        
    }

    IEnumerator DestoryButtons()
    {
        foreach (GameObject button in buttonList)
        {
            button.GetComponent<Animator>().SetTrigger("hide");
            yield return new WaitForSeconds(0.06f);
        }
        Destroy(gameObject);

    }
}
