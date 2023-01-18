using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palraycastbarra : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var layerMask = (1 << 2);
        layerMask |= (1 << 14);
        layerMask |= (1 << 17);
        layerMask = ~layerMask;
        RaycastHit hit = default(RaycastHit);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000, layerMask))

        {
            ManageEnemyStatus target = hit.transform.GetComponent<ManageEnemyStatus>();
            critico target2 = hit.transform.GetComponent<critico>();
            if (target != null)
            {
                // target.activao = Time.time + target.tiempodesaparace;
                target.SendMessage("tiempobarra");
            }

            if (target2 != null)
            {
                target2.SendMessage("tiempobarra");
            }
        }
    }
}
