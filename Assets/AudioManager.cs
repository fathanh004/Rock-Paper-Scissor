using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource sfxInstance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    private void Awake()
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        

        if (sfxInstance != null)
        {
            Destroy(sfx.gameObject);
            sfx = sfxInstance;
        }

        DontDestroyOnLoad(bgm.gameObject);
        DontDestroyOnLoad(sfx.gameObject);
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }
        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfx.isPlaying)
        {
            sfx.Stop();
        }
        sfx.clip = clip;
        sfx.Play();
    }
}
