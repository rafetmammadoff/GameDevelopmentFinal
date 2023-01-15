using CASP.SoundManager;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
//using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject PostcardPanel;
    [SerializeField] GameObject firstImage;
    [SerializeField] GameObject secondImage;
    [SerializeField] GameObject slice3Image;
    [SerializeField] RectTransform slice3ImageTransform;
    [SerializeField] GameObject slice4Image;
    [SerializeField] RectTransform slice4ImageTransform;
    [SerializeField] GameObject LoadingPanel;
    [SerializeField] GameObject GeneralPanel;
    [SerializeField] GameObject FailPanel;
    [SerializeField] GameObject LevelPanel;
    [SerializeField] GameObject HomePanel;
    [SerializeField] GameObject OptionsPanel;
    [SerializeField] GameObject OptionsPanelGame;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject bigablePausePanel;
    [SerializeField] GameObject FirstVideo;
    [SerializeField] GameObject SecondVideo;
    [SerializeField] GameObject StoryPanel;
    [SerializeField] GameObject firstVideoPlayer;
    [SerializeField] GameObject secondVideoPlayer;

    [SerializeField] GameObject StoryVideoPlayer;
    [SerializeField] GameObject StoryVideo;
    public bool isFindSlice3 = false;
    public bool isFindSlice4 = false;
    public GameObject fillAbleImage;
    PointerEventData eventData;
    public bool isStart = true;
    public Loader isLoader;

    private void Awake()
    {
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        EditorApplication.playModeStateChanged += ResetSO;

    }

    private void ResetSO(PlayModeStateChange state)
    {
        if (state==PlayModeStateChange.ExitingPlayMode)
        {
            isLoader.canStart = true;
        }
    }

    private void Start()
    {
        Debug.Log(isLoader);
        if (!isLoader.canStart)
        {
            OpenSecondVideo();  
        }
        if (isLoader.canStart)
        {
            //secondVideoPlayer = GameObject.FindGameObjectWithTag("svp");
            //firstVideoPlayer = GameObject.FindGameObjectWithTag("fvp");
        }

        if (isLoader.canStart)
        {
            LoadingPanel.SetActive(true);
            DOTween.To(() => fillAbleImage.GetComponent<Image>().fillAmount, x => fillAbleImage.GetComponent<Image>().fillAmount = x, 1, 2f).OnComplete(() =>
            {
                LoadingPanel.SetActive(false);
                firstVideoPlayer.GetComponent<VideoPlayer>().enabled=true;
                FirstVideo.GetComponent<RawImage>().enabled=true;
                StartCoroutine(waitChangeColor());
                StartCoroutine(Loading());
            });
            isLoader.canStart = false;
        }
        DontDestroyOnLoad(this);


    }

    // Update is called once per frame
    void Update()
    {
        if (isFindSlice3)
        {
            PostcardPanel.SetActive(true);
            firstImage.SetActive(true);
            secondImage.SetActive(false);
            StartCoroutine(bigSlice3());
            isFindSlice3= false;
        }
        if (isFindSlice4)
        {
            PostcardPanel.SetActive(true);
            secondImage.SetActive(true);
            firstImage.SetActive(false);
            StartCoroutine(bigSlice4());
            isFindSlice4= false;
        }

    }
    public void OpenLevelPanel()
    {
        LevelPanel.SetActive(true);
        HomePanel.SetActive(false);
    }
    public IEnumerator bigSlice3()
    {
        yield return new WaitForSeconds(1);
        slice3Image.transform.DOMove(slice3ImageTransform.position,0.4f);
        // slice2Image.transform.DOScale(0.9262591f, 0.2f);
    }
    public IEnumerator bigSlice4()
    {
        yield return new WaitForSeconds(1);
        slice4Image.transform.DOMove(slice4ImageTransform.position, 0.4f);
        // slice2Image.transform.DOScale(0.9262591f, 0.2f);
    }
    public void OpenSecondVideo()
    {
        LevelPanel.SetActive(false) ;
        SecondVideo.GetComponent<RawImage>().enabled=true ;
        secondVideoPlayer.GetComponent<VideoPlayer>().enabled = true; 
        StartCoroutine(LoadingSecVideo());

    }

    public void OpenStoryVideo()
    {
        StoryPanel.SetActive(true);
        StoryVideo.GetComponent<RawImage>().enabled = true;
        StoryVideoPlayer.GetComponent<VideoPlayer>().enabled = true;
    }
    public void CloseStoryVideo()
    {
        StoryPanel.SetActive(false) ;
        StoryVideo.GetComponent<RawImage>().enabled = false;
        StoryVideoPlayer.GetComponent<VideoPlayer>().enabled = false;
    }
    public void closePostcardPanel()
    {
        PostcardPanel.SetActive(false);
    }
    public void openPausePanel()
    {
        PausePanel.SetActive(true);
        bigablePausePanel.transform.localScale = Vector3.zero;
        GeneralPanel.SetActive(false);
        bigablePausePanel.transform.DOScale(1f, 0.4f).OnComplete(() =>
        {

            Time.timeScale= 0f;
        });
    }
    public void openSettingPanel()
    {
        Time.timeScale= 1f;
        OptionsPanel.SetActive(true);
       // OptionsPanel.transform.localScale = Vector3.zero;
            Time.timeScale = 0f;
        //OptionsPanel.transform.DOScale(1f, 0.4f).OnComplete(() =>
        //{
        //});
    }
    public void openSettingPanelGame()
    {
        Time.timeScale = 1f;
        OptionsPanelGame.SetActive(true);
       // OptionsPanelGame.transform.localScale = Vector3.zero;
            Time.timeScale = 0f;
        //OptionsPanelGame.transform.DOScale(1f, 0.4f).OnComplete(() =>
        //{
        //});
    }
    public void openHomePanel()
    {
        Debug.Log("aaaaaaaaaaaaa");
        LevelPanel.SetActive(false);
        FailPanel.SetActive(false); 
        Time.timeScale = 1f;
        HomePanel.SetActive(true);
        //HomePanel.transform.localScale = Vector3.zero;
        //HomePanel.transform.DOScale(1f, 0.4f).OnComplete(() =>
        //{
        //    GeneralPanel.SetActive(false) ;
        //    PausePanel.SetActive(false);
        //});
        GeneralPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void OpenFailPanel()
    {
        FailPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void CloseSettingPanelExit()
    {
        Time.timeScale = 1f;
        OptionsPanel.SetActive(false);
    }
    public void CloseSettingPanelGameExit()
    {
        Time.timeScale = 1f;
        OptionsPanelGame.SetActive(false);
        Time.timeScale = 0f;
        
    }
    public void ClosePausePaneResume()
    {
        Time.timeScale = 1f;
        bigablePausePanel.transform.DOScale(0f, 0.4f).OnComplete(() =>
        {
            PausePanel.SetActive(false);
        });
        GeneralPanel.SetActive(true);
        
    }

    public IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        HomePanel.SetActive(true);
        //HomePanel.transform.localScale = Vector3.zero;
        //HomePanel.transform.DOScale(1f, 0.4f).OnComplete(() =>
        //{
        //    FirstVideo.GetComponent<RawImage>().enabled=false;
        //});
        FirstVideo.GetComponent<RawImage>().enabled = false;
    }

    public IEnumerator LoadingSecVideo()
    {
        yield return new WaitForSeconds(1);
        secondVideoPlayer.GetComponent<VideoPlayer>().enabled = false;
        SecondVideo.GetComponent<RawImage>().enabled=false ;
        GeneralPanel.SetActive(true);
    }

    public void Restart()
    {
        FailPanel.SetActive(false); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Time.timeScale = 1;
        OpenSecondVideo();
    }

    public IEnumerator wait3()
    {
        yield return new WaitForSeconds(2);
    }
    public IEnumerator waitChangeColor()
    {
        yield return new WaitForSeconds(.4f);
        FirstVideo.GetComponent<RawImage>().color = Color.white;

    }
}
