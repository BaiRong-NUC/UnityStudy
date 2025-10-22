using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStyle : MonoBehaviour
{
    public Texture2D mouseCursorTexture;
    void Start()
    {
        // 1. 隐藏鼠标
        // Cursor.visible = false;
        // 2. 锁定鼠标
        // Locked: 锁定鼠标在屏幕中央,并且隐藏鼠标
        // Confined: 将鼠标锁定在游戏窗口内,但可以移动
        // None: 取消鼠标锁定,可以自由移动
        // Cursor.lockState = CursorLockMode.Locked; //锁定鼠标在屏幕中央,并且隐藏鼠标
        Cursor.lockState = CursorLockMode.Confined; //将鼠标锁定在游戏窗口内,但可以移动

        // 3. 设置鼠标图片
        // 参数一: 鼠标图片,类型为Texture2D,图片Texture Type 设置为Cursor
        // 参数二: 鼠标偏移位置,类型为Vector2
        // 参数三: 鼠标光标模式,类型为CursorMode
        //         Auto: 自动选择硬件或软件模式
        //         ForceSoftware: 强制使用软件模式
        Cursor.SetCursor(this.mouseCursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
