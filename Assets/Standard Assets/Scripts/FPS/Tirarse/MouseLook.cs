using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public static float sensitivityX = 4F;
	public static float sensitivityY = 4F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;

    [HideInInspector]
	public static float rotationY = 0F;
    public static float rotationY2 = 0F;
    public static float rotationX2 = 0F;
	public static float rotationY3 = 0F;
	public static float rotationX3 = 0F;

	private float pollax;
    private float pollay;

	private float fps;
	private float fps2;

	private float polladas = 0;
	public static float origsensx;
	public static float origsensy;
	float offsetY = 0;
	private float deltatime;
	private float rotationX;

	public static float mult;

	public int targetFrameRate = 75;
	public bool cont = false;
	public int targetFrameRate2 = 200;
	public float timer1 = 0;
	public float timer2 = 0;
	public float lastframe;
	public float newframe;
	private float tiempo;
	public float multgay = 1;

	void Awake()
    {
		rotationY = 0F;
		sensitivityX = Controlador.sensibilidad;
        sensitivityY = Controlador.sensibilidad;
		origsensx = sensitivityX;
		origsensy = sensitivityY;
	}
	
	void Update()
    {
		deltatime = Time.deltaTime;

		if (Time.timeScale == 0 || Pausa.Pa.dentro) { return; }

		/*
		float sensX = sensitivityX * (Camera.main.fieldOfView / DisparoSelectivo.originalfov);
		float sensY = sensitivityY * (Camera.main.fieldOfView / DisparoSelectivo.originalfov);
		*/

		float sensX = sensitivityX * mult;
		float sensY = sensitivityY * mult;

		rotationX = Input.GetAxisRaw("Mouse X") * sensX;
		rotationY -= Input.GetAxisRaw("Mouse Y") * sensY;

		
	}
	
	void LateUpdate()
	{
		//Debug.Log(sensitivityX);
		//float deltas = deltatime;
		//	float pollada = 1 / deltas;
		//	float sensy = origsensy;
		//	sensy /= 60;
		//	sensy *= pollada;
		//	sensitivityY = sensy;

		//float deltas2 = deltatime;
		//	float polladas = 1 / deltas2;

		//float sensx = origsensx;
		//	sensx /= 60;
		//	sensx *= polladas;
		//sensitivityX = sensx;

		if (Time.timeScale == 0 || Pausa.Pa.dentro) { return; }

		if (axes == RotationAxes.MouseXAndY)
		{
			/*
			float rotationX = transform.localEulerAngles.y + Input.GetAxisRaw("Mouse X") * sensitivityX;
			rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			*/

			float m_VerticalAngle = transform.localEulerAngles.x;
		    m_VerticalAngle = Mathf.Clamp(rotationY + m_VerticalAngle, minimumY, maximumY);

			Vector3 currentAngles = transform.localEulerAngles;
			currentAngles.x = m_VerticalAngle;
			transform.localEulerAngles = currentAngles;
		}
		if (axes == RotationAxes.MouseX)
		{
			/*

			rotationX2 *= Time.deltaTime; 
		    rotationX += rotationX2;
			pollax = rotationX;
			transform.Rotate(0, rotationX * sensitivityX, 0);
			*/
			//rotationX3 *= Time.deltaTime;
			float rX = rotationX2;
			rX *= Time.deltaTime;
			float m_HorizontalAngle = transform.localEulerAngles.y;
			m_HorizontalAngle = m_HorizontalAngle + rotationX + rX;

			if (m_HorizontalAngle > 360) m_HorizontalAngle -= 360.0f;
			if (m_HorizontalAngle < 0) m_HorizontalAngle += 360.0f;

			Vector3 currentAngles = transform.localEulerAngles;
			currentAngles.y = m_HorizontalAngle;
			transform.localEulerAngles = currentAngles;

		}
		else
		{
			/*
			rotationY2 *= Time.deltaTime;
			rotationY += rotationY2;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			pollay = rotationY;
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			*/
			float rY = rotationY2;
			rY *= Time.deltaTime;
			rotationY -= rY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			

			Vector3 currentAngles = transform.localEulerAngles;
			currentAngles.x = rotationY;
			transform.localEulerAngles = currentAngles;

			if (rotationY == minimumY)
            {
                FPCStatus.maximoratgay = true;
            }
            else if (rotationY == maximumY)
            {
                FPCStatus.maximoratgay = true;
            }
            else
            {
                FPCStatus.maximoratgay = false;
            }
                  
        }
		
		if(offsetY != 0)
			offsetY = 0;
	}
	
	void SetOffsetY(float _value){
		offsetY = _value;
	}
	
	void Start ()
	{
		rotationY = 0F;
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
		GetComponent<Rigidbody>().freezeRotation = true;

		sensitivityX = Controlador.sensibilidad;
		sensitivityY = Controlador.sensibilidad;
		origsensx = sensitivityX;
		origsensy = sensitivityY;

		//StartCoroutine(gaysex());
	}

	IEnumerator gaysex()
	{
		while (true)
		{
			newframe = Time.time;

			tiempo = newframe - lastframe;
			int vueltas = 0;
			while (true)
			{
				vueltas++;
				if (tiempo < 1f / targetFrameRate2) { break; }
				timer2 += 1;
				//Debug.Log(tiempo);
				tiempo -= 1f / targetFrameRate2;
				sex();

			}
			if (newframe - lastframe > 1f / targetFrameRate2)
			{
				lastframe = Time.time - tiempo;
			}

			yield return null;
		}
	}

	void sex()
    {
		float sensX = sensitivityX * mult;
		float sensY = sensitivityY * mult;

		rotationX = (Input.GetAxisRaw("Mouse X") * sensX * multgay ) * Time.deltaTime;
		rotationY -= (Input.GetAxisRaw("Mouse Y") * Time.deltaTime) * ((sensY * 0.5f )* multgay);
		Debug.Log(rotationX);

		
		if (axes == RotationAxes.MouseX)
		{
			/*

			rotationX2 *= Time.deltaTime; 
		    rotationX += rotationX2;
			pollax = rotationX;
			transform.Rotate(0, rotationX * sensitivityX, 0);
			*/
			//rotationX3 *= Time.deltaTime;
			float rX = rotationX2;
			rX *= Time.deltaTime;
			float m_HorizontalAngle = transform.localEulerAngles.y;
			m_HorizontalAngle = m_HorizontalAngle + rotationX + rX;

			if (m_HorizontalAngle > 360) m_HorizontalAngle -= 360.0f;
			if (m_HorizontalAngle < 0) m_HorizontalAngle += 360.0f;

			Vector3 currentAngles = transform.localEulerAngles;
			currentAngles.y = m_HorizontalAngle;
			transform.localEulerAngles = currentAngles;

		}
		else
		{
			/*
			rotationY2 *= Time.deltaTime;
			rotationY += rotationY2;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			pollay = rotationY;
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			*/
			float rY = rotationY2;
			rY *= Time.deltaTime;
			rotationY -= rY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);


			Vector3 currentAngles = transform.localEulerAngles;
			currentAngles.x = rotationY;
			transform.localEulerAngles = currentAngles;

			if (rotationY == minimumY)
			{
				FPCStatus.maximoratgay = true;
			}
			else if (rotationY == maximumY)
			{
				FPCStatus.maximoratgay = true;
			}
			else
			{
				FPCStatus.maximoratgay = false;
			}

		}

		if (offsetY != 0)
			offsetY = 0;
	}
}