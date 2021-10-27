using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一开始写的AudioManager
// wolaile!!
// 本来想像bagmanager那样不过换一个场景音乐就没了（
//然后又试了另一种方法，就是加了一个prefab


public delegate void AudioCallBack();
 
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
 
    public static AudioClip clipdata;
 
    public static AudioSource _audioSource;
    public GameObject bgm1_0 = null;
    public GameObject bgmprefab1_0;
 
    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        bgm1_0= GameObject.FindGameObjectWithTag("sound");
        bgmprefab1_0 = Resources.Load("Prefabs/1.0",typeof(GameObject)) as GameObject;
        if (Begin.go0 && bgm1_0 == null)
        {
            bgm1_0 = (GameObject)Instantiate(bgmprefab1_0);
        }
        //然后到了1.1音乐就停不下来了（
        // if(Begin.go1)
        // {
        //     Destroy(bgm1_0.GetComponent("DontDestroy"));
        //     Destroy(bgm1_0);
        // }
    }

    void update()
    {
        if(Begin.go1)
        {
            Destroy(bgm1_0.GetComponent("DontDestroy"));
            Destroy(bgm1_0);
        }
    }
    
    // 播放音频
    public static void AudioPlay(string name)
    {
        Debug.Log("audio");
        clipdata = Resources.Load<AudioClip>(name);
        _audioSource.clip = clipdata;
        _audioSource.Play();
    }
    
    // 暂停播放
    public static void AudioPause()
    {
        _audioSource.Pause();
    }
    
    // 暂停播放后继续播放
    public static void AudioUnPause()
    {
        _audioSource.UnPause();
    }
  
    // 停止播放
    public static void AudioStop()
    {
        _audioSource.Stop();
    }
    
    // 切换音频
    public static void AudioSwitch(string name)
    {
        AudioClip _clip = Resources.Load<AudioClip>(name);
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.clip = _clip;
        _audioSource.Play();
    }
}
