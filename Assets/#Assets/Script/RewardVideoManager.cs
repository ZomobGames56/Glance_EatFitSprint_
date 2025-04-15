using UnityEngine;

public class RewardVideoManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip playBtnClip;
    public void RewaredVideo()
    {
        HY_AudioManager.instance.PlayAudioEffectOnce(playBtnClip);
        HY_AudioManager.instance.bgAudioSource.Pause();
        Application.ExternalCall("rewardEvent");
    }
}
