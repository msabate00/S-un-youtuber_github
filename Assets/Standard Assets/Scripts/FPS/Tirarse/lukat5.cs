using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lukat5 : MonoBehaviour
{

    public Transform target;
    public float speed = 1f;

    int randomTarget;
    Quaternion newRot;
    Vector3 relPos;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("TargetEnemy").transform;
        }
        else
        {
            relPos = target.position - transform.position;
            newRot = Quaternion.LookRotation(relPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.P))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

    }

    void GetNewTarget()
    {
        GameObject[] possibleTargets;
        possibleTargets = GameObject.FindGameObjectsWithTag("ball");
        if (possibleTargets.Length > 0)
        {
            randomTarget = Random.Range(0, possibleTargets.Length);
            target = possibleTargets[randomTarget].transform;
        }
    }
}