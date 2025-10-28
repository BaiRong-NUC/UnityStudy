using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAPI : MonoBehaviour
{
    public AudioSource audioSource;

    // 图片资源
    private Texture texture;
    void Start()
    {
        // 1. Resources动态加载:通过代码加载Resources文件夹下的资源,避免拖动的繁琐操作

        // 2. 常用资源类型
        //    2.1 预设体对象: GameObject,加载需要实例化
        //    2.2 音效文件: AudioClip
        //    2.3 文本文件: TextAsset
        //    2.5 图片文件: Texture

        // 3. 资源同步加载,一个项目的Resources文件夹可以有多个,打包时Unity会整合到一起
        // 加载预设体资源文件
        GameObject cubeObject = Resources.Load("Cube") as GameObject;
        // 实例化预设体
        GameObject instantiatedCube = GameObject.Instantiate(cubeObject);
        instantiatedCube.transform.localPosition = new Vector3(2, 0, 0);

        // 音效文件
        AudioClip bgMusic = Resources.Load<AudioClip>("Musics/BKMusic");
        this.audioSource.clip = bgMusic;
        this.audioSource.Play();

        // 4. 文本资源 .txt .json .bytes .xml .csv .html等格式
        TextAsset textAsset = Resources.Load<TextAsset>("Texts/Test"); //不需要写文件后缀
        Debug.Log("TextAsset文本内容:" + textAsset.text);

        // 5. 图片资源 Texture
        this.texture = Resources.Load<Texture>("Textures/Background");

        // 6. 指定类型加载资源
        this.texture = Resources.Load("Textures/Background", typeof(Texture)) as Texture;

        // 7. 加载指定文件夹下特定类型的资源
        Object[] textures = Resources.LoadAll("Textures", typeof(Texture));
        foreach (Object obj in textures)
        {
            Debug.Log("加载到的图片资源:" + obj.name);
        }

        // 8. 加载文件夹下的所有资源
        Object[] allObjects = Resources.LoadAll("Musics");
        foreach (Object obj in allObjects)
        {
            if (obj is AudioClip)
            {
                Debug.Log("加载到的音频资源:" + obj.name);
            }
            else{
                Debug.Log("加载到的其他资源:" + obj.name);
            }
        }
    }


    private void OnGUI()
    {
        if (this.texture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.texture);
        }
    }
}
