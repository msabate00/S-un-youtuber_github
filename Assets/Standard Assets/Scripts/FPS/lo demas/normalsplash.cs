using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalsplash : MonoBehaviour {
    public GameObject punto;
    private int paraostia = 0;
    public float distancia = 1;
    public float amplitud;
    public float longitud;
    public float vertical;
    private float vertical2;
    private Rigidbody rb;
    public GameObject yo;
    public GameObject yo2;

    void Start()
    {
        Destroy(yo2, 1);
        Destroy(gameObject, 1);
        vertical2 = vertical;
        vertical2 /= 2;
        float arriba = Random.Range(-vertical2, vertical);
        float derecha = Random.Range(-amplitud, amplitud);
        //yo.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * arriba);
        rb.AddForce(transform.right * derecha);
        rb.AddForce(transform.forward * longitud);
    }
    void Update (){
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
        {
            if (hit.collider.tag.Contains("pene")){
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                CrearDecall(hit);
          //      Debug.Log("Did Hit");
            }
            }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, distancia))
        {
            if (hit.collider.tag.Contains("pene"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
                CrearDecall(hit);
             //   Debug.Log("Did Hit");
            }
            }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, distancia))
        {
            if (hit.collider.tag.Contains("pene"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.green);
                CrearDecall(hit);
            //    Debug.Log("Did Hit");
            }
            }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, distancia))
        {
            if (hit.collider.tag.Contains("pene"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
                CrearDecall(hit);
              //  Debug.Log("Did Hit");
            }
            }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, distancia))
        {
            if (hit.collider.tag.Contains("pene"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.green);
                CrearDecall(hit);
               // Debug.Log("Did Hit");
            }
            }
    }

    // Update is called once per frame
    private void CrearDecall(RaycastHit hit)
    {
        if (paraostia < 1)
        {
            paraostia += 1;
            Vector3 pos = hit.point;
            Quaternion rotDecall = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject DecallObj = Instantiate(punto, pos, rotDecall);

            /**/
            /*Vector3 _posAux = DecallObj.transform.position;
            _posAux.y = DecallObj.transform.position.y + 0.1f;
            DecallObj.transform.position = _posAux;*/
            DecallObj.transform.position += DecallObj.transform.up * 0.03f;

          //  DecallObj.transform.parent = hit.transform;
        }
     }
}
