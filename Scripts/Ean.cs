using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ean : MonoBehaviour
{
    public static void printGameObjectTransform(string name)
    {
        GameObject gameObject = GameObject.Find(name);
        Transform trans = gameObject.GetComponent<Transform>();
        Debug.Log("\n--------------Info-----------------------\n"
            + "GameObject : " + name + "\n"
            + "position: " + trans.position + "\n"
            +"rotation: " + trans.rotation + "\n"
            + "eulerAngles: " + trans.eulerAngles + "\n"
            + "scale: "+trans.localScale + "\n"
            + "--------------endInfo-------------------");
    }
}
