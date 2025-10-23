using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoordinates : MonoBehaviour
{
    /**
    1. 世界坐标系
    世界坐标系是Unity中所有物体的参考坐标系
    2. 物体坐标系
    物体中心点(建模时决定)
    一般:前:Z+, 后:Z-, 上:Y+, 下:Y-, 右:X+, 左:X-
    3. 屏幕坐标系
    原点:屏幕左下角,向右为X+,向上为Y+ 右上角:(屏幕宽度,屏幕高度)
    4. 视口坐标系
    原点:视口左下角,向右为X+,向上为Y+ 右上角:(1,1)
    */

    void Start()
    {
        // 1. 世界坐标系 相对世界坐标系
        print("World Position: " + this.transform.position);
        print("World Rotation: " + this.transform.rotation);
        print("World Scale: " + this.transform.lossyScale);
        print("World eulerAngles: " + this.transform.eulerAngles);

        // 2. 物体坐标系 相对父对象的坐标系的位置 本地坐标 相对坐标
        print("Local Position: " + this.transform.localPosition);
        print("Local Rotation: " + this.transform.localRotation);
        print("Local Scale: " + this.transform.localScale);
        print("Local eulerAngles: " + this.transform.localEulerAngles);

        // 3. 屏幕坐标系
        print("Input Mouse Position: " + Input.mousePosition);
        print("Screen Width: " + Screen.width + ", Height: " + Screen.height);

        // 4. 视口坐标系

        // 坐标转化
        // 1. 世界坐标系 <-> 物体坐标系
        Vector3 worldToLocal = this.transform.InverseTransformPoint(this.transform.position);
        Vector3 localToWorld = this.transform.TransformPoint(worldToLocal);
        print("World to Local: " + worldToLocal);
        print("Local to World: " + localToWorld);
        // 2. 世界坐标系 <-> 屏幕坐标系
        Vector3 worldToScreen = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(worldToScreen);
        print("World to Screen: " + worldToScreen);
        print("Screen to World: " + screenToWorld);
        // 3. 世界坐标系 <-> 视口坐标系
        Vector3 worldToViewport = Camera.main.WorldToViewportPoint(this.transform.position);
        Vector3 viewportToWorld = Camera.main.ViewportToWorldPoint(worldToViewport);
        print("World to Viewport: " + worldToViewport);
        print("Viewport to World: " + viewportToWorld);
        // 4. 屏幕坐标系 <-> 视口坐标系
        Vector3 screenToViewport = Camera.main.ScreenToViewportPoint(worldToScreen);
        Vector3 viewportToScreen = Camera.main.ViewportToScreenPoint(screenToViewport);
        print("Screen to Viewport: " + screenToViewport);
        print("Viewport to Screen: " + viewportToScreen);
    }
}
