using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenu : MonoBehaviour {

    public RadialButton buttonPrefab;
    public RadialButton selected;
    public Text label;

	// Use this for initialization
	public void SpawnButtons (Interactable obj)
    {
        StartCoroutine(AnimateButtons(obj));
        //foreach (Interactable.Action A in obj.options)
     /*   for (int i = 0; i< obj.options.Length; ++i)
        { 
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);

            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xpos = Mathf.Sin(theta);
            float ypos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xpos, ypos, 0f) * 100f;

            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
        }
        */
    }

    IEnumerator AnimateButtons(Interactable obj)
    {
        for (int i = 0; i < obj.options.Length; ++i)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);

            float theta = (2 * Mathf.PI / obj.options.Length) * i;
            float xpos = Mathf.Sin(theta);
            float ypos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xpos, ypos, 0f) * 100f;

            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
            newButton.Anim();
            yield return new WaitForSeconds(0.06f);
        }
    }

    void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (selected)
            {
                selected.SelectAction();
            }

            Destroy(gameObject);
        }
    }
}
