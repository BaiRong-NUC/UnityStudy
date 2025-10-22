using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneApi : MonoBehaviour
{
    private AudioClip audioClip;
    void Start()
    {
        // 1. 获取设备麦克风信息
        foreach (var device in Microphone.devices)
        {
            // 打印麦克风设备信息
            print("麦克风设备名称: " + device);
        }
    }

    void Update()
    {
        // 2. 录音
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 开始录音
            // 参数1：麦克风设备名称，null表示默认麦克风,可以传入设备名字符串
            // 参数2：是否循环录音
            // 参数3：录音时长，单位秒
            // 参数4：采样率，常用44100
            this.audioClip = Microphone.Start(null, false, 10, 44100);
            print("开始录音");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // 停止录音
            Microphone.End(null); // null表示默认麦克风
            print("停止录音");

            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = this.gameObject.AddComponent<AudioSource>();
            }
            audioSource.clip = this.audioClip;
            audioSource.Play();

            // 3. 获取音频数据用于存储或者传输
            float[] samples = new float[audioClip.samples * audioClip.channels]; // samples是音频的采样点数 * 通道数(规则)
            audioClip.GetData(samples, 0); //参数1：存储音频数据的数组 参数2：从第几个采样点开始获取一般为 0
        }
    } 
}
