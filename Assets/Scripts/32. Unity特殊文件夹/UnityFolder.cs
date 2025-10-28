using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFolder : MonoBehaviour
{
    void Start()
    {
        // 1. 工程路径获取
        print("工程路径: " + Application.dataPath); // 一般在编辑模式下使用,游戏发布后该路径不存在

        // 2. Resources文件夹: 一般不获取,只能使用Resources相关API加载,需要自己创建
        // 作用:
        // 2.1 需要通过Resources相关API加载的资源必须放在Resources文件夹下
        // 2.2 Resources文件夹下的资源会被打包进最终的游戏包体中
        // 2.3 打包时Unity会对其压缩加密
        // 2.4 该文件打包后只读 只能通过Resources相关API加载

        // 3. StreamingAssets文件夹: 一般不获取,需要自己创建
        print("StreamingAssets路径: " + Application.streamingAssetsPath);
        // 作用:
        // 3.1 打包后不会被加密
        // 3.2 移动平台只读,PC平台可读写
        // 3.3 适合存放一些自定义动态加载的文件

        // 4. persistentData文件夹: 一般用于存储游戏运行时产生的数据,不需要手动创建
        print("persistentData路径: " + Application.persistentDataPath);
        // 作用:
        // 4.1 该路径在各个平台都是读写的
        // 4.2 适合存放游戏动态下载或者动态创建的文件,游戏中创建或者获取的文件都放在其中

        // 5. Plugins文件夹: 一般不获取,需要自己创建
        // 作用:
        // 5.1 不同平台的插件相关文件放在其中,IOS和Android平台的原生插件放在其中

        // 6. Editor文件夹: 一般不获取,需要自己创建
        // 作用:
        // 6.1 开发Unity编辑器时,编辑器相关脚本放在该文件夹中
        // 6.2 该文件夹中的内容不会被打包出去

        // 7. Standard Assets文件夹: 一般不获取,需要自己创建,
        // Unity自带的标准资源包放在其中,会被优先编译
    }
}
