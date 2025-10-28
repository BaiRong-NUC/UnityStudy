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
            else
            {
                Debug.Log("加载到的其他资源:" + obj.name);
            }
        }

        // ==========资源异步加载==========
        // 若资源过大,使用上面的同步加载方式会导致卡顿(加载到内存),可以使用异步加载方式
        // 异步加载需要等待资源加载完毕才可以使用

        // 1. 使用异步加载完成事件监听使用加载资源
        Resources.LoadAsync<AudioClip>("Musics/BKMusic").completed += (AsyncOperation op) =>
        {
            // assert是资源对象,加载完成后,就可以正常使用
            AudioClip asyncBgMusic = (op as ResourceRequest).asset as AudioClip;
            Debug.Log("异步加载到的音频资源:" + asyncBgMusic.name);
        };

        // 2. 使用协程加载资源
        StartCoroutine(LoadAudioCoroutine());

        // 事件监听异步加载:只能在资源加载结束后进行处理
        // 协程异步加载:可以在等待过程中做其他操作,如进度条显示

        // ==========资源卸载==========
        // Resources加载一次的资源过后,该资源会在内存中作为缓存,第二次重复加载时,会直接使用内存中的缓存资源,提高效率
        // 若某个资源长时间不使用,需要卸载所有未使用的资源,释放内存
        // 1. 卸载指定资源
        Resources.UnloadAsset(bgMusic); // 卸载指定资源,不能用于释放GameObject预设体资源

        // 2. 卸载所有未使用的资源
        Resources.UnloadUnusedAssets(); // 卸载所有未使用的资源,一般在过场景中,和垃圾回收一起使用,可能会导致卡顿
        System.GC.Collect(); // 强制进行垃圾回收,释放内存
    }
    
    IEnumerator LoadAudioCoroutine()
    {
        ResourceRequest request = Resources.LoadAsync<AudioClip>("Musics/BKMusic");
        // 等待加载完成
        yield return request; // Unity会自动检测request的完成状态,未完成则等待
        AudioClip asyncBgMusic = request.asset as AudioClip;
        Debug.Log("协程异步加载到的音频资源:" + asyncBgMusic.name);

        // // 方法二: 判断资源是否加载完毕
        // while(!request.isDone)
        // {
        //     Debug.Log("协程加载进度:" + request.progress);
        //     yield return null; // 等待下一帧
        // }
    }

    private void OnGUI()
    {
        if (this.texture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.texture);
        }
    }
}
