using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishAnimation : MonoBehaviour
{
    public static FinishAnimation instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void finishAnimation()
    {
        //Debug.LogWarning("FINISH ANIMATION GAME FİNİSH");

        Vector3 finishPos = transform.position;

        for (int i = ATMRush.instance.cubes.Count - 1; i >= 0; i--)
        {
            CameraMovement.instance.target = ATMRush.instance.cubes[0];
            CameraMovement.instance.transform.localRotation = Quaternion.Euler(-45,0,0);
            CameraMovement.instance.transform.DOLocalRotate(new Vector3(45, 0, 0), 2).OnComplete(()=>
            UserInterfaceManager.instance.FinishGame());
            ATMRush.instance.cubes[i].transform.DOMove(finishPos, 1);
            ATMRush.instance.cubes[i].transform.DOLocalRotate(new Vector3(0, 45, 0), 1);
            finishPos.y += 1;
            //Debug.Log("Finish Pos :  " + finishPos);
            //Debug.Log("Car Pos :  " + ATMRush.instance.cubes[i].transform.localPosition);
        }
    }
}
