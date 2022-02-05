using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float swipeSpeed;

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

    //firstCube.transform.localPosition = Vector3.MoveTowards(mousex);
}
