using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;


    [Header("#BGM")]
    [SerializeField]
    private AudioClip[] bgmClips;

    [Header("#SFX")]
    [SerializeField]
    private AudioClip[] sfxClips;

    [Range(0f, 1f)]
    private float bgmVolume = .5f;

    [Range(0f, 1f)]
    public float sfxVolume = .7f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        } else
        {
            Destroy(gameObject);
        }

        InitSoundPlayer();
    }

    private void InitSoundPlayer()
    {
        // BGM Player 초기화
        // 빈 오브젝트를 생성하고 부모를 현재 오브젝트로 설정
        GameObject bgmPlayerObject = new GameObject("BGMPlayer");
        bgmPlayerObject.transform.SetParent(transform);

        // 오브젝트에 AudioSource 컴포넌트를 추가
        bgmPlayer = bgmPlayerObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false; // 오브젝트 활성화 시 소리 자동 재생 여부 = false
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        //SFX Player 초기화 
        GameObject sfxPlayerObject = new GameObject("SfxPlayer");
        sfxPlayerObject.transform.SetParent(transform);

        // 오브젝트에 AudioSource 컴포넌트를 추가
        sfxPlayer = sfxPlayerObject.AddComponent<AudioSource>();
        sfxPlayer.playOnAwake = false; // 오브젝트 활성화 시 소리 자동 재생 여부 = false
        sfxPlayer.loop = true;
        sfxPlayer.volume = sfxVolume;
    }


    public void PlaySoundBGM()
    {
        PlaySound(bgmPlayer, bgmClips, "VideoGameBgm");
    }


    public void PlaySoundPop()
    {
        PlaySound(sfxPlayer, sfxClips, "BubblePop");

    }

    public void PlaySoundGameStart()
    {
        PlaySound(sfxPlayer, sfxClips, "GameStart");
    }


    private void PlaySound(AudioSource player, AudioClip[] clicps, string selectedClip)
    {
        AudioClip playClip = null;

        foreach(AudioClip clip in clicps)
        {
            if (clip.name.Contains(selectedClip))
            {
                playClip = clip;
                break;
            }
        }

        if (playClip != null)
        {
            player.PlayOneShot(playClip);
        } else
        {
            Debug.Log($"{selectedClip} sound is empty.");
        }

    }

}
