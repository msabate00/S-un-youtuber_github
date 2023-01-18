using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Controlador : MonoBehaviour {

    public static Controlador ah;

    public static string nuser = "Míster gay"; // el puto nombre de usuario que la gente podrá puto ponerse mira el proyecto borra ahí ahi escrí y cosas
    public static int num = 0;
    public static int Moral = 0;
    public static int ComB = 0;
    public static int ComM = 0;
    public static int Comneg = 0;
    public static int Comneg1 = 0;
    public static int Comneg2 = 0;
    public static int Comneg3 = 0;
    public static int Comneg4 = 0;
    public static int like1 = 0;
    public static int like2 = 0;
    public static int like3 = 0;
    public static int like4 = 0;
    public static int like5 = 0;
    public static int Edicion = 10; //13 max            CALIDAD DE VIDEO + COMENTARIOS
    public static int Comunicacion = 11; //13 max
    public static int Skill = 9; //13 max
    public static int Video = 9; //40 max
    public static int Video2 = 10; //40 max
    public static int Entretenimiento = 10; //20 max    CALIDAD DE VIDEO + COMENTARIOS
    public static int Seguidores = 25; //60 max         CALIDAD DE COMENTARIOS
    public static int Seguidoresprov = 0;
    public static int Acercamiento = 30; //30 max       DISMINUCIÓN DE CALIDAD DE COMUNIDAD    
    public static int Rebeldía = 10; //30 max, 15 es neutro y 0 niño bueno        PERSONALIDAD
    public static int Imagen = 100; //100 max                                        MARCAS
    public static int amplia = 1;
    public static int Min1 = 74;
    public static int Max1 = 100;
    public static int Min2 = 36;
    public static int Max2 = 73;
    public static int Min3 = 1;
    public static int Max3 = 35;
    public static int TipoEdicion = 0; //0 es no selected, 1 simple, 2 complejo, 3 montaje
    public static int Lenguaje = 0; //Max 40
    public static int Lenguaje1 = 0; //Max 40
    public static int Suscriptores = 1000;
    public static int Suscriptores2 = 0;
    public static float Visualizaciones = 10000;
    public static float Visualizacionestotales = 0;
    public static int Dias = 0;
    public static int Diastotales = 0;
    public static int Dias2 = 0;
    public static int Diaspasaos = 0;
    public static int Diasdesdetrending = 11;
    public static int Diasgente = 0; //dias genteyutuf
    public static int VideoGrabao = 0; //Binario
    public static int ConexionSeguidores = 5; //Max 10
    public static float Dinero = 700;
    public static int DineroYoutube = 45;
    public static int DineroNetwork = 40; // cuanto más se acerca a 100, menos dinero te quitan estos hijos de puta
    public static int DineroEstado = 80;
    public static int Vid1 = 0;
    public static int Vid2 = 0;
    public static int Vid3 = 0;
    public static int times = 0;
    public static int Distancia = 0;
    public static int Times = 0;
    public static int Juegoselec = 0;
    public static int Ordenador = 2; //Habrán 3, 1 es shit, 2 es gaming y 3 pc master race
    public static bool desrank = false;
    public static bool transition = false;
    public static bool Desmonet = true;
    public static bool Copy = false;
    public static bool Embargo; // mensaje alerta (no guardar en el sistema guardado)
    public static int Mails = 0; // contador mails
    public static bool cienk = false;
    public static bool unm = false;
    public static bool diezm = false;
    public static bool cincom = false;
    public static bool cienm = false;
    public static bool trendactivao = false;
    public static string nombrevid;
    public static float dinerobid;
    public static float vidahomosexual = 100;
    public static int usos = 7;
    public static bool mestoylevantandojoder = false;
    public static int damage1;
    public static int damage2;
    public static int damage3;
    public static int damage4;
    public static int stun1;
    public static int stun2;
    public static int stun3;
    public static int stun4;
    public static float critico1;
    public static float critico2;
    public static float critico3;
    public static float cd1;
    public static float cd2;
    public static float cd3;
    public static float cd4;
    public static float cd5;
    public static float cd1ratio;
    public static float cd2ratio;
    public static float cd3ratio;
    public static float cd4ratio;
    public static float cd5ratio;
    public static bool llevobolsa = false;
    public static bool detectao = false;
    public static bool civilmuerto = false;
    public static bool trabajando = true;
    public static int diasinpaga = 0;
    public static float puntos = 0;
    public static float puntostotales;
    public static int multi = 1; // 1-5
    public static float desfibrilador = 2;
    public float desfvel = 1;
    public static int cargas = 3;
    public static int ultanim = 0;
    public static int meleenivel2 = 0;

    public static int enemigostochosalpha;
    public static int enemigosnormalesalpha;
    public static int enemigoscampersalpha;
    public static int enemigostochosbeta;
    public static int enemigosnormalesbeta;
    public static int enemigoscampersbeta;
    public static int enemigostochosdelta;
    public static int enemigosnormalesdelta;
    public static int enemigoscampersdelta;
    public static int enemigostochosgamma;
    public static int enemigosnormalesgamma;
    public static int enemigoscampersgamma;

    public static int enemigosactuales = 0;
    public static int enemigosactualesesp = 0;
    public static float[] dañoenemigogay;
    public static int[] enemigoslista;

    public static float[] bajas = new float[10];
    public static float[] bajaspartidagay = new float[10];
    public static float bajastotales;
    public static float bajaspartida;
    public static float muertes;

    public static int dineroasegurado = 0;
    public static bool asalto = false;

    public int[] objetos;
    public float[] precios;

    public int[] habitosint; //min 0 max 3
    public int[] habman;

    public static int[] horasgays = new int[35];
    public static int[] horasgaystotales = new int[35];
    public static int horasmax = 5;
    public static int horastot = 0;
    public static int horastotmax = 15;
    public static int restantescompra = 7;
    public static bool comprauto = true;

    public int[] pccalidad;
    public string[] pctexto;
    public float[] pcprecios;
    public bool[] pcdisp;
    public int[] pcselec;
    public int[] pcafect;
    public int[] pcdesc;
    public float[] pcfinal;
    public int valoracion;

    public static List<float> listadinero = new List<float>() { Dinero };
    public static List<int> semanas = new List<int>() { 0 };
    public static List<string> videos = new List<string>() { };
    public static List<float> calidadvideos = new List<float>() { };
    public static List<int> suscribersgays = new List<int>() { 0 };
    public List<claselista> listauto;
    public static int suscriptoresult = 1000; // empieza siendo igual que suscriptores
    public List<GestorgayStats> listastats = new List<GestorgayStats>();

    public static Resolution Resolucion;
    public static Resolution ResolucionNativa;
    public static int QualityLevel = 5;
    // public static bool Fullscreen = true;
    public static int Refresh = 60;
    public static int RefreshOrig = 60;
    public static FullScreenMode Ventana;
    public static bool vsync = false;
    public static float sensibilidad = 1;
    public static float volumenef = 1;
    public static float volumenmusica = 1;
    public static float volumenglobal = 0.3f;
    public static int limitefps = 75;
    public static int fov = 90;
    public static int dificultad = 1;
    public static bool ShowFPS = false;


    public Coroutine para = null;

    public GameObject moridor;

    private mostradorUI UIgay;

    private float separacion = -62f;
    private float separacion2 = -67f;
    private bool ahora = false;
    public static bool muerto = false;
    public Coroutine activacursorgay = null;

    public static string adondequiereirbro = "";
    public static bool adelante = false;
    Coroutine trans = null;
    Coroutine trans2 = null;
    private bool botones = false;

    public static bool acabado = false;
    [HideInInspector]
    public int posranking = 69;

    void Awake() {

        if (ah != null) { ah.gameObject.SendMessage("ResetWapo"); Destroy(gameObject); return; }
        ah = gameObject.GetComponent<Controlador>();

        ResolucionNativa = Screen.currentResolution;
        RefreshOrig = Screen.currentResolution.refreshRate;
        Refresh = RefreshOrig;
        Ventana = FullScreenMode.ExclusiveFullScreen;
        volumenglobal = AudioListener.volume;
        //Resolucion = Screen.currentResolution;

        cargar();

        Setear();
        
        /*
Latas energicas KK y RB
Alcohol
Bebidas neutrales
Snacks G y R
Snacks saludables?
Chocolate
Comida basura Pizza kebab hot dog
Comida saludable ens, arroz
Comida neutral carne, ramen
        */
        Application.targetFrameRate = limitefps;
        QualitySettings.maxQueuedFrames = 0;



    }

    // Update is called once per frame
    void Update() {
        // Debug.Log(Moral);
        // Debug.Log(Video2);
        //        Debug.Log(vidahomosexual);

        Time.fixedDeltaTime = 0.014f;

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Application.targetFrameRate += 1;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Application.targetFrameRate -= 1;
        }

        usos = Mathf.Clamp(usos, 0, 7);

        desfibrilador += desfvel * Time.deltaTime;
        desfibrilador = Mathf.Clamp(desfibrilador, 0, 2);
    }

    IEnumerator activacursor()
    {
        while (true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            yield return null;
        }
    }

    IEnumerator fadergestor()
    {
        Debug.Log("FOLLAME");
        ahora = false;
        muerto = true;
        GameObject SRC = GameObject.Find("Sacabo");
        SRC.transform.GetChild(0).gameObject.SetActive(true);
        GameObject lols = GameObject.Find("Sacabo").transform.GetChild(0).GetChild(1).GetChild(2).gameObject;

        activacursorgay = StartCoroutine(activacursor());
        StartCoroutine(armasdisplay());
        StartCoroutine(rabos());
        StartCoroutine(Record());

        int index = lols.transform.childCount;

        for (int i = 0; i < index; i++)
        {
            lols.transform.GetChild(i).gameObject.SetActive(false);
        }

        Image negro = SRC.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        Color orig = negro.color;
        orig.a = 0;
        negro.color = orig;
        float alpha = 0;

        while (true)
        {
            yield return null;

            alpha = Mathf.MoveTowards(alpha, 1, 0.7f * Time.deltaTime);
            orig.a = alpha;
            negro.color = orig;


            if (alpha == 1) { negro.color = orig; break; }
        }

        yield return new WaitForSeconds(1);

        ahora = true;
        fadergeneral();
    }

    void fadergeneral()
    {
        GameObject SRC = GameObject.Find("Sacabo").transform.GetChild(0).GetChild(1).GetChild(2).gameObject;
        int index = SRC.transform.childCount;

        for (int i = 0; i < index; i++)
        {
            SRC.transform.GetChild(i).gameObject.SetActive(true);
            SRC.transform.GetChild(i).GetComponent<Animator>().Play("fadergay");
        }
    }

    IEnumerator armasdisplay()
    {
        //yield return null;

        float[] pajas = new float[bajaspartidagay.Length];

        for (int i = 0; i < bajaspartidagay.Length; i++)
        {
            //bajas[i] += bajaspartidagay[i];
            pajas[i] = bajaspartidagay[i];
            bajaspartidagay[i] = 0;
        }

        GameObject cerda = GameObject.Find("Sacabo");

        Transform Armas = cerda.transform.GetChild(0).GetChild(1).GetChild(0);

        GameObject panel = Armas.GetChild(0).gameObject;
        GameObject textor = Armas.GetChild(1).gameObject;
        GameObject textor2 = Armas.GetChild(2).gameObject;

        textor.SetActive(false);
        textor2.SetActive(false);
        panel.SetActive(false);
        Vector3 cor = textor.GetComponent<RectTransform>().anchoredPosition3D;
        Vector3 cor2 = textor2.GetComponent<RectTransform>().anchoredPosition3D;
        Vector3 cor3 = panel.GetComponent<RectTransform>().anchoredPosition3D;

        yield return new WaitWhile(() => !ahora);

        for (int i = 2; i < pajas.Length; i++)
        {
            GameObject prov3 = Instantiate(panel, Armas);
            GameObject prov = Instantiate(textor, Armas);
            GameObject prov2 = Instantiate(textor2, Armas);

            RectTransform recto = prov.GetComponent<RectTransform>();
            RectTransform recto2 = prov2.GetComponent<RectTransform>();
            RectTransform recto3 = prov3.GetComponent<RectTransform>();

            recto.anchoredPosition3D = cor + new Vector3(0, (separacion * i), 0);
            recto2.anchoredPosition3D = cor2 + new Vector3(0, (separacion * i), 0);
            recto3.anchoredPosition3D = cor3 + new Vector3(0, (separacion * i), 0);

            TextMeshProUGUI textamen = prov.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textamen2 = prov2.GetComponent<TextMeshProUGUI>();
            Image fotopolla = prov3.GetComponent<Image>();
            Image fotopolla2 = prov3.transform.GetChild(0).GetComponent<Image>();
            textamen.text = nombre(i);
            textamen2.text = 0.ToString("F0");

            Vector4 col = new Vector4(textamen.color.r, textamen.color.g, textamen.color.b, 0);
            Vector4 col2 = new Vector4(fotopolla.color.r, fotopolla.color.g, fotopolla.color.b, 0);
            Color col3 = new Color(fotopolla.color.r, fotopolla.color.g, fotopolla.color.b, 0);

            textamen.color = col;
            textamen2.color = col;
            fotopolla.color = col2;
            fotopolla2.color = col2;
            float alpha = 0;
            float num = 0;

            prov.SetActive(true);
            prov2.SetActive(true);
            prov3.SetActive(true);

            while (true)
            {
                yield return null;

                alpha = Mathf.MoveTowards(alpha, 1, 2 * Time.deltaTime);
                col = new Vector4(col.w, col.x, col.y, alpha);
                col2 = new Vector4(col2.w, col2.x, col2.y, alpha);
                col3 = new Color(col3.r, col3.g, col3.b, alpha);
                textamen.color = col;
                textamen2.color = col;
                fotopolla.color = col3;
                fotopolla2.color = col3;

                num = Mathf.MoveTowards(num, pajas[i], 30 * Time.deltaTime);
                textamen2.text = num.ToString("F0");

                if (alpha == 1 && num == pajas[i]) { break; }
            }

        }
        Destroy(textor);
        Destroy(textor2);
        Destroy(panel);
    }

    IEnumerator rabos()
    {
        //yield return null;

        GameObject cerda = GameObject.Find("Sacabo");

        Transform Stats = cerda.transform.GetChild(0).GetChild(1).GetChild(1);

        GameObject panel = Stats.GetChild(0).gameObject;
        GameObject textor = Stats.GetChild(1).gameObject;
        GameObject textor2 = Stats.GetChild(2).gameObject;

        textor.SetActive(false);
        textor2.SetActive(false);
        panel.SetActive(false);

        yield return new WaitWhile(() => !ahora);

        float[] nums = new float[3];

        nums[0] = bajaspartida;
        Debug.Log(nums[0]);
        nums[1] = bajastotales;
        nums[2] = puntos;

        float[] ratios = new float[3];
        ratios[0] = bajaspartida / 2;
        ratios[1] = bajastotales / 4;
        ratios[2] = puntos / 5;

        bajaspartida = 0;

       

        textor.SetActive(false);
        textor2.SetActive(false);
        panel.SetActive(false);
        Vector3 cor = textor.GetComponent<RectTransform>().anchoredPosition3D;
        Vector3 cor2 = textor2.GetComponent<RectTransform>().anchoredPosition3D;
        Vector3 cor3 = panel.GetComponent<RectTransform>().anchoredPosition3D;

        Vector4 col = Color.black;
        Color col2 = Color.black;

        yield return new WaitWhile(() => !ahora);

        for (int i = 0; i < 3; i++)
        {
            GameObject prov3 = Instantiate(panel, Stats);
            GameObject prov = Instantiate(textor, Stats);
            GameObject prov2 = Instantiate(textor2, Stats);

            RectTransform recto = prov.GetComponent<RectTransform>();
            RectTransform recto2 = prov2.GetComponent<RectTransform>();
            RectTransform recto3 = prov3.GetComponent<RectTransform>();

            recto.anchoredPosition3D = cor + new Vector3(0, (separacion2 * i), 0);
            recto2.anchoredPosition3D = cor2 + new Vector3(0, (separacion2 * i), 0);
            recto3.anchoredPosition3D = cor3 + new Vector3(0, (separacion2 * i), 0);
            TextMeshProUGUI textamen = prov.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textamen2 = prov2.GetComponent<TextMeshProUGUI>();
            Image fotopolla = prov3.GetComponent<Image>();
            textamen.text = nombre2(i);
            textamen2.text = 0.ToString();

            col = new Vector4(textamen.color.r, textamen.color.g, textamen.color.b, 0);
            col2 = new Color(fotopolla.color.r, fotopolla.color.g, fotopolla.color.b, 0);
            textamen.color = col;
            textamen2.color = col;
            fotopolla.color = col;

            prov.SetActive(true);
            prov2.SetActive(true);
            prov3.SetActive(true);
        }

        Destroy(textor);
        Destroy(textor2);
        Destroy(panel);

        int[] id = new int[3];
        id[0] = 2;
        id[1] = 5;
        id[2] = 8;

        float alpha = 0;
        int index = 0;

        bool[] si = new bool[3];
        si[0] = false;
        si[1] = false;
        si[2] = false;

        float[] numerosdemireda = new float[3];
        numerosdemireda[0] = 0;
        numerosdemireda[1] = 0;
        numerosdemireda[2] = 0;


        while (true)
        {
            yield return null;
            alpha = Mathf.MoveTowards(alpha, 1, 2 * Time.deltaTime);

            for (int i = 0; i < 9; i++)
            {
                bool siu = false;
                for (int a = 0; a < 3; a++)
                {
                    if (i == id[a]) { siu = true; index = a; break; }
                }

                if (Stats.GetChild(i).GetComponent<TextMeshProUGUI>()) {
                    col = new Vector4(col.w, col.x, col.y, alpha);
                    TextMeshProUGUI textamen = Stats.GetChild(i).GetComponent<TextMeshProUGUI>();
                    textamen.color = col;
                }
                else
                {
                    col2 = new Color(col2.r, col2.g, col2.b, alpha);
                    Image fotopolla = Stats.GetChild(i).GetComponent<Image>();
                    fotopolla.color = col2;
                }

                if (!siu) { continue; };

                numerosdemireda[index] = Mathf.MoveTowards(numerosdemireda[index], nums[index], ratios[index] * Time.deltaTime);
                Stats.GetChild(i).GetComponent<TextMeshProUGUI>().text = numerosdemireda[index].ToString("F0");

                if (numerosdemireda[index] == nums[index] && alpha == 1) { si[index] = true; }
            }

            bool acabao = true;

            for (int a = 0; a < 3; a++)
            {
                if (!si[a]) { acabao = false; break; }
            }

            if (acabao) { break; }
        }

    }

    string nombre2(int id)
    {
        string sex = "";
        switch (id)
        {
            case 0:
                sex = "Bajas partida: ";
                break;
            case 1:
                sex = "Bajas globales: ";
                break;
            case 2:
                sex = "Puntos: ";
                break;

        }

        return sex;
    }

    string nombre(int id)
    {
        string sex = "";
        switch (id)
        {
            case 2:
                sex = "Escopeta: ";
                break;
            case 3:
                sex = "Lanzagranadas: ";
                break;
            case 4:
                sex = "Deagle duales: ";
                break;
            case 5:
                sex = "Subfusil de plasma: ";
                break;
            case 6:
                sex = "Rifle: ";
                break;
            case 7:
                sex = "Sally && Mustang: ";
                break;
            case 8:
                sex = "Ballesta: ";
                break;
            case 9:
                sex = "Ejecuciones: ";
                break;

        }

        return sex;
    }

    IEnumerator Quetefollen()
    {
        Destroy(GameObject.Find("Spawners"));

        //gameObject.SendMessage("objetivoprop", 0.6f);
        yield return new WaitForSeconds(3.15f / 0.7f);
        reseteaenemigos();
        vidahomosexual = 100;
        usos = 5;
        mestoylevantandojoder = false;
        cargas = 3;
        enemigosactuales = 0;
        enemigosactualesesp = 0;

        normalizador nor = GetComponent<normalizador>();
        nor.armaslot = 0;

        for (int i = 0; i < nor.armaskit.Length; i++)
        {
            nor.armaskit[i] = nor.armaskitorig[i];
        }

        llevobolsa = false;
        detectao = false;
        civilmuerto = false;
        dineroasegurado = 0;
        asalto = false;
        enemigostochosalpha = 0;
        enemigosnormalesalpha = 0;
        enemigoscampersalpha = 0;
        enemigostochosbeta = 0;
        enemigosnormalesbeta = 0;

        enemigosactuales = 0;
        enemigosactualesesp = 0;

        enemigoscampersbeta = 0;
        enemigostochosdelta = 0;
        enemigosnormalesdelta = 0;
        enemigoscampersdelta = 0;
        enemigostochosgamma = 0;
        enemigosnormalesgamma = 0;
        enemigoscampersgamma = 0;
        enemigosactuales = 0;
        enemigosactualesesp = 0;
        Time.timeScale = 1;
        desfibrilador = 2;
        //puntostotales += puntos;


        para = null;
        muerto = false;
        if (activacursorgay != null) { StopCoroutine(activacursorgay); activacursorgay = null; }
        //SceneManager.LoadScene("prototiponivelesweno 1");
        StartCoroutine(fadergestor());
    }

    public IEnumerator resetear(bool sex)
    {
        //vidahomosexual = 100;
        if (!sex)
        {
            StartCoroutine(Quetefollen());
            yield break;
        }
        Destroy(GameObject.Find("Spawners"));
        Transform penis = GameObject.FindGameObjectWithTag("ELPLAYERJODER").transform.GetChild(0);
        penis.SendMessage("volvedzorras");
        Transform peniscam = Camera.main.transform;
        Vector3 last = penis.GetComponent<Muevo>().momentum;
        float mag = last.magnitude;
        float lul = penis.GetComponent<Muevo>().speed;
        if (mag > lul * 1.5f)
        {
            last = last.normalized;
            last *= lul * 1.5f;
        }

        if (sex)
        {
            Transform ins = Instantiate(moridor, penis.position, penis.rotation).transform;
            Destroy(penis.parent.gameObject);
            ins.GetComponent<moridor>().sex(peniscam.transform.rotation, last);
        }

        normalizador nor = GetComponent<normalizador>();
        nor.armaslot = 0;

        for (int i = 0; i < nor.armaskit.Length; i++)
        {
            nor.armaskit[i] = nor.armaskitorig[i];
        }

        gameObject.SendMessage("objetivoprop", 0.6f);
        yield return new WaitForSeconds(3.15f / 0.7f);
        reseteaenemigos();
        vidahomosexual = 100;
        usos = 5;
        mestoylevantandojoder = false;
        cargas = 3;
        enemigosactuales = 0;
        enemigosactualesesp = 0;

        llevobolsa = false;
        detectao = false;
        civilmuerto = false;
        dineroasegurado = 0;
        asalto = false;
        enemigostochosalpha = 0;
        enemigosnormalesalpha = 0;
        enemigoscampersalpha = 0;
        enemigostochosbeta = 0;
        enemigosnormalesbeta = 0;

        enemigosactuales = 0;
        enemigosactualesesp = 0;

        enemigoscampersbeta = 0;
        enemigostochosdelta = 0;
        enemigosnormalesdelta = 0;
        enemigoscampersdelta = 0;
        enemigostochosgamma = 0;
        enemigosnormalesgamma = 0;
        enemigoscampersgamma = 0;
        enemigosactuales = 0;
        enemigosactualesesp = 0;
        Time.timeScale = 1;
        //puntostotales += puntos;
        desfibrilador = 2;

        para = null;
        muerto = false;
        if (activacursorgay != null) { StopCoroutine(activacursorgay); activacursorgay = null; }
        //SceneManager.LoadScene("prototiponivelesweno 1");
        StartCoroutine(fadergestor());

    }

    void reseteaenemigos()
    {
        enemigosactuales = 0;
        enemigosactualesesp = 0;
    }

    public void actualizarvida()
    {
        if (para != null) { return; }
        if (vidahomosexual < 1)
        {
            para = StartCoroutine(resetear(true));
            muertes++;
        }

        if (UIgay == null) { UIgay = GameObject.Find("VidaUI").GetComponent<mostradorUI>(); }
        UIgay.SendMessage("actualizar");
    }

    public void carga(string sex)
    {
        StartCoroutine(cargamesta(sex));
    }

    IEnumerator cargamesta(string sex)
    {
        gameObject.SendMessage("objetivoprop", 1);
        GameObject Carga = GameObject.FindGameObjectWithTag("Granada");
        GameObject Boton = GameObject.FindGameObjectWithTag("TU MADRE ES GAY");

        trans = StartCoroutine(fundidosiu());
        trans2 = null;
        botones = false;

        Carga.SetActive(true);
        Boton.SetActive(false);

        yield return null;

        adelante = false;
        AsyncOperation a = SceneManager.LoadSceneAsync(sex);
        a.allowSceneActivation = false;
        TextMeshProUGUI texto = GameObject.Find("CargaTexto").GetComponent<TextMeshProUGUI>();

        float faker = 0;

        while (!a.isDone)
        {
            float uf = a.progress * 111.11f;

            faker += 30 * Time.deltaTime;
            faker = Mathf.Clamp(faker, 0, 99);

            texto.text = faker.ToString("F0") + "%";



            if (a.progress == 0.9f && faker == 99)
            {
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.7f);

        while (true)
        {
            Carga.SetActive(false);
            Boton.SetActive(true);
            if (!botones)
            {
                Animation[] penis = Boton.GetComponentsInChildren<Animation>();
                for (int i = 0; i < penis.Length; i++)
                {
                    penis[i].Play("fader2");
                }

                botones = true;
            }

            if (GetComponent<audiosglobal>().trans != null) { StopCoroutine(GetComponent<audiosglobal>().trans); }

            if (trans2 == null)
            {
                GetComponent<audiosglobal>().trans2 = StartCoroutine(gameObject.GetComponent<audiosglobal>().transwapa());
                trans2 = GetComponent<audiosglobal>().trans;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                adelante = true;
            }

            if (adelante) { break; }

            yield return null;
        }

        Image fun = GameObject.Find("Fundido").GetComponent<Image>();
        Color c = fun.color;
        c.a = 0;

        float timer = 0;

        adelante = false;

        while (true)
        {
            timer = Time.realtimeSinceStartup;
            yield return null;
            float timer2 = Time.realtimeSinceStartup - timer;

            c.a += 0.5f * Time.deltaTime;
            c.a = Mathf.Clamp(c.a, 0, 1);
            fun.color = c;
            if (c.a == 1) { break; }

        }

        if (activacursorgay != null) { StopCoroutine(activacursorgay); }

        a.allowSceneActivation = true;
        //adelante = true;

    }

    IEnumerator fundidosiu()
    {
        Image fun = GameObject.Find("Fundido").GetComponent<Image>();
        Color c = fun.color;
        c.a = 1;
        fun.color = c;

        float timer = 0;

        while (true)
        {
            timer = Time.realtimeSinceStartup;
            yield return null;
            float timer2 = Time.realtimeSinceStartup - timer;

            c.a -= 1 * Time.deltaTime;
            c.a = Mathf.Clamp(c.a, 0, 1);
            fun.color = c;
            if (c.a == 0) { break; }

        }
    }

    IEnumerator Record()
    {
        GameObject Record = GameObject.Find("Sacabo").transform.GetChild(0).GetChild(1).GetChild(3).gameObject;
        Record.SetActive(false);

        yield return new WaitWhile(() => !ahora);

        int pos = listastats.Count;

        int cont = 0;
        while (true)
        {
            if (cont == listastats.Count) { break; }

            if (puntos > listastats[cont].Putos)
            {
                pos = cont;
                string sex = "AAA";
                float sex2 = puntos;
                listastats.Insert(cont, new GestorgayStats(sex, sex2));
                break;
            }
            cont++;
        }

        if (listastats.Count > 10)
        {
            listastats.RemoveAt(listastats.Count - 1);
        }

        

        if (cont == listastats.Count) { Record.SetActive(false); 
            yield return new WaitWhile(() => !ahora);
            puntos = 0;
            yield break; }

        Record.SetActive(true);
        posranking = cont;

        TextMeshProUGUI[] textamens = new TextMeshProUGUI[3];
        Color[] coloresgays = new Color[3];
        Color[] coloresgaysorig = new Color[3];

        textamens[0] = Record.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textamens[1] = Record.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        textamens[2] = Record.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();

        cont++;
        textamens[0].text = "Enhorabuena, has superado el " + cont + "º mejor registro, introduce un nombre.";

        for (int i = 0; i < textamens.Length; i++)
        {
            coloresgays[i] = textamens[i].color;
            coloresgaysorig[i] = coloresgays[i];
            coloresgays[i].a = 0;
            textamens[i].color = coloresgays[i];
        }

        bool[] listo = new bool[3];
        float alpha = 0;

        yield return new WaitWhile(() => !ahora);

        puntos = 0;

        while (true)
        {
            yield return null;

            for (int i = 0; i < textamens.Length; i++)
            {
                coloresgays[i].a = Mathf.MoveTowards(coloresgays[i].a, coloresgaysorig[i].a, 2f * Time.deltaTime);
                textamens[i].color = coloresgays[i];
                if (coloresgays[i].a == coloresgaysorig[i].a) {

                    listo[i] = true;
                }
                else
                {
                    listo[i] = false;
                }
            }

            bool siu = true;
            for (int i = 0; i < textamens.Length; i++)
            {
                if (listo[i] == false) { siu = false; break; }
            }

            if (!siu) { continue; }
            break;

        }
    }

    public void Reseteogay()
    {
        //gameObject.SendMessage("objetivoprop", 0.6f);
        //yield return new WaitForSeconds(3.15f / 0.7f);
        reseteaenemigos();
        vidahomosexual = 100;
        usos = 5;
        mestoylevantandojoder = false;
        cargas = 3;
        enemigosactuales = 0;
        enemigosactualesesp = 0;

        normalizador nor = GetComponent<normalizador>();
        nor.armaslot = 0;

        for (int i = 0; i < nor.armaskit.Length; i++)
        {
            nor.armaskit[i] = nor.armaskitorig[i];
        }

        llevobolsa = false;
        detectao = false;
        civilmuerto = false;
        dineroasegurado = 0;
        asalto = false;
        enemigostochosalpha = 0;
        enemigosnormalesalpha = 0;
        enemigoscampersalpha = 0;
        enemigostochosbeta = 0;
        enemigosnormalesbeta = 0;

        enemigosactuales = 0;
        enemigosactualesesp = 0;

        enemigoscampersbeta = 0;
        enemigostochosdelta = 0;
        enemigosnormalesdelta = 0;
        enemigoscampersdelta = 0;
        enemigostochosgamma = 0;
        enemigosnormalesgamma = 0;
        enemigoscampersgamma = 0;
        enemigosactuales = 0;
        enemigosactualesesp = 0;
        //puntostotales += puntos;
        desfibrilador = 2;

        para = null;
        muerto = false;
       
    }

    void borrar()
    {
        PlayerPrefs.DeleteKey("slot");
    }

    public void cargar()
    {
        mierdas puta = new mierdas();
        Debug.Log("CARGAO");
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("slot"), puta);
        puta.carga();
    }

    public void guardar()
    {
        mierdas puta = new mierdas();
        puta.guarda();
        puta.accesible = true;
        Debug.Log("GUARDAO");
        PlayerPrefs.SetString("slot", JsonUtility.ToJson(puta));
    }  

    void Setear()
    {
        if (Resolucion.height > 0)
        {
            Screen.SetResolution(Resolucion.width, Resolucion.height, Ventana, Refresh);
        }

        AudioListener.volume = Controlador.volumenglobal;
        QualitySettings.SetQualityLevel(QualityLevel);
        if (Controlador.vsync) { QualitySettings.vSyncCount = 1; }
        else { QualitySettings.vSyncCount = 0; }
    }
}

public class mierdas
{
    public bool accesible = false;

    public float[] bajas = new float[10];
    //public float[] bajaspartidagay = new float[9];
    public float bajastotales;
    public float bajaspartida;
    public float muertes;

    //public float puntos;
    public float puntostotales;

    public List<GestorgayStats> listastats = new List<GestorgayStats>();

    public Resolution Resolucion;
    public int width;
    public int height;
    public Resolution Resolucionfail;
    public int QualityLevel = 5;
    // public static bool Fullscreen = true;
    public int Refresh = 60;
    public FullScreenMode Ventana;
    public bool vsync = false;
    public float sensibilidad = 1;
    public float volumenef = 1;
    public float volumenmusica = 1;
    public float volumenglobal = 0.3f;
    public int limitefps = 75;
    public int fov = 90;
    public int dificultad = 1;
    public bool ShowFPS = false;

    //public string sexual;

    public void guarda()
    {
        Controlador con = Controlador.ah;

        bajas = Controlador.bajas;
        //bajaspartidagay = Controlador.bajaspartidagay;
        bajastotales = Controlador.bajastotales;
        bajaspartida = Controlador.bajaspartida;
        muertes = Controlador.muertes;

        //puntos = Controlador.puntos;
        puntostotales = Controlador.puntostotales;

        listastats = con.listastats;

        width = Controlador.Resolucion.width;
        height = Controlador.Resolucion.height;
        QualityLevel = Controlador.QualityLevel;
        Refresh = Controlador.Refresh;
        Ventana = Controlador.Ventana;
        vsync = Controlador.vsync;
        sensibilidad = Controlador.sensibilidad;
        volumenef = Controlador.volumenef;
        volumenmusica = Controlador.volumenmusica;
        volumenglobal = Controlador.volumenglobal;
        limitefps = Controlador.limitefps;
        fov = Controlador.fov;
        dificultad = Controlador.dificultad;
        ShowFPS = Controlador.ShowFPS;

        //sexual = con.sexual;
    }
    public void carga()
    {
        if (!accesible) { return; }
        Controlador con = Controlador.ah;

        Controlador.bajas = bajas;
        //Controlador.bajaspartidagay = bajaspartidagay;
        Controlador.bajastotales = bajastotales;
        Controlador.bajaspartida = bajaspartida;
        Controlador.muertes = muertes;

        //Controlador.puntos = puntos;
        Controlador.puntostotales = puntostotales;

        con.listastats = listastats;
        if (width > 1)
        {
            Controlador.Resolucion.width = width;
            Controlador.Resolucion.height = height;
        }
        
        Controlador.QualityLevel = QualityLevel;
        Controlador.Refresh = Refresh;
        Controlador.Ventana = Ventana;
        Controlador.vsync = vsync;
        Controlador.sensibilidad = sensibilidad;
        Controlador.volumenef = volumenef;
        Controlador.volumenmusica = volumenmusica;
        Controlador.volumenglobal = volumenglobal;
        Controlador.limitefps = limitefps;
        Controlador.fov = fov;
        Controlador.dificultad = dificultad;
        Controlador.ShowFPS = ShowFPS;
        // con.sexual = sexual;
    }




}
