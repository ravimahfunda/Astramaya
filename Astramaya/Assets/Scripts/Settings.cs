using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    LegacyManager lm;

    public Slider sfxSlider;
    public Slider bgmSlider;


    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();
        sfxSlider.value = lm.GetSFXVolume();
        bgmSlider.value = lm.GetBGMVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSFXVolume() {
        lm.SetSFXVolume(sfxSlider.value);
        AudioManager.Instance.setSfxVolume(sfxSlider.value);
    }

    public void SetBGMVolume()
    {
        lm.SetBGMVolume(bgmSlider.value);
        AudioManager.Instance.setBgmVolume(bgmSlider.value);
    }

    public void ResetData()
    {
        lm.ResetData();
    }
}
