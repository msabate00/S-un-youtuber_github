using UnityEngine;

public class CrouchVariable : MonoBehaviour
{
    public float CrouchHeight = 0.5f;
    public float CrouchVelocity = 0.05f;
    private bool isCrouching = false;
    public float walkSpeed = 2f;
    public Vector2 bobbingAmount = new Vector2(0.1f, 0.05f);
    public float Radiuus = 0.32f;

    private CharacterController controller;
    private CharacterMotor walker;
    private HeadbobberGun HeadUp;
    private float OriginalHeight;
    private float Originalradius;
    private Vector3 OriginalPosition = Vector3.zero;
    private float walkerwalkSpeed;
    private float Original;
    private Vector2 OrigHeadUpAmount = Vector3.zero;
    private float OrigHeadUpSpeed;
    private Muevo mov;

    void Start()
    {
        mov = gameObject.GetComponent<Muevo>();
        controller = GetComponent<CharacterController>();
        walker = GetComponent<CharacterMotor>();
        HeadUp = GetComponentInChildren<HeadbobberGun>();
        Original = mov.speed;
        Originalradius = controller.radius;
        OriginalHeight = controller.height;
        OriginalPosition = transform.position;
        walkerwalkSpeed = walker.movement.maxForwardSpeed;
        OrigHeadUpSpeed = HeadUp.bobbingSpeed;
        OrigHeadUpAmount = HeadUp.bobbingAmount;
    }

    void Update()
    {
        if (HeadUp == null)
        {
           // HeadUp = GetComponentInChildren<HeadbobberGun>();
        }
        if (Input.GetButton("Crouch"))
        {
            if (controller.height > CrouchHeight)
            {
                FPCStatus.isCrouched = false;
            }
            if (!FPCStatus.isRunning)
            {
                if (!FPCStatus.isCrouched)
                {
                    UpdateWalkerParameters(walkSpeed);
                    UpdateBobbingParameters(bobbingAmount, OrigHeadUpSpeed * 0.5f);
                    if (controller.radius > Radiuus)
                    {
                     //   controller.radius = controller.radius - (CrouchVelocity * Time.deltaTime * 0.5f);
                    }
                    if (controller.height > CrouchHeight)
                    {
                        controller.height = controller.height - (CrouchVelocity * Time.deltaTime);
                        isCrouching = true;
                    }
                    if (controller.radius < Radiuus)
                    {
                        controller.radius = Radiuus;
                    }
                    else if (controller.height < CrouchHeight)
                    {
                        controller.height = CrouchHeight;
                        FPCStatus.isCrouched = true;
                        isCrouching = false;
                    }
                }
            }
        }
        else
        {
            if (FPCStatus.isCrouched || isCrouching)
            {
                UpdateWalkerParameters(Original);
                if (controller.radius < Originalradius)
                {
                    controller.radius = controller.radius + (CrouchVelocity * Time.deltaTime * 0.22f);
                }
                if (controller.radius > Originalradius)
                {
                    controller.radius = Originalradius;
                }
                if (controller.height < OriginalHeight)
                {
                    controller.height = controller.height + (CrouchVelocity * Time.deltaTime);
                    Vector3 _posAux = transform.position;
                    _posAux.y += CrouchVelocity * Time.deltaTime * 2;
                    transform.position = _posAux;
                }
                else
                {
                    controller.height = OriginalHeight;
                    UpdateWalkerParameters(Original);
                    UpdateBobbingParameters(OrigHeadUpAmount, OrigHeadUpSpeed);

                    FPCStatus.isCrouched = false;
                    isCrouching = false;
                }
            }
        }
        
     }

    private void UpdateWalkerParameters(float _velo)
    {
        mov.speed = _velo;
        walker.movement.maxForwardSpeed = _velo;
        walker.movement.maxSidewaysSpeed = _velo;
        walker.movement.maxBackwardsSpeed = _velo;
    }

    private void UpdateBobbingParameters(Vector2 _amount, float _speed)
    {
     //   HeadUp.bobbingAmount = _amount;
     //   HeadUp.bobbingSpeed = _speed;
    }

}