using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Json序列使用的方法
public enum JsonType
{
    JsonUtility,
    LitJson,
}

// 将类的信息序列化为Json字符串,反序列化为类对象
public class JsonManage
{
    private static JsonManage _instance;
    public static JsonManage instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new JsonManage();
            }
            return _instance;
        }
    }
    private JsonManage() { }

    public string ToJson(object t, string saveFileName = "", JsonType jsonType = JsonType.LitJson)
    {
        string jsonStr = "";
        if (!string.IsNullOrEmpty(saveFileName))
        {
            string path = Application.persistentDataPath + "/" + saveFileName;
            switch (jsonType)
            {
                case JsonType.JsonUtility:
                    jsonStr = JsonUtility.ToJson(t);
                    break;
                case JsonType.LitJson:
                    jsonStr = LitJson.JsonMapper.ToJson(t);
                    break;
            }
            System.IO.File.WriteAllText(path, jsonStr);
        }
        return jsonStr;
    }

    public T FromJson<T>(string jsonStr = "", string loadFileName = "", JsonType jsonType = JsonType.LitJson)
    {
        if (!string.IsNullOrEmpty(loadFileName))
        {
            // 先判断默认数据文件夹是否有默认文件,没有再去持久化数据文件夹找
            string path = Application.streamingAssetsPath + "/" + loadFileName;
            if (!System.IO.File.Exists(path))
            {
                path = Application.persistentDataPath + "/" + loadFileName;
                if (!System.IO.File.Exists(path))
                {
                    Debug.LogError("加载Json文件失败,路径不存在:" + path);
                    return default(T);
                }
            }
            jsonStr = System.IO.File.ReadAllText(path);
        }
        T t = default(T);
        switch (jsonType)
        {
            case JsonType.JsonUtility:
                t = JsonUtility.FromJson<T>(jsonStr);
                break;
            case JsonType.LitJson:
                t = LitJson.JsonMapper.ToObject<T>(jsonStr);
                break;
        }
        return t;
    }
}
