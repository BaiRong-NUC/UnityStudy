using System.Collections.Generic;
using UnityEngine;

public static class Tool
{
    // Transfor拓展方法,将子对象按照名字长短排序
    public static void Sort(this Transform obj)
    {
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < obj.childCount; i++)
        {
            list.Add(obj.GetChild(i));
        }
        list.Sort((left, right) =>
        {
            if (left.name.Length < right.name.Length)
            {
                //左小与右,不变
                return -1;
            }
            else
            {
                return 1;
            }
        });

        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetSiblingIndex(i);
        }
    }
    //为Trapform写一个拓展方法,传入一个名字查找子对象,即使是子对象的子对象也能查找到
    public static Transform FindIncludeChild(this Transform father, string childName)
    {
        Transform ret = null;
        ret = father.Find(childName);
        if (ret != null)
        {
            return ret;
        }

        //找自己的子对象
        for (int i = 0; i < father.childCount; i++)
        {
            ret = father.GetChild(i).FindIncludeChild(childName);
            if (ret != null)
            {
                break;
            }
        }
        return ret;
    }
}
