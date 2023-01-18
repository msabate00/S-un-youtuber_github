using UnityEngine;

public class RunVariable : MonoBehaviour
{
    public float runSpeed = 2f;
    public float guenorunSpeed = 2f;

    private CharacterMotor walker;
    private HeadbobberGun HeadUp;
    private float walkerwalkSpeed;
    private float OrigHeadUpSpeed;
    private float original;
    private bool lol = false;
    private bool activao = false;
    private Muevo mov;

    public void ActivarArma()
    {
        HeadUp = (HeadbobberGun)gameObject.GetComponentInChildren(typeof(HeadbobberGun));
        OrigHeadUpSpeed = HeadUp.bobbingSpeed;
        activao = false; 
    }

    void Start()
    {
        mov = gameObject.GetComponent<Muevo>();
        original = mov.speed;
        walker = (CharacterMotor) GetComponent(typeof(CharacterMotor));
        walkerwalkSpeed = walker.movement.maxForwardSpeed;
        HeadUp = (HeadbobberGun) gameObject.GetComponentInChildren(typeof(HeadbobberGun));
        OrigHeadUpSpeed = HeadUp.bobbingSpeed;
    }

    void Update()
    {
        //        Debug.Log(HeadbobberGun.vertigay2);
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical == 0)
        {
            lol = false;
        }
        else
        if (vertical == 1)
        {
            lol = true;
        }
            if (Input.GetButton("Run") && !activao && !FPCStatus.isCrouched && !FPCStatus.IsAiming && lol)
        {
            mov.speed = guenorunSpeed;
            UpdateWalkerParameters(runSpeed);
            HeadUp.bobbingSpeed = HeadUp.bobbingRunSpeed;

            FPCStatus.isRunning = true;
            FPCStatus.isRunningAntFrame = false;
            activao = true;
        }
        else if (!lol && FPCStatus.isRunning)
        {
            mov.speed = original;
            float walkAux = FPCStatus.isCrouched ? 2 : walkerwalkSpeed;
            UpdateWalkerParameters(walkAux);
            HeadUp.bobbingSpeed = OrigHeadUpSpeed;

            FPCStatus.isRunning = false;
            FPCStatus.isRunningAntFrame = true;
            activao = false;
        }
    }

    private void UpdateWalkerParameters(float _velo)
    {
        walker.movement.maxForwardSpeed = _velo;
        walker.movement.maxSidewaysSpeed = _velo;
        walker.movement.maxBackwardsSpeed = _velo;
    }
}