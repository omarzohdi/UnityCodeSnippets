using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroScreenManager : MonoBehaviour
{
    public GameObject Background;
    public GameObject Title;
    public GameObject SubTitle;

    [HideInInspector]
    public bool BgAnimIsPlaying;
    [HideInInspector]
    public bool TitleAnimIsPlaying;
    [HideInInspector]
    public bool StitleAnimIsPlaying;

    private Animator BackGroundAnimator;
    private Animator TitleAnimator;
    private Animator SubTitleAnimator;

    private AsyncOperation LevelLoading;
    private bool IntroDone;

    // Use this for initialization
    void Awake()
    {
        BgAnimIsPlaying = true;
        TitleAnimIsPlaying = true;
        StitleAnimIsPlaying = true;

        BackGroundAnimator = Background.GetComponent<Animator>();
        TitleAnimator = Title.GetComponent<Animator>();
        SubTitleAnimator = SubTitle.GetComponent<Animator>();

        IntroDone = false;

        StartCoroutine(LoadLevel());
        
    }    
    
    // Update is called once per frame
    IEnumerator LoadLevel()
    {
        Debug.Log("LoadLevel()");

        yield return new WaitForSeconds(5);

        LevelLoading = SceneManager.LoadSceneAsync("RadialMenuCleanUp", LoadSceneMode.Additive);

        while (!IntroDone)
        {
            if (LevelLoading.isDone)
            {
                StartCoroutine(StartFadeOut());
                IntroDone = true;
            }
            yield return new WaitForSeconds(2);
        }
        
        yield return null;
    }

    IEnumerator StartFadeOut()
    {
        TitleAnimator.SetTrigger("LoadingDone");
        SubTitleAnimator.SetTrigger("LoadingDone");

        TitleAnimIsPlaying = TitleAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadeOut_UI");
        StitleAnimIsPlaying = SubTitleAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadeOut_UI");

        if (!TitleAnimIsPlaying && !StitleAnimIsPlaying)
        {
            StartCoroutine(SwitchLevel());
        }

        yield return null;
    }

    IEnumerator SwitchLevel()
    {
        bool fadingdone = false;
        BackGroundAnimator.SetTrigger("LoadingDone");

        while (!fadingdone)
        {
            yield return new WaitForSeconds(1);

            BgAnimIsPlaying = BackGroundAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadeOutBackground_UI");

            if (!BgAnimIsPlaying)
            {
                SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("RadialMenuCleanUp"));
                fadingdone = true;
            }
        }

        yield return null;
    }
}
