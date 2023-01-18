using UnityEngine;

public class FPCSoundMngr : MonoBehaviour
{
    [System.Serializable]
    public class StepSounds
    {
        public AudioClip FPCSound;
        public float interval = 0.5f;
    }
    public StepSounds walkSound;
    public StepSounds runSound;
    public StepSounds jumpSound;

    private AudioSource footAudioSource;
    

    private CharacterController cc;
    private CharacterMotor cm;
    private float PlayTime;
    private bool JumpPlayed;

    private bool wasRunning = false;


    void Start()
    {
        GameObject MyFPC = GameObject.Find("First Person Controller");
        cc = MyFPC.GetComponent<CharacterController>();
        cm = MyFPC.GetComponent<CharacterMotor>();
        footAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time < 0.5f) { return; } // Sentecia de seguridad


        // Paramos los sonidos de andar si no se mueve el FPC
        if (Mathf.Approximately(cc.velocity.magnitude, 0))
        {
            if (footAudioSource.isPlaying)
            {
                footAudioSource.Stop();
            }

            JumpPlayed = false;
            return;
        }

        // Si esta en el aire, reproducir el salto una sola vez.
        if (!cm.grounded)
        {
            if (!JumpPlayed)
            {
                footAudioSource.PlayOneShot(jumpSound.FPCSound);
                JumpPlayed = true;
            }
        }
        else // Si NO esta en el aire, reproducir los pasos.
        {
             
            if(wasRunning != FPCStatus.isRunning && cc.velocity.magnitude > 0)
            {
                PlayTime = Time.time;
                footAudioSource.Stop();
                wasRunning = FPCStatus.isRunning;
            }

            if (Time.time > PlayTime)
            {
                if (cc.velocity.magnitude > 0)
                {
                    footAudioSource.PlayOneShot(walkSound.FPCSound);

                    // Calculamos cuando tocaremos el sonido de la siguiente pisada.
                    float timeToAdd = FPCStatus.isRunning ? runSound.interval : walkSound.interval;
                    PlayTime = Time.time + timeToAdd;

                    // Me aseguro de quitar el flag de que hemos reproducido el sonido de salto
                    if (JumpPlayed)
                    {
                        JumpPlayed = false;
                    }
                }
            }
        }
    }

}


/*
 
    if (Time.time > PlayTime)
            {
                if (cc.velocity.magnitude > 0)
                {
                    //footAudioSource.Stop();
                    footAudioSource.PlayOneShot(FPCSounds[0]);

                    // Calculamos cuando tocaremos el sonido de la siguiente pisada.
                    float timeToAdd = (cc.velocity.magnitude < 6) ? FPCSounds[0].length : FPCSounds[0].length * 0.5f;

                    PlayTime += timeToAdd;

                    // Me aseguro de quitar el flag de que hemos reproducido el sonido de salto
                    if (JumpPlayed)
                    {
                        JumpPlayed = false;
                    }
                }
            }*/