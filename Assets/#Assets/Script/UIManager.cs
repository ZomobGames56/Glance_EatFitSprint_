using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField]
    TextMeshProUGUI foodCountText,junkfoodText,coinText,diamondText;

    [SerializeField]
    public GameObject gameOverPanel,settingPanel;
    [SerializeField]
    AudioClip buttonClip;

    
    public TextMeshProUGUI countDownText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        gameOverPanel.SetActive(false);
        settingPanel.SetActive(false);
        countDownText.gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        foodCountText.text = GameManager.instance.fruitCount.ToString();
        junkfoodText.text = GameManager.instance.junkFoodCount.ToString();
    }

    public void SettingBtn()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(buttonClip);
        settingPanel.SetActive(true);
    }

    public void NO()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(buttonClip);
        settingPanel.SetActive(false);
    }

}
