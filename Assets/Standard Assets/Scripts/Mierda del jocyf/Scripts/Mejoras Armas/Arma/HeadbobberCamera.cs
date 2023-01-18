using UnityEngine;

public enum Axis
{
    X = 0,
    Y = 1,
    XY = 2
}

public class HeadbobberCamera : MonoBehaviour
{
    public Axis AxisMov = Axis.X;
    public float bobbingSpeed = 0.18f;
    public Vector2 bobbingAmount = new Vector2(0.2f, 0.2f);
    private float midpointX = 2f;
    private float midpointY = 2f;
    private float timerX;
    private float timerY;

    private Transform MainCamera;



    void Start()
    {
        MainCamera = Camera.main.transform;
        midpointX = MainCamera.transform.localPosition.x;
        midpointY = MainCamera.transform.localPosition.y;
    }

    void Update()
    {
        float wavesliceX = 0f;
        float wavesliceY = 0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 MyPos = MainCamera.localPosition;


        if (FPCStatus.IsAiming) { return; } // Sentencia seguridad


        if (FPCStatus.isShooting)
        {
            if (this.AxisMov == Axis.X)
            {
                MyPos.x = midpointX;
            }
            else if (AxisMov == Axis.Y)
            {
                MyPos.y = midpointY;
            }
            else if (AxisMov == Axis.XY)
            {
                MyPos.x = midpointX;
                MyPos.y = midpointY;
            }

            MainCamera.localPosition = MyPos;
            timerX = 0f;
            timerY = 0f;
            return;
        }

        // Bobbing!
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timerX = 0f;
            timerY = 0f;
        }
        else
        {
            // Calcula el tiempo del movimiento basado en la velocidad de bob.
            wavesliceX = Mathf.Sin(timerX);
            if (FPCStatus.isCrouched)
            {
                timerX = timerX + ((bobbingSpeed * 0.5f) * Time.deltaTime);
            }
            else
            {
                timerX = timerX + (bobbingSpeed * Time.deltaTime);
            }

            if (timerX > Mathf.PI * 2)
            {
                timerX = timerX - (Mathf.PI * 2);
            }

            wavesliceY = Mathf.Sin(timerY);
            timerY = timerX * 2;
            if (timerY > (Mathf.PI * 2))
            {
                timerY = timerY - (Mathf.PI * 2);
            }
        }


        if (wavesliceX != 0 || wavesliceY != 0)
        {
            // Calcula el desplazamiento en ese momento dado multiplicado por la cantidad de mivimiento.
            float translateChangeX = 0;

            if (FPCStatus.isCrouched)
            {
                translateChangeX = wavesliceX * bobbingAmount.x * 0.5f;
            }
            else
            {
                translateChangeX = wavesliceX * bobbingAmount.x;
            }
            float totalAxesX = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxesX = Mathf.Clamp01(totalAxesX);
            translateChangeX = totalAxesX * translateChangeX;

            float translateChangeY = 0;
            if (FPCStatus.isCrouched)
            {
                translateChangeY = wavesliceY * bobbingAmount.y * 0.5f;
            }
            else
            {
                translateChangeY = wavesliceY * bobbingAmount.y;
            }
            float totalAxesY = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxesY = Mathf.Clamp01(totalAxesY);
            translateChangeY = totalAxesY * translateChangeY;


            // Calcula la posicion final
            if (AxisMov == Axis.X)
            {
                MyPos.x = midpointX + translateChangeX;
            }
            else if (AxisMov == Axis.Y)
            {
                MyPos.y = midpointY + translateChangeY;
            }
            else if (AxisMov == Axis.XY)
            {
                MyPos.x = midpointX + translateChangeX;
                MyPos.y = midpointY + translateChangeY;
            }
        }
        else
        {
            if (AxisMov == Axis.X)
            {
                MyPos.x = midpointX;
            }
            else if (AxisMov == Axis.Y)
            {
                MyPos.y = midpointY;
            }
            else if (AxisMov == Axis.XY)
            {
                MyPos.x = midpointX;
                MyPos.y = midpointY;
            }
        }

        MainCamera.localPosition = MyPos;
    }

    

}