using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mueveteenemigopruebagay : MonoBehaviour {

    public NavMeshAgent myNavMeshAgent;
    public Transform puta;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myNavMeshAgent.SetDestination(puta.position);
    }
}
