using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContral : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    void Start()
    {
        // 1. 角色控制器是让角色可以受制与碰撞,但是不会被刚体牵引
        // eg: 加刚体后物体可能会被撞飞等

        // 2. 注意:
        // - 添加角色控制器后不需要添加刚体组件
        // - 可以检测碰撞器,触发器,射线检测

        // 3. CharacterController常用属性
        // - Slope Limit: 角色能攀爬的最大坡度,超过这个坡度的地形角色将无法攀爬
        // - Step Offset: 角色能跨越的最大台阶高度
        // - Skin Width: 两个碰撞体可以穿透的最大距离,防止角色卡在墙体中,一般为半径radius的1/10
        // - Min Move Distance: 角色每次移动的最小距离,防止角色抖动,一般不修改

        // 4. API
        this.characterController = this.GetComponent<CharacterController>();
        this.animator = this.GetComponent<Animator>();
        // - 是否接触到地面
        Debug.Log(this.characterController.isGrounded);
        // - 受重力作用的移动
        // this.characterController.SimpleMove(Vector3.forward * Time.deltaTime * 5);
        // - 不受重力作用的移动,移动后如果悬空不会下坠
        // this.characterController.Move(Vector3.forward * Time.deltaTime * 5);
    }

    void Update()
    {
        this.animator.SetInteger("Speed", (int)Input.GetAxisRaw("Vertical"));
        this.characterController.SimpleMove(100 * this.transform.forward * Time.deltaTime * 5 * Input.GetAxisRaw("Vertical"));
        // 按Q旋转
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(Vector3.up, -100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(Vector3.up, 100 * Time.deltaTime);
        }

        if (this.characterController.isGrounded)
        {
            Debug.Log("接触地面");
        }
    }

    // 角色控制器碰撞检测
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit.collider.gameObject.name);
    }

    // 当碰撞的是触发器时使用
    private void OnTriggerEnter(Collider other)
    {
        print("进入触发器:" + other.gameObject.name);
    }
}
