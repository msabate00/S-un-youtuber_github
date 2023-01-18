using UnityEngine;

public class VariationGun : MonoBehaviour
{
    // Basado en el script de la demo de disparos de technotdc.
    public Vector2 amountXY = new Vector2(1, 1);
    public Vector2 maxAmount = new Vector2(2, 2);
    public Vector2 minAmount = new Vector2(-2, -2);
    public float smooth = 6;

    private Vector3 OriginalPosition;
    private float XComp;
    private float YComp;
    private Vector3 finalPosition;
    private AimDownSights aim;


    public void ReasignOriginalValues(Vector3 NewGunPos)
    {
        OriginalPosition = NewGunPos;
        transform.localPosition = NewGunPos;
    }

    public void ReasignOriginalRotValues(Quaternion NewGunRot)
    {
        transform.localRotation = NewGunRot;
    }


    void Start()
    {
        OriginalPosition = transform.localPosition;
        aim = gameObject.GetComponentInChildren<AimDownSights>();

    }


    // Movemos el arma sobre su pivot para generar un efecto de desplazamiento al mover el raton.
    void Update()
    {
        // Sentencias se seguridad.
        if (FPCStatus.IsFire2Down && !FPCStatus.isRunning && !FPCStatus.dual && aim != null && aim.enabled) { transform.localPosition = OriginalPosition; return; } // Si estamos apuntando, no se rotara el arma.
        if (FPCStatus.IsAiming) { return; } // Lo mismo.        

        // El calculo del desplazamiento del arma solo se hace cuando se esta moviendo el raton
        if (FPCStatus.IsAxisXActive || FPCStatus.IsAxisYActive)
        {
            if (FPCStatus.IsAxisXActive)
            {
                XComp = -FPCStatus.AxisXValue * amountXY.x;
                XComp = Mathf.Clamp(XComp, minAmount.x, maxAmount.x);
            }
            else
            {
                XComp = 0;
            }

            if (FPCStatus.IsAxisYActive)
            {
                if (!FPCStatus.maximoratgay)
                {
                    YComp = -FPCStatus.AxisYValue * amountXY.y;
                    YComp = Mathf.Clamp(YComp, minAmount.y, maxAmount.y);
                }
                if (FPCStatus.maximoratgay)
                {
                    YComp = 0;
                }
            }
            else
            {
                YComp = 0;
            }

            finalPosition = new Vector3(OriginalPosition.x + XComp, OriginalPosition.y + YComp, OriginalPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition, Time.deltaTime * smooth * Controlador.sensibilidad);
        }
    }

    

}