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
        LevelLoading = SceneManager.LoadSceneAsync("RadialMenuCleanUp", LoadSceneMode.Additive);
        LevelLoading.allowSceneActivation = false;

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

        yield return new WaitForSeconds(SubTitleAnimator.GetCurrentAnimatorStateInfo(0).length);

        bool firstrun = true;

        while (!IntroDone)
        {
            if (LevelLoading.isDone)
            {
                TitleAnimator.SetTrigger("LoadingDone");
                SubTitleAnimator.SetTrigger("LoadingDone");

                if (firstrun)
                {
                    yield return new WaitForSeconds(2);
                    firstrun = false;
                }
               
                TitleAnimIsPlaying = TitleAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadeOut_UI");
                StitleAnimIsPlaying = SubTitleAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadeOut_UI");

                if (!TitleAnimIsPlaying && !StitleAnimIsPlaying)
                {
                    BackGroundAnimator.SetTrigger("LoadingDone");
                    BgAnimIsPlaying = BackGroundAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadeOutBackground_UI");

                    if (BgAnimIsPlaying == false)
                    {
                        SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("RadialMenuCleanUp"));
                        IntroDone = true;
                    }
                }
            }
        }
    }
}
