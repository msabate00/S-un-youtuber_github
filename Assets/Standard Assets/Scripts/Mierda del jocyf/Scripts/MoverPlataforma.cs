using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public float speedDown = 2;
    public float speedUp = 2;
    private Transform MyTransform;
    private bool HasMoved;
    private Vector3 OriginalPosition;
    private bool IsFPCOver;


    void Start()
    {
        MyTransform = transform.parent;
        OriginalPosition = MyTransform.position;
    }

    void Update()
    {
        if (HasMoved && !IsFPCOver) // Mover la plataforma a la posiion original cuando el player ya no esta encima de ella.
        {
            MyTransform.Translate(Vector3.up * speedUp * Time.deltaTime, Space.World);
            if (MyTransform.position.y >= OriginalPosition.y)
            {
                MyTransform.position = OriginalPosition;
                HasMoved = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("FPC is over the Platform");
        if (other.transform.tag.Contains("Player"))
        {
            if (!HasMoved)
            {
                HasMoved = true;
                IsFPCOver = true;
            }

            // Movimiento de la plataforma hacia abajo
            MyTransform.Translate(-Vector3.up * speedDown * Time.deltaTime, Space.World);
            
            // Me aseguro de que no baje mas de cierta altura. Restriccion. La altura es fija, deberia de tener un punto de destino.
            if (MyTransform.position.y <= 1f)
            {
                Vector3 _posAux = MyTransform.position;
                _posAux.y = 1f;
                MyTransform.position = _posAux;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Contains("Player"))
        {
            IsFPCOver = false;
        }
    }

}