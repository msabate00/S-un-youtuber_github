using UnityEngine;

public enum RotationAxes
{
    MouseXAndY = 0,
    MouseX = 1,
    MouseY = 2
}

public class RotationGun : MonoBehaviour
{
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 10f;
    public float sensitivityY = 17f;
    public float minimumX = -10f;
    public float maximumX = 10f;
    public float minimumY = -10f;
    public float maximumY = 10f;
    public float damping = 6f;

    private float rotationY;
    private float rotationX;


    public virtual void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    public virtual void Update()
    {
        // No hacer ada en este script cuando estoy saltando y corriendo.
        if (FPCStatus.isRunning || FPCStatus.IsJumping) { return; }

        // No permitir giros cuado está apuntando.
        if (FPCStatus.IsAiming) { transform.rotation = Camera.main.transform.rotation; return; }


        if ((axes == RotationAxes.MouseXAndY && FPCStatus.IsAxisXActive) || FPCStatus.IsAxisYActive)
        {
            float RotTotalXLerp = Mathf.LerpAngle(transform.localEulerAngles.y, GetRotationX(), damping * Time.deltaTime);
            float RotTotalYLerp = Mathf.LerpAngle(transform.localEulerAngles.x, GetRotationY(), damping * Time.deltaTime);
            transform.localEulerAngles = new Vector3(RotTotalYLerp, RotTotalXLerp, 0);
        }
        else if (axes == RotationAxes.MouseX && FPCStatus.IsAxisXActive)
        {
            float RotTotalXLerp = Mathf.LerpAngle(transform.localEulerAngles.y, GetRotationX(), damping * Time.deltaTime);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, RotTotalXLerp, 0);
        }
        else if (FPCStatus.IsAxisYActive)
        {
            float RotTotalYLerp = Mathf.LerpAngle(transform.localEulerAngles.x, GetRotationY(), damping * Time.deltaTime);
            transform.localEulerAngles = new Vector3(RotTotalYLerp, transform.localEulerAngles.y, 0);
        }

        // Hace el seguimiento para mirar al target en caso de que no estés girando el raton.
        if (!FPCStatus.IsAxisXActive && !FPCStatus.IsAxisYActive)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Camera.main.transform.rotation, damping * Time.deltaTime);
        }
    }

    private float GetRotationX()
    {
        float RotAuxX, RotTotalX = 0;

        RotAuxX = FPCStatus.AxisXValue * sensitivityX * (Controlador.sensibilidad);
        RotAuxX = Mathf.Clamp(RotAuxX, minimumX, maximumX);
        rotationX += RotAuxX;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        RotTotalX = rotationX + transform.localEulerAngles.y;
        RotTotalX = LimitAngle(RotTotalX, maximumX, 360 + minimumX);

        return RotTotalX;
    }

    private float GetRotationY()
    {
        float RotAuxY, RotTotalY = 0;

        RotAuxY = FPCStatus.AxisYValue * sensitivityY * (Controlador.sensibilidad);
        RotAuxY = Mathf.Clamp(RotAuxY, minimumY, maximumY);
        rotationY += RotAuxY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        RotTotalY = rotationY + transform.localEulerAngles.x;
        RotTotalY = LimitAngle(RotTotalY, maximumY, 360 + minimumY);

        return RotTotalY;
    }

    private float LimitAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle = angle + 360;
        }
        if (angle > 360)
        {
            angle = angle - 360;
        }

        if (angle > min && angle < 300)
        {
            angle = min;
        }
        else if (angle < max && angle > 100)
        {
            angle = max;
        }

        return angle;
    }

   

}