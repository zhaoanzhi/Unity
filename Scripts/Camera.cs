using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
/*
    this module is used for the camera,in order to achive the 3-rd or 1-st Camera 
    3-rd:
        the camera is behand the player always.
    1-st:
        the camera is in front of the eye of the player.
    Controll:
        mouse X,Y -> turn left/right.
 */
public class camera : MonoBehaviour
{
    /*
        offset为第三人称的偏移值
     */
    [SerializeField] public int typeCamera;
    [SerializeField] public Vector3 offset;
    [SerializeField] public GameObject player;
    
    public float speedX = 200f;
    public float speedY = 200f;
    public float minRangeY = -60f;
    public float maxRangeY = 60f;
    public float distance = 10f;
    public float x, y;
    private Vector3 posPlayer;
    public float damping = 5.0f;
    public bool needDamping = true;
    void Start()
    {
        init();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (typeCamera == 1) Work_1();
        if (typeCamera == 3) Work_3();
    }

    static float ClamAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
    void Work_1()
    {

    }
    void Work_3()
    {
        if (player.transform)
        {
            //button values are 0 for left button, 1 for right button, 2 for the middle button.
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * speedX * 0.02f;
                y -= Input.GetAxis("Mouse Y") * speedY * 0.02f;
                y = ClamAngle(y, minRangeY, maxRangeY);
            }
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            Vector3 dis = new Vector3(0.0f, 0.0f, -distance);
            Vector3 pos = rotation* dis+player.transform.position;
            if (needDamping)
            {
                //Linearly interpolates between a and b by t.
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * damping);
            }
            else
            {
                transform.rotation = rotation;
                transform.position = pos;
            }
        }
    }
    void init()
    {
        Vector3 angle = transform.eulerAngles;
        x = angle.y;
        y = angle.x;
        posPlayer = player.transform.position;
    }
}
