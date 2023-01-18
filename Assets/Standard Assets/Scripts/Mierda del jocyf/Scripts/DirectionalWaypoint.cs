using UnityEngine;

public class DirectionalWaypoint : MonoBehaviour
{
    [Tooltip("The next waypoint, this variable needs to be assigned in the inspector. You can select all waypoints to see the full waypoint path.")]
    public DirectionalWaypoint next;
    [Tooltip("This is used to determine where the start waypoint is.")]
    public bool isStart;
    public bool ocupao = false;
    public bool lehedao = false;

    private Transform myTransform;

    // Returns where the AI should drive towards position is the current position of the car.
    void Update()
    {
        if (lehedao)
        {
            ocupao = true;
        }
        if (Rusheador.aporesecerdofascista)
        {
            ocupao = false;
        }
    }
    void OnTriggerStay(Collider mishuevos)
    {
        if (mishuevos.gameObject.tag == "Desactivador")
        {
            ocupao = false;
        }
    }
  
    public DirectionalWaypoint CalculateTargetPosition(Vector3 position, float nDistance)
    {
        // If we are getting close to the waypoint, we return the next waypoint.
        // This gives us better behaviour when cars (or enemy) don't exactly hit the waypoint
        if (CalculateDistance(position) < nDistance)
        {
            ocupao = true;
            SendMessage("SumadorRetraso", 1);
            return next;
        }
        else
        {
            // We are still far away from the next waypoint, just return the waypoints position
            return this;
        }
    }
    public DirectionalWaypoint CalculateDisponiblepollas(Vector3 position, float nDistance)
    {
        // If we are getting close to the waypoint, we return the next waypoint.
        // This gives us better behaviour when cars (or enemy) don't exactly hit the waypoint
        if (ocupao)
        {
            return next;
            
        }
        else
        {
            // We are still far away from the next waypoint, just return the waypoints position
            return this;
        }
    }
    public void estaocupao()
    {
        ocupao = true;
    }
    // Get the distance from this waypoint to 'position'.
 
    public float CalculateDistance(Vector3 position)
    {
        return Vector3.Distance(myTransform.position, position);
    }

    // This initializes the start and goal static variables.
    // We have to do this inside Awake because the waypoints need to be initialized before the AI scripts use it.
    // All Awake function are always called before all Start functions.
    void Awake()
    {
        myTransform = this.transform;

        if (!next)
        {
            Debug.Log("This waypoint is not connected, you need to set the next waypoint!", this);
        }
    }

    // Draw the waypoint pickable gizmo
    void OnDrawGizmos()
    {
        //Gizmos.DrawIcon(transform.position, "waypoint.png");   /**/
        if (next)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }

    // Draw the waypoint lines only when you select one of the waypoints
    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawIcon(transform.position, "waypoint.png");
        if (next)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }

}