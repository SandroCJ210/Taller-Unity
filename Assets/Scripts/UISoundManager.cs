using UnityEngine;
using UnityEngine.UI;

public class UISoundManager : MonoBehaviour
{
    public Slider musicSlider;
    private AudioManager audioManager;
    
    private void Start()
    {
        GameObject audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager = audioManagerObject.GetComponent<AudioManager>();
    }

    public void ToggleMusic()
    {
        audioManager.ToggleMusic();
    }

    public void MusicVolume()
    {
        audioManager.MusicVolume(musicSlider.value);
    }
}
