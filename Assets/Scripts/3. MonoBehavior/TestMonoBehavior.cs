using UnityEngine;

public class TestMonoBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // this代表这个脚本对象
        // this.gameObject代表这个脚本挂在的物体
        // this.transform代表这个脚本挂的物体的位置信息
        // 获取依附的GameObject
        print(this.gameObject.name);
        // 获取依附的GameObject位置,角度信息
        print(this.transform.position);
        print(this.transform.eulerAngles);
        print(this.transform.lossyScale);
        // this.transform = this.gameObject.transform

        // 获取脚本是否激活
        this.enabled = true;

        // 获取其他脚本
        // Edit edit = this.GetComponent("Edit") as Edit;
        // Edit edit = this.GetComponent(typeof(Edit)) as Edit;
        Edit edit = this.GetComponent<Edit>();
        if (edit != null)
        {
            print(edit);
        }

        Edit[] edits = this.GetComponents<Edit>();
        print(edits.Length);

        // 获取子节点下挂的脚本,默认会从自己的节点上查找,true代表查询未激活的组件,只要是后代都会查找
        edit = this.GetComponentInChildren<Edit>(true);
        edits = this.GetComponentsInChildren<Edit>(true);
        print(edits.Length);

        // 获取父对象挂载的脚本,默认会从自己的节点上查找,只要层级比本节点高都会查找
        edit = this.GetComponentInParent<Edit>();
        edits = this.GetComponentsInParent<Edit>();
        print(edits.Length);

        //尝试获取脚本 
        if (this.TryGetComponent<Edit>(out edit))
        {
            print("本物体节点有 Edit脚本 ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
