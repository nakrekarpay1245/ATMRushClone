using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ATMRush : MonoBehaviour
{
    public static ATMRush instance;
    public List<GameObject> cubes;

    public float movementDelay = 0.25f;

    bool gameStop;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        if (!gameStop)
        {
            //Debug.LogWarning("ATM RUSH GAME NOT FİNİSH");
            if (Input.GetKey(KeyCode.Mouse0))
                MoveListElements(movementDelay);

            else
                MoveListElements(movementDelay / 2);
        }
    }
    public void StackCube(GameObject other, int index)
    {
        //Debug.Log("Stack Cube");

        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 2;
        other.transform.localPosition = newPos;
        cubes.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }

    public IEnumerator MakeObjectsBigger()
    {
        // Debug.Log("Make Objects Bigger");

        for (int i = cubes.Count - 1; i >= 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            cubes[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
             cubes[index].transform.DOScale(Vector3.one, 0.1f));
            yield return new WaitForSeconds(0.05f);

        }
    }

    public void MoveListElements(float delay)
    {
        //Debug.Log("Move List Elemnts");

        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, delay);
        }
    }

    public void GameStop()
    {
        //Debug.LogWarning("ATM RUSH GAME FİNİSH");
        gameStop = true;
    }
}
