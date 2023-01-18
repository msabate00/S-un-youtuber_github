using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muevoalternativo : MonoBehaviour {

    public static float speed = 7.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public static float velocidad;
    public static bool movimientochingon;
    private Vector3 distanciador;

    void Start()
    {
       // StartCoroutine(CalcVelocity());
    }

    void Update()
    {

        // if (velocidad > 0.1f)
        //   {
        //       movimientochingon = true;
        //   }
        //  if (velocidad < 0.1f)
        //  {
        //      movimientochingon = false;
        //  }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            Vector3 moveDirectionForward = transform.forward * verticalInput * Time.deltaTime;
            Vector3 moveDirectionSide = transform.right * horizontalInput * Time.deltaTime;

            //find the direction
            Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
            //find the distance
            Vector3 distance = direction * speed * Time.deltaTime;
            distanciador = distance;
            controller.SimpleMove((moveDirectionForward + moveDirectionSide).normalized * speed);
        }
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
            
          //  controller.Move(distanciador);
        
      }

    IEnumerator CalcVelocity() //DETECTA LA VELOCIDAD DE MOVIMIENTO ES LA POLLA TIO
    {
        while (Application.isPlaying)
        {
            var prevPos = transform.position;
            yield return new WaitForEndOfFrame();
            var currVel = (prevPos - transform.position).magnitude / Time.deltaTime;
            velocidad = currVel;
        }
    }


}