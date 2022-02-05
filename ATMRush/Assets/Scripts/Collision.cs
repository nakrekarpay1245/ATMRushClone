using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            //Debug.Log("Collide Cube");
            if (!ATMRush.instance.cubes.Contains(other.gameObject))
            {
                //Debug.Log("Called SC");
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                ATMRush.instance.StackCube(other.gameObject, ATMRush.instance.cubes.Count - 1);                
            }
        }
    }
}
