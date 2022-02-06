using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0;
    public float speed;
    public float swipeSpeed;

    public static Movement instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        GameObject firstCube = ATMRush.instance.cubes[0];
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("Left - Right Movement");
            float mouseX = Input.GetAxis("Mouse X");
            Vector3 swipePos = firstCube.transform.position;
            swipePos.x += mouseX * swipeSpeed * Time.deltaTime;
            firstCube.transform.position = swipePos;
        }
    }

    public void GameStart()
    {
        moveSpeed = speed;
    }

    public void GameStop()
    {
        moveSpeed = 0;
    }

    //firstCube.transform.localPosition = Vector3.MoveTowards(mousex);
}
