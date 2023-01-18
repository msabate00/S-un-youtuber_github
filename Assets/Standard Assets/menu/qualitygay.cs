using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class qualitygay : MonoBehaviour, ISelectHandler
{

	private Resolution[] resolutions;
	private List<Resolution> resolutionsDef = new List<Resolution>();
	private TMP_Dropdown a;
	public TMP_Text text;
	private List<int> Refreshes = new List<int>();
	public int audiotipo = -1;

	public static bool parchedemierda = false;

	public enum Direction
	{
		Quality = 0,
		Resolution = 1,
		Refresh = 2,
		Screen = 3,
		Vsync = 4,
		Nada = 5,
		Sensibilidad = 6,
		LimitarFPS = 7,
		Fov = 8,
		Dificultad = 9,
		ShowFPS = 10
	}

	public Direction Modo;

	void OnEnable()
    {
		parchedemierda = true;
		StartCoroutine(parcheadorsexual());

		switch (Modo)
		{
			case Direction.Quality:

				hacercosas();

				break;
			
			case Direction.Resolution:

				Res();

				break;

			case Direction.Refresh:

				Refreshgay();

				break;

			case Direction.Screen:

				Ventana();

				break;

			case Direction.Vsync:

				Vsyncgay();

				break;

			case Direction.Nada:



				break;

			case Direction.Sensibilidad:

				ActSens();

				break;

			case Direction.LimitarFPS:

				Limitargays();

				break;

			case Direction.Fov:

				LimitargaysFOV();

				break;

			case Direction.Dificultad:

				PillarDificultad();

				break;

			case Direction.ShowFPS:

				ShowFPS();

				break;
		}

		if (audiotipo != -1) {
			setearslider(audiotipo);
		}

	}

	void Refreshgay()
    {
		Refreshes.Clear();

		Refreshes.Add(50);
		Refreshes.Add(60);
		Refreshes.Add(75);

		bool nuse = false;

		for (int i = 0; i < Refreshes.Count; i++)
        {
			if (Refreshes[i] == Controlador.RefreshOrig) { nuse = true; break; }
		}

		if (!nuse) { Refreshes.Add(Controlador.RefreshOrig); }

		a = GetComponent<TMP_Dropdown>();
		a.options.Clear();

		for (int i = 0; i < Refreshes.Count; i++)
		{
			a.options.Add(new TMP_Dropdown.OptionData() { text = Refreshes[i].ToString() });
		}

		a.value = Refreshes.IndexOf(Screen.currentResolution.refreshRate);
	}


	public void cocksucker(int mierda) {

		Controlador.QualityLevel = mierda;
		hacercosas();
	}
	
	void hacercosas()
    {
		GetComponent<TMP_Dropdown>().value = Controlador.QualityLevel;
		QualitySettings.SetQualityLevel(Controlador.QualityLevel);
		GameObject.Find("Vsync").SendMessage("Vsyncgay");
	}

	void Res()
    {
		resolutions = Screen.resolutions;
		a = GetComponent<TMP_Dropdown>();
		a.options.Clear();
		resolutionsDef.Clear();


		for (int i = 0; i < resolutions.Length; i++)
        {
			
			if (i > 0 && resolutions[i].height == resolutions[i - 1].height && resolutions[i].width == resolutions[i - 1].width) { continue; }

			resolutions[i].refreshRate = Controlador.Refresh;
			a.options.Add(new TMP_Dropdown.OptionData() { text = resolutions[i].ToString() });
			resolutionsDef.Add(resolutions[i]);

			if (Screen.height == resolutions[i].height && Screen.width == resolutions[i].width) { a.value = i; }
		}

		GameObject.Find("FullScreen").SendMessage("Ventana");
	}

	void Ventana()
    {
		a = GetComponent<TMP_Dropdown>();
		a.options.Clear();

		a.options.Add(new TMP_Dropdown.OptionData() { text = "Pantalla completa" });
		a.options.Add(new TMP_Dropdown.OptionData() { text = "Ventana sin bordes" });
		a.options.Add(new TMP_Dropdown.OptionData() { text = "Ventana" });

		

			if (Controlador.Ventana == FullScreenMode.ExclusiveFullScreen) { a.value = 0; }
			else if (Controlador.Ventana == FullScreenMode.FullScreenWindow) { a.value = 1; }
			else if (Controlador.Ventana == FullScreenMode.Windowed) { a.value = 2; }

	}

	public void OnSelect(BaseEventData eventData)
	{
		if (Modo == Direction.Screen)
        {
			Ventana();
		}
		
	}

	public void SetearRatio(int mierda)
    {
		if (parchedemierda) { return; }
		Screen.SetResolution(resolutionsDef[mierda].width, resolutionsDef[mierda].height, Controlador.Ventana, resolutionsDef[mierda].refreshRate);
		GameObject.Find("FullScreen").SendMessage("Ventana");
		Controlador.Resolucion.width = resolutionsDef[mierda].width;
		Controlador.Resolucion.height = resolutionsDef[mierda].height;
		Controlador.Resolucion.refreshRate = resolutionsDef[mierda].refreshRate;
	}

	public void SetearRefresh(int mierda)
    {
		if (parchedemierda) { return; }
		Controlador.Refresh = Refreshes[mierda];
		Screen.SetResolution(Screen.width, Screen.height, Controlador.Ventana, Controlador.Refresh);
		GameObject.Find("Resolucion").SendMessage("Res");
		GameObject.Find("FullScreen").SendMessage("Ventana");

		GameObject.Find("Refresh").SendMessage("Refreshgay");
	}

	public void SetearVentana(int mierda)
    {
		if (parchedemierda) { return; }
		if (mierda == 0) { Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen; Controlador.Ventana = FullScreenMode.ExclusiveFullScreen;  }
		else if (mierda == 1) { Screen.fullScreenMode = FullScreenMode.FullScreenWindow; Controlador.Ventana = FullScreenMode.FullScreenWindow; }
		else { Screen.fullScreenMode = FullScreenMode.Windowed; Controlador.Ventana = FullScreenMode.Windowed; }

		//Controlador.Ventana = Screen.fullScreenMode;

		//GameObject.Find("Resolucion").SendMessage("Res");

		gameObject.GetComponentInParent<qualitygay>().parche();

		TMP_Dropdown pinus = GetComponent<TMP_Dropdown>();

		pinus.Hide();

		Ventana();
	}
	

	public void parche()
    {
		gameObject.SetActive(false);
		gameObject.SetActive(true);
	}

	public void setearvsync()
    {
		Controlador.vsync = !Controlador.vsync;
		Vsyncgay();
    }

	public void Vsyncgay()
    {
		transform.GetChild(2).gameObject.SetActive(Controlador.vsync);

		if (Controlador.vsync) { QualitySettings.vSyncCount = 1; }
        else { QualitySettings.vSyncCount = 0; }
    }

	public void ShowFPS()
	{
		transform.GetChild(2).gameObject.SetActive(Controlador.ShowFPS);

		GameObject sex = null;
		if (GameObject.Find("MarcadorFPS")) { sex = GameObject.Find("MarcadorFPS").transform.GetChild(0).gameObject; }
		if (sex == null) { return; }
		sex.SetActive(Controlador.ShowFPS);
	}

	public void setearshowfps()
	{
		Controlador.ShowFPS = !Controlador.ShowFPS;
		ShowFPS();
	}

	void ActSens()
    {
		if (!GetComponentInChildren<Slider>()) { return; }
		GetComponentInChildren<Slider>().value = Controlador.sensibilidad;
		transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Controlador.sensibilidad.ToString("F2");
    }

	public void sensgay()
    {
		Controlador.sensibilidad = GetComponentInChildren<Slider>().value;
		MouseLook.sensitivityX = Controlador.sensibilidad;
		MouseLook.sensitivityY = Controlador.sensibilidad;
		ActSens();
    }

	public void audio(int a)
    {
		if (a == 0) { Controlador.volumenef = GetComponentInChildren<Slider>().value; GetComponentInChildren<Slider>().value = Controlador.volumenef; }
		else if (a == 1) { Controlador.volumenmusica = GetComponentInChildren<Slider>().value; GetComponentInChildren<Slider>().value = Controlador.volumenmusica; }
		else if (a == 2) { Controlador.volumenglobal = GetComponentInChildren<Slider>().value; GetComponentInChildren<Slider>().value = Controlador.volumenglobal; AudioListener.volume = Controlador.volumenglobal; }
	}

	void setearslider(int a)
    {
		if (a == 0) { GetComponentInChildren<Slider>().value = Controlador.volumenef; }
		else if (a == 1) { GetComponentInChildren<Slider>().value = Controlador.volumenmusica; }
		else if (a == 2) { GetComponentInChildren<Slider>().value = Controlador.volumenglobal; }
	}

	public void limitarfps(string a)
    {
		if (a == "") { a = Controlador.limitefps.ToString(); GetComponentInChildren<TMP_InputField>().text = Controlador.limitefps.ToString(); }
		int penis = int.Parse(a);
		if (penis < 15) { penis = 15; GetComponentInChildren<TMP_InputField>().text = penis.ToString(); }
		Controlador.limitefps = penis;
		Application.targetFrameRate = Controlador.limitefps;

	}

	public void fov(string a)
	{
		if (a == "") { a = Controlador.fov.ToString(); GetComponentInChildren<TMP_InputField>().text = Controlador.fov.ToString(); }
		int penis = int.Parse(a);
		penis = Mathf.Clamp(penis, 60, 120);
		GetComponentInChildren<TMP_InputField>().text = penis.ToString();
		Controlador.fov = penis;
		DisparoSelectivo.originalfov = penis;
		if (DisparoSelectivo.GunStatusScript2 != null)
        {
			DisparoSelectivo.GunStatusScript2.gameObject.SendMessage("ActualizarFOV");
		}
		
	}

	void Limitargays()
    {
		GetComponentInChildren<TMP_InputField>().text = Controlador.limitefps.ToString();
	}
	
	void LimitargaysFOV()
	{
		GetComponentInChildren<TMP_InputField>().text = Controlador.fov.ToString();
	}

	public void Reset()
    {
		Controlador.QualityLevel = 5;
		Controlador.Refresh = Controlador.RefreshOrig;
	Controlador.Ventana = FullScreenMode.ExclusiveFullScreen;
	Controlador.vsync = false;
	Controlador.sensibilidad = 1;
	Controlador.volumenef = 1;
	Controlador.volumenmusica = 1;
	Controlador.volumenglobal = 0.3f;
	Controlador.limitefps = 200;
		Controlador.fov = 90;
		Controlador.dificultad = 1;
		Controlador.Resolucion = Controlador.ResolucionNativa;
		Controlador.ShowFPS = false;

		GameObject.Find("Global").GetComponentInChildren<Slider>().value = Controlador.volumenglobal;
		GameObject.Find("musica").GetComponentInChildren<Slider>().value = Controlador.volumenmusica;
		GameObject.Find("efectos").GetComponentInChildren<Slider>().value = Controlador.volumenef;
		GameObject.Find("sensibilidad").GetComponentInChildren<Slider>().value = Controlador.sensibilidad;
		GameObject.Find("Fov").GetComponentInChildren<TMP_InputField>().text = Controlador.fov.ToString();
		GameObject.Find("Limitar FPS").GetComponentInChildren<TMP_InputField>().text = Controlador.limitefps.ToString();
		fov(Controlador.fov.ToString());
		if (GameObject.Find("Dificultad") != null)
        {
			GameObject.Find("Dificultad").GetComponentInChildren<TMP_Dropdown>().value = Controlador.dificultad;
		}

		//Screen.SetResolution(Controlador.Resolucion.width, Controlador.Resolucion.height, Controlador.Ventana, Controlador.Refresh);
		gameObject.SetActive(false);
		gameObject.SetActive(true);

	}

	void Update()
    {
		if (Modo == Direction.Screen)
        {
			Controlador.Ventana = Screen.fullScreenMode;
		}
    }

	public void dificultad (int mierda)
    {
		Controlador.dificultad = mierda;
    }

	void PillarDificultad()
    {
		TMP_Dropdown drop = GetComponent<TMP_Dropdown>();

		drop.value = Controlador.dificultad;
    }

	IEnumerator parcheadorsexual()
    {
		yield return null;
		yield return null;
		parchedemierda = false;
	}
}
