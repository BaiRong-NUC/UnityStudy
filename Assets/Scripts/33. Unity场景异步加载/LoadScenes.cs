using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    void Start()
    {
        // 1. 线性加载场景
        // SceneManager.LoadScene("TestScene");
        // 线性加载场景的缺陷:Unity会删除场景上所有对象,当下一个场景对象过多,会导致卡顿现象

        // 2. 异步加载场景
        // 2.1 通过回调异步加载场景
        // SceneManager.LoadSceneAsync("TestScene").completed += (AsyncOperation obj) =>
        // {
        //     Debug.Log("场景加载完成");
        // };

        // 2.2 通过协程异步加载场景
        StartCoroutine(LoadSceneAsync("TestScene"));
        // 注意: 加载场景会把当前场景上没有处理的对象都删除了,所以协程中的部分逻辑可能不执行
        //      为了解决这个问题,可以在加载场景前将需要保留的对象标记为DontDestroyOnLoad
        DontDestroyOnLoad(gameObject);

        // 使用协程异步加载场景的好处:可以在加载过程中可以做一些处理,比如更新自定义进度条等
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOperation.isDone)
        {
            Debug.Log($"场景加载进度: {asyncOperation.progress}");
            yield return null;
        }
        Debug.Log("场景加载完成");

        // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        // yield return asyncOperation; // Unity会自动等待场景加载完成
        // Debug.Log("场景加载完成"); // 打印不出来,因为场景切换成功后这个场景的脚本被删除了需要标记为DontDestroyOnLoad
    }
}
