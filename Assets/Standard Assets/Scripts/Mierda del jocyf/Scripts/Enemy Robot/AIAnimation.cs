using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    [Tooltip("Velocidad minima para ver al enemigo correr en pantalla (con su animacion de corrr).")]
    public float minimumRunSpeed = 1f;
    [HideInInspector]
    public string gay;
    private Animator aiAnimation;
    private int AUTOBUS = 0; // ¿Vale cualquier tipo de transporte público? Autobús. Pero... ¡¡¡AUTOBÚÚÚÚS!!!

    void Start()
    {
        aiAnimation = gameObject.GetComponent<Animator>();

        // Poner todas las animaciones en Loop

        // El disparo no es Lopp, solo se ejecuta una vez.


        // Poner idle y Run en un layer menor. Sólo se animaran si las animaciones de accion no se estan viendo.
      
    }
    
    public float Durum(string a)
    {
        
            RuntimeAnimatorController ac = aiAnimation.runtimeAnimatorController;

            for (int i = 0; i < ac.animationClips.Length; i++)
            {
                if (ac.animationClips[i].name == a)
                    return ac.animationClips[i].length;

            }

        return 0;
    }

    public void transicionlol(string speed)
    {

        foreach (var param in aiAnimation.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                aiAnimation.ResetTrigger(param.name);
            }
        }

        aiAnimation.CrossFadeInFixedTime(speed, 0.17f, -1, 0, 0);      

    }

    public void transicionlol2(string speed, float speedeao)
    {

        foreach (var param in aiAnimation.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                aiAnimation.ResetTrigger(param.name);
            }
        }

        aiAnimation.CrossFadeInFixedTime(speed, speedeao, -1, 0, 0);

    }

    public void transicionlol3(string speed, float speedeao, int layer)
    {

        foreach (var param in aiAnimation.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                aiAnimation.ResetTrigger(param.name);
            }
        }

        aiAnimation.CrossFadeInFixedTime(speed, speedeao, layer, 0, 0);

    }

    public void SetSpeed2(string speed)
    {

        foreach (var param in aiAnimation.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                aiAnimation.ResetTrigger(param.name);
            }
        }

        aiAnimation.SetTrigger(speed);

    }

    public void SetSpeed(string speed)
    {
        gay = speed;

            foreach (var param in aiAnimation.parameters)
            {
                if (param.type == AnimatorControllerParameterType.Trigger)
                {
                  aiAnimation.ResetTrigger(param.name);
                }
            }    

        if (speed == "parao")
        {
            aiAnimation.SetTrigger("parese");
        }
       else if (speed == "apunta")
        {
            aiAnimation.SetTrigger("apuntar");
        }
        else if (speed == "camina")
        {
            aiAnimation.SetTrigger("caminar");
        }
        else if (speed == "caminapuntando")
        {
            aiAnimation.SetTrigger("acercarseapuntando");
        }
        else if (speed == "muereputa")
        {
            aiAnimation.SetTrigger("morir");
        }
        else if (speed == "correostia")
        {
            aiAnimation.SetTrigger("correr");
        }
        else if (speed == "aturdido")
        {
            aiAnimation.SetTrigger("stun");
        }
        else if (speed == "Pegame")
        {
            aiAnimation.SetTrigger("Pegame");
        }





        else if (speed == "golpeado") {
            int pene = Random.Range(1, 4);
            if (pene == 1)
            {
                if (pene != AUTOBUS)
                {
                    aiAnimation.SetTrigger("melee1");

                }
                if (pene == AUTOBUS)
                {
                    aiAnimation.SetTrigger("melee2");
                }
                AUTOBUS = 1;
            }
            if (pene == 2)
            {
                if (pene != AUTOBUS)
                {
                    aiAnimation.SetTrigger("melee2");
                }
                if (pene == AUTOBUS)
                {
                    aiAnimation.SetTrigger("melee3");
                }
                AUTOBUS = 2;
            }
            if (pene == 3)
            {
                if (pene != AUTOBUS)
                {
                    aiAnimation.SetTrigger("melee3");
                }
                if (pene == AUTOBUS)
                {
                    aiAnimation.SetTrigger("melee1");
                }
                AUTOBUS = 3;
            }

        }
    }

}