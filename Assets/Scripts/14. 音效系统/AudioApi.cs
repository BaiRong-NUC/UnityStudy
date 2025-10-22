using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioApi : MonoBehaviour
{
    // AudioSource 组件的API
    AudioSource audioSource;

    public AudioClip audioClip;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        // 3. 动态控制音效播放
        //    - 直接在要播放音效的对象上挂在脚本 控制播放
        //    - 实例化挂载了音效源脚本的对象
        //    - 用一个AudioSource来播放不同的音效
        audioSource.clip = audioClip; // 指定要播放的音频
        audioSource.Play(); // 播放音频
    }

    void Update()
    {
        // 1. 代码控制播放停止
        if (this.audioSource == null)
        {
            print("请先添加AudioSource组件");
            return;
        }
        // 按下A键播放音频，按下S键暂停音频，按下D键停止音频
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.Play();
            // audioSource.PlayDelayed(2); // 延迟2秒播放
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            audioSource.Pause();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            audioSource.Stop();
        }

        // 2. 判断音频播放完毕,需要不停检测这个属性,来判断音效是否播放完毕
        if (audioSource.isPlaying == true)
        {
            print("音频正在播放");
        }
        else
        {
            print("音频播放完毕");
        }
    }
}
