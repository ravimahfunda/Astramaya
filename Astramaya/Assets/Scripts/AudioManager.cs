using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    private LegacyManager lm;

    public AudioSource[] sfxs;
    public AudioSource[] bgms;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lm = new LegacyManager();
        setSfxVolume(lm.GetSFXVolume());
        setBgmVolume(lm.GetBGMVolume());
    }

    public void setSfxVolume(float volume) {
        foreach (AudioSource a in sfxs) {
            a.volume = volume;
        }
    }

    public void setBgmVolume(float volume)
    {
        foreach (AudioSource a in bgms)
        {
            a.volume = volume;
        }
    }
}
