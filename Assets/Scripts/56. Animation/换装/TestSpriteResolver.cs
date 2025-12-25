using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class TestSpriteResolver : MonoBehaviour
{
    // public SpriteResolver spriteResolver;
    Dictionary<string, SpriteResolver> spriteResolvers = new Dictionary<string, SpriteResolver>();
    void Start()
    {
        // 1. 在同一个文件下的换装
        /**
            在PS制作美术资源时,将一个游戏对象所有的换装资源拜访好位置
            在导入资源时,要注意是否导入隐藏的图层
        */
        // 2. 编辑换装资源的骨骼信息以及分组类别,需要修改每张图片绑定的骨骼
        /**
            将同一种类的装备分成一组,方便后续通过代码进行换装
            Visvable-> Category: 设置类别
            注意: 每个部位关联的骨骼需要明确设置,为同一部位不同装备设置相同的分组

            分组完成后拖入到场景中,Unity会自动添加SpriteLibrary组件,记录分组信息

            SpriteResolver组件: 也会自动添加到和分类名相同的节点上,确定部位类别与使用的图片
        */
        // 3. 通过代码进行换装
        /**
            (1). 获取各部位的SpriteResolver组件
            (2). 通过GetCategory()获取默认类别名,SetCategoryAndLabel()方法进行换装
        */

        SpriteResolver[] resolvers = this.GetComponentsInChildren<SpriteResolver>();
        foreach (var resolver in resolvers)
        {
            spriteResolvers[resolver.GetCategory()] = resolver;
        }
    }

    void ChangeEquipment(string category, string label)
    {
        if (!spriteResolvers.ContainsKey(category))
        {
            Debug.LogWarning("不存在该类别: " + category);
            return;
        }
        spriteResolvers[category].SetCategoryAndLabel(category, label);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeEquipment("Hat", "CASK 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeEquipment("Hat", "CASK 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeEquipment("Hat", "CASK 3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeEquipment("Hat", "CASK 4");
        }
    }
}
