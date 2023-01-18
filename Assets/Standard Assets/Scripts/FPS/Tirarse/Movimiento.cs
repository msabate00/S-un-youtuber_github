using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour
{
    //Desplazamiento en los ejes X y Z
    float movX;
    float movZ;
    //rotación en el eje vertical (el FPC sólo va a rotar sobre este eje)
    float rotY;
    Vector3 mov;
    //las velocidades de movimiento y rotación
    public float vel = 8.0f;
    public float velRot = 180.0f;
    Vector3 lastPosition = Vector3.zero;
    public static float velocidad;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(CalcVelocity());
        //  Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       
        movX = Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime;
        movZ = Input.GetAxisRaw("Vertical") * vel * Time.deltaTime;
        mov = new Vector3(movX, 0.0f, movZ);
        transform.Translate(mov);
       
    }

    IEnumerator CalcVelocity() //DETECTA LA VELOCIDAD DE MOVIMIENTO ES LA POLLA TIO
    {
        while (Application.isPlaying)
        {
            var prevPos = transform.position;
            yield return new WaitForEndOfFrame();
            var currVel = (prevPos - transform.position).magnitude / Time.deltaTime;
            Debug.Log(velocidad);
            velocidad = currVel;
        }
    }
}