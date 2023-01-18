using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{

    public GameObject Prefab;

    [Tooltip("El placeHolder debe de estar puesto en el mapa, asi se recoge las coordenados donde spawneara")]
    public Transform placeHolder;
    public float timeToSpawn;

    private Vector3 coords;
    private Quaternion rotation;
    private float contador;
    

    // Start is called before the first frame update
    void Start()
    {
        coords = new Vector3(placeHolder.position.x, placeHolder.position.y, placeHolder.position.z);
        rotation = placeHolder.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (!placeHolder || placeHolder.GetComponent<ManageEnemyStatus1>().health <= 0)
        {
            contador += Time.deltaTime;
            if (contador >= timeToSpawn) {
                placeHolder = Instantiate(Prefab, coords, rotation).transform;
                contador = 0; 
            }

        }
        else {
            contador = 0;
        }

        
    }
}
