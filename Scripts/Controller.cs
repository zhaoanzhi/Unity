using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    //GameObject gameObject = new GameObject();//这是最基的类
    //Object x= new Object();
    //EditorExtension editorExtension =new EditorExtension(); 没找到
    //Component component = null;
    //NamedObject x = null;
    // Start is called before the first frame update
    public static float speed = 6.0F;
    public static float jumpSpeed = 8.0F;
    public static float gravity = 20.0F;
    private static Vector3 moveDirection = Vector3.zero;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveLikeWow();
    }
    public void MoveLikeWow()
    {
        CharacterController controller = GetComponent<CharacterController>();
        //是否触碰地面
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        } 
        moveDirection.y -= gravity * Time.deltaTime;//模拟重力
        controller.Move(moveDirection * Time.deltaTime);//移动
        /*var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var point = Input.mousePosition- playerScreenPoint;
        var angle = Mathf.Atan2(point.x, point.y)*Mathf.Rad2Deg;*/
        GameObject camera = GameObject.Find("Main Camera");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, camera.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
