using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RadialMenu : MonoBehaviour {

    public RadialButton selected;
    public Text label;

    private List<GameObject> buttonList;
    private bool IntiComplete = false;

    public void SpawnButtons(Interactable obj)
    {
        StartCoroutine(AnimateButtons(obj));
    }

    IEnumerator AnimateButtons(Interactable obj)
    {
        
        buttonList = new List<GameObject>();

        for (int i = 0; i < obj.options.Length; ++i)
        {
            RadialButton CurrentButton = RadialMenuFactories.CreateRadialButton(obj.options[i],this);
            buttonList.Add(CurrentButton.gameObject);

            CurrentButton.transform.localPosition = HelperRadialMenu.GetNextButtonPosition(i, obj.options.Length);

            yield return new WaitForSeconds(0.06f);
        }

        IntiComplete = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                selected.SelectAction();
            }
        }
    }
   
    public void Destroy()
    {
        StartCoroutine(DestoryButtons());
    }

    IEnumerator DestoryButtons()
    {
        while (!IntiComplete)
            yield return new WaitForSeconds(0.06f);

        foreach (GameObject button in buttonList)
        {
            button.GetComponent<Animator>().SetTrigger("hide");
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(0.10f);
        Destroy(gameObject);
    }
}
