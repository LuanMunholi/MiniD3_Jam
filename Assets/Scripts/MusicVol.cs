using UnityEngine;
using UnityEngine.Audio;

public class MusicVol : MonoBehaviour
{
    
    [SerializeField] private AudioMixer menuMixer;

    public void SetVolume(float sliderValue){
        menuMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

}
