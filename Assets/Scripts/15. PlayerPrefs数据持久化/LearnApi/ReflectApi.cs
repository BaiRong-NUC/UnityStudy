using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Father
{
    public string name;
    public int age;

    public void Speak()
    {
        Debug.Log("Father Speak");
    }
}

public class Son : Father
{
    public int grade;

    public void Study()
    {
        Debug.Log("Son Study");
    }
}

public class ReflectApi : MonoBehaviour
{
    void Start()
    {
        // 1. 反射类型
        // Type: 获取类的所有信息 字段 属性 方法 等等
        // Assembly: 获取程序集 通过程序集获取Type
        // Activator: 用于快速实例化对象

        // 2. 判断一个类型的对象是否可以让另一个类型为自己分配空间
        // 父类装子类
        Type fatherType = typeof(Father);
        Type sonType = typeof(Son);

        // 是否可以让传入的类型为自己分配空间
        if (fatherType.IsAssignableFrom(sonType))
        {
            Debug.Log("Father can assign by Son");

            Father father = (Father)Activator.CreateInstance(sonType);
            print(father);
            father.Speak();
            //father.Study(); // 父类不能调用子类特有的方法
        }
        else
        {
            Debug.Log("Father can't assign by Son");
        }

        // 3. 通过反射获取泛型类型
        List<string> list = new List<string>();
        Type listType = list.GetType();
        Type[] genericArguments = listType.GetGenericArguments();
        foreach (Type arg in genericArguments)
        {
            Debug.Log("Generic argument: " + arg);
        }
    }
}
