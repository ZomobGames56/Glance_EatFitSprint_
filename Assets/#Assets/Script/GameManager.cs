using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int index;
    public int fruitCount, junkFoodCount;
    [SerializeField]
    public List<GameObject> gameObjects = new List<GameObject>();
    public GameObject mainMenuPanel;

    public bool isVictory;

    public bool start;
    public string status;
    [SerializeField]
    TextMeshProUGUI fruitCountTxt, junkFoodCountTxt;

    public GameObject makeMeFitScreen;
    public GameObject fightingPanel, collectingPanel;
    [SerializeField]
    GameObject m_movementInstruction;
    [SerializeField]
    AudioClip playBtnClip,winClip,loseClip;

    public static bool gameStartEvent=false;

    bool soundPlayed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        soundPlayed = false;
        start = false;
        collectingPanel.SetActive(false);
        isVictory = false;
        mainMenuPanel.SetActive(true);
        m_movementInstruction.SetActive(false);

       

    }
    private void Start()
    {
        HY_AudioManager.instance.bgAudioSource.UnPause(); 
    }
    private void Update()
    {
        fruitCountTxt.text = fruitCount.ToString();
        junkFoodCountTxt.text = junkFoodCount.ToString();
        if (isVictory && InGameTimer.instance.isGameEnded)
        {
            if (!soundPlayed)
            {
                HY_AudioManager.instance.PlayAudioEffectOnce(winClip);
                soundPlayed = true;
            }
        }
        else if (!isVictory && InGameTimer.instance.isGameEnded)
        {
            if (!soundPlayed)
            {
                HY_AudioManager.instance.PlayAudioEffectOnce(loseClip);
                soundPlayed = true;
            }
        }


    }

   public void GamePause()
    {
        HY_AudioManager.instance.bgAudioSource.Pause();
        HY_AudioManager.instance.forOnShotPlayAudioSource.Pause();
        Time.timeScale = 0;
      
    }
    public void ResumePressed()
    {
       Time.timeScale = 1;
        HY_AudioManager.instance.bgAudioSource.UnPause();
        HY_AudioManager.instance.forOnShotPlayAudioSource.UnPause();
    }
    public void Play()
    {
        if (!gameStartEvent)
        {
            gameStartEvent = true;
            Application.ExternalCall("GameStart"); 
            print("called");
        }
        if (!SaveDataManager.instance.VariableExist("LearnedPlay"))
        {
            m_movementInstruction.SetActive(true);

        }
        else
        {
            start = true;
            collectingPanel.SetActive(true);

        }
        HY_AudioManager.instance.PlayAudioEffectOnce(playBtnClip);
        mainMenuPanel.SetActive(false);
    }
    //---------------------------- -150 to 150 

    public void FitnessStatus(float sliderVal)
    {
        if (sliderVal >= 70 && sliderVal <= 150)
        {
            status = "TOO FAT";
            //200
            // DefaultCoins = 200;
            //default coins


        }
        else if (sliderVal >= 15 && sliderVal <= 69)
        {
            status = "FAT";
            //350
            // DefaultCoins = 350;

        }
        else if (sliderVal >= 6 && sliderVal <= 14)
        {
            status = "FIT";
            //1000
            isVictory = true;
            //  DefaultCoins = 1000;
        }
        else if (sliderVal >= -10 && sliderVal <= 5)
        {
            status = "PERFECT";
            //2000
            isVictory = true;

            //  DefaultCoins = 2000;
            // WinCheck();

        }
        else if (sliderVal >= -14 && sliderVal <= -9)
        {
            status = "FIT";
            //1000
            isVictory = true;

            // DefaultCoins = 1000;

        }
        else if (sliderVal >= -69 && sliderVal <= -15)
        {
            status = "SLIM";
            //350
            // DefaultCoins = 350;

        }
        else if (sliderVal >= -150 && sliderVal <= -70)
        {
            status = "TOO SLIM";
            //200
            // DefaultCoins = 200;

        }
    }
    public void Quit()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(playBtnClip);
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(playBtnClip);
        Application.ExternalCall("m_GameReplay");
        HY_AudioManager.instance.bgAudioSource.Pause();
        Application.ExternalCall("replayEvent");
    }

}
