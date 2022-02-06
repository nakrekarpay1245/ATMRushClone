using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Car : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float moveSpeed;

    [SerializeField]
    private ParticleSystem explosion;

    private void Awake()
    {
        explosion = GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void CarStart()
    {
        moveSpeed = speed;
    }
    public void CarStop()
    {
        moveSpeed = 0;
    }

    public void Explosion()
    {
        explosion.Play();
    }
}
