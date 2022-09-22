using UnityEngine;
using UnityEngine.Audio;

public class SFXVol : MonoBehaviour
{
    
    [SerializeField] private AudioMixer sfxMixer;

    public void SetVolume(float sliderValue){
        sfxMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }

}
