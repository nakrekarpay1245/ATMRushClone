﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float followSpeed;

    [SerializeField]
    private float zOffset;

    [SerializeField]
    private float yOffset;

    public GameObject target;

    public static CameraMovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,
            target.transform.position.y + yOffset, target.transform.position.z + zOffset),
            followSpeed * Time.deltaTime);
    }

    public void CameraShake()
    {
        GetComponent<Animator>().SetTrigger("isCameraShake");
    }
}
