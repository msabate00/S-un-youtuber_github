using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulas : MonoBehaviour {

    public float radius = 5f;
    public float power = 100f;
    public float liftPower = 50f;
    public GameObject cosa;
    private ParticleSystem PSystem;
    private ParticleCollisionEvent[] CollisionEvents;
    Quaternion currentRotation;
    Quaternion rotagay;
    private bool vamos = false;
    private float pollas = 0;

    void Start()
    {
        CollisionEvents = new ParticleCollisionEvent[8];
        PSystem = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        
        //pollas += Time.deltaTime;
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "pene")
        {
            vamos = true;
         //   Debug.Log("LOOOL");
        }

            int collCount = PSystem.GetSafeCollisionEventSize();

        if (collCount > CollisionEvents.Length)
        {
            CollisionEvents = new ParticleCollisionEvent[collCount];
        }
        int eventCount = PSystem.GetCollisionEvents(other, CollisionEvents);

        for (int i = 0; i < eventCount; i++)
        {

            Vector3 collisionHitRot = CollisionEvents[i].normal;
         //   Debug.Log(collisionHitRot);
            currentRotation = Quaternion.Euler(collisionHitRot.x, collisionHitRot.y, collisionHitRot.z);
            Explosions(CollisionEvents[i].intersection);

            //TODO: Do your collision stuff here. 
            // You can access the CollisionEvent[i] to obtaion point of intersection, normals that kind of thing
            // You can simply use "other" GameObject to access it's rigidbody to apply force, or check if it implements a class that takes damage or whatever
        }
    }

    void Explosions(Vector3 intersection)
    {

        Vector3 explosionPos = intersection;
        
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        
            if (pollas <= 4)
            {
                
            if (vamos)
            {
                GameObject DecallObj = Instantiate(cosa, explosionPos, rotagay);
                DecallObj.transform.position -= DecallObj.transform.up * 0.17f;
                pollas += 1;
                vamos = false;
            }
            }
            
       
            foreach (Collider hit in colliders)
        {
            if (hit && hit.GetComponent<Rigidbody>())
            {
                //hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, liftPower);
            }
        }

        //GetComponent<AudioSource>().Play();

    }


    void spawncerda()
    {

    }

}