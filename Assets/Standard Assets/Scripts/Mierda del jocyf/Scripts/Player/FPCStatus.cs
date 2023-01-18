using UnityEngine;

public class FPCStatus : MonoBehaviour
{
    public static bool isNormal; // es normal cuando no esta saltando ni agachado.
    public static bool isShooting; // Esta disparando.
    public static bool isShooting2;
    public static bool isReloading; // Esta recargando el arma-
    public static bool isRunning;
    public static bool IsJumping;
    public static bool isCrouched;
    public static bool IsAiming;
    public static bool isNormalAntFrame;
    public static bool isShootingAntFrame;
    public static bool isRunningAntFrame;
    public static bool IsJumpingAntFrame;
    public static bool isCrouchedAntFrame;
    public static bool IsAimingAntFrame;
    public static bool IsFire1Down;
    public static bool IsFire1Pressed;
    public static bool IsFire1Up;
    public static bool IsFire2Down;
    public static bool IsFire2Pressed;
    public static bool IsFire2Up;
    public static bool IsAxisXActive;
    public static float AxisXValue;
    public static bool IsAxisYActive;
    public static float AxisYValue;
    public static bool haybalas;
    public static bool transicion;
    public static bool maximoratgay;
    public static bool melee = false;
    public static bool accionando = false;
    public static Vector3 movimiento;
    public static bool especial = false;
    public static bool dual = false;
    public static bool cambioarma = false;

    private CharacterMotor walker;


    public void DamagePlayer(int damage)
    {
        GameMngr.Instance.nSalud -= damage;
        if (GameMngr.Instance.nSalud <= 0)
        {
            GameMngr.Instance.LoadGameOverScene();
        }
    }

    void OnEnable()
    {
        walker = GetComponent<CharacterMotor>();
    }

    void Update()
    {
        // Comprobar los valores para igualar el frame anterior al principio de este nuevo frame.
        isNormalAntFrame = isNormal;
        isShootingAntFrame = isShooting;
        /*isRunningAntFrame = isRunning;
	    IsJumpingAntFrame = IsJumping;*/
        isCrouchedAntFrame = isCrouched;
        IsAimingAntFrame = IsAiming;
        isNormal = false;


        if (!IsJumping && !isRunning)
        {
            isNormal = true;
        }

        if (!walker.grounded && walker.jumping != null && !IsAiming)
        {
           // IsJumping = true; Lo he kitao yo jej soi un troll
        }
        else
        {
            IsJumping = false;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            IsFire1Down = true;
            IsFire1Pressed = true;
            IsFire1Up = false;
        }
        else if (Input.GetButton("Fire1"))
        {
            IsFire1Down = false;
            IsFire1Pressed = true;
            IsFire1Up = false;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            IsFire1Down = false;
            IsFire1Pressed = false;
            IsFire1Up = true;
        }
        else
        {
            IsFire1Down = false;
            IsFire1Pressed = false;
            IsFire1Up = false;
        }


        if (Input.GetButtonDown("Fire2"))
        {
            IsFire2Down = true;
            IsFire2Pressed = true;
            IsFire2Up = false;
        }
        else if (Input.GetButton("Fire2"))
        {
            IsFire2Down = false;
            IsFire2Pressed = true;
            IsFire2Up = false;
        }
        else  if (Input.GetButtonUp("Fire2"))
        {
            IsFire2Down = false;
            IsFire2Pressed = false;
            IsFire2Up = true;
        }
        else
        {
            IsFire2Down = false;
            IsFire2Pressed = false;
            IsFire2Up = false;
        }


        AxisXValue = Input.GetAxis("Mouse X");
        AxisYValue = Input.GetAxis("Mouse Y");

        IsAxisXActive = (AxisXValue != 0);
        IsAxisYActive = (AxisYValue != 0);

        /*if (AxisXValue == 0)
        {
            IsAxisXActive = false;
        }
        else
        {
            IsAxisXActive = true;
        }

        if (AxisYValue == 0)
        {
            IsAxisYActive = false;
        }
        else
        {
            IsAxisYActive = true;
        }*/
    }

}