using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Escuadrones
{
    Alpha,
    Beta,
    Delta,
    Gamma
    
}

public class Spawner : MonoBehaviour {

    public bool camperos = false;
    public GameObject EnemigoNormal;
    public GameObject EnemigoTocho;
    public GameObject EnemigoCampero;
    public DirectionalWaypoint elwaypoint;
    public int aspawnear = 5;
    public int aspawnearinicialcamperos = 5;
    private float timingay = 0;
    private int camperosiniciales;
    public int maximotochos = 4;
    public int maximonormales = 15;
    public int maximocamperos = 7;
    public int normalesahora;
    public int tochosahora;
    public int camperosahora;
    public Escuadrones Escuadronesgays;
    private int spawneacerda;
    private bool asalto = false;
    public GameObject yolol;
    public bool rusheador = false;
    [HideInInspector]
    public bool aporesecerdofascista = false;
    private int enemigosgenerados = 0;
    public int enemigosahora = 0;
    private float tiempoespera = 0;
    public int tiempoasalto = 20; //tiempo de espera para que aparezca el primer enemigo después de que toda la escuadra haya morido
    private bool lehedao = true;
    public int enemigosescuadra = 7;
    private bool JODER = true;
    private bool guardao;

    void Start () {
        yolol = gameObject;
    }
	void aporelgay()
    {
        aporesecerdofascista = true;
    }
	// Update is called once per frame
	void Update () {
       
        if (rusheador && Controlador.asalto)
        {
            aporesecerdofascista = true;
        }      
        if (!Controlador.asalto && JODER)
        {
            guardao = aporesecerdofascista;
            aporesecerdofascista = false;
            JODER = false;
        }
        if (Controlador.asalto && !JODER)
        {
            aporesecerdofascista = guardao;
            JODER = true;
        }
        normalesahora = Controlador.enemigosnormalesalpha;
        tochosahora = Controlador.enemigostochosalpha;
        camperosahora = Controlador.enemigoscampersalpha;

        if (enemigosgenerados == enemigosescuadra && lehedao)
        {
            Invoke("aporelgay", 5.0f);
            asalto = true;
            lehedao = false;
        }
        if (enemigosahora == 0)
        {
            aporesecerdofascista = false;
        }
            if (enemigosahora == 0 && !lehedao)
        {
            enemigosgenerados = 0;
            aporesecerdofascista = false;
            tiempoespera = 0;
            lehedao = true;
            enemigosgenerados = 0;
            asalto = false;
        }
        if (!camperos)
        {
            spawneacerda = aspawnear;
        }
            if (camperos)
        {
            if (camperosiniciales >= maximocamperos)
            {
                spawneacerda = aspawnear;
            }
            else
            {
                spawneacerda = aspawnearinicialcamperos;
            }
        }
       
        timingay += Time.deltaTime;
        tiempoespera += Time.deltaTime;
        if (timingay >= spawneacerda)
        {
            
            if (Escuadronesgays == Escuadrones.Alpha)
            {
            int lol = Random.Range(0, 101);
            if (lol >= 70)
            {
                    if (!camperos)
                    {
                        if (Controlador.enemigostochosalpha < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochoalpha";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosalpha += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigosnormalesalpha < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normalalpha";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesalpha += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }

                    }

                }
            if (lol < 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigosnormalesalpha < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normalalpha";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesalpha += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigostochosalpha < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochoalpha";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosalpha += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                    }
                }
                
                if (camperos && Controlador.enemigoscampersalpha < maximocamperos)
                {
                    GameObject pollones = Instantiate(EnemigoCampero, transform.position, transform.rotation);
                    pollones.SendMessage("waypoint", elwaypoint);
                    pollones.GetComponent<ManageEnemyStatus>().tipo = "camperoalpha";
                    Controlador.enemigoscampersalpha += 1;
                    camperosiniciales += 1;
                    
                }
            }


            
            if (Escuadronesgays == Escuadrones.Beta)
            {
                int lol = Random.Range(0, 101);
                if (lol >= 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigostochosbeta < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochobeta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosbeta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigosnormalesbeta < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normalbeta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesbeta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }

                    }

                }
                if (lol < 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigosnormalesbeta < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normalbeta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesbeta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigostochosbeta < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochobeta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosbeta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                    }
                }

                if (camperos && Controlador.enemigoscampersbeta < maximocamperos)
                {
                    GameObject pollones = Instantiate(EnemigoCampero, transform.position, transform.rotation);
                    pollones.SendMessage("waypoint", elwaypoint);
                    pollones.GetComponent<ManageEnemyStatus>().tipo = "camperobeta";
                    Controlador.enemigoscampersbeta += 1;
                    camperosiniciales += 1;
                }
            }



            if (Escuadronesgays == Escuadrones.Delta)
            {
                int lol = Random.Range(0, 101);
                if (lol >= 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigostochosdelta < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochodelta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosdelta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigosnormalesdelta < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normaldelta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesdelta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }

                    }

                }
                if (lol < 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigosnormalesdelta < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normaldelta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesdelta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigostochosdelta < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochodelta";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosdelta += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                    }
                }

                if (camperos && Controlador.enemigoscampersdelta < maximocamperos)
                {
                    GameObject pollones = Instantiate(EnemigoCampero, transform.position, transform.rotation);
                    pollones.SendMessage("waypoint", elwaypoint);
                    pollones.GetComponent<ManageEnemyStatus>().tipo = "camperodelta";
                    Controlador.enemigoscampersdelta += 1;
                    camperosiniciales += 1;
                }
            }



            if (Escuadronesgays == Escuadrones.Gamma)
            {
                int lol = Random.Range(0, 101);
                if (lol >= 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigostochosgamma < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochogamma";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosgamma += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigosnormalesgamma < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normalgamma";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesgamma += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }

                    }

                }
                if (lol < 70)
                {
                    if (!camperos)
                    {
                        if (Controlador.enemigosnormalesgamma < maximonormales && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoNormal, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "normalgamma";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigosnormalesgamma += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                        else
                        if (Controlador.enemigostochosgamma < maximotochos && tiempoespera > tiempoasalto && enemigosahora < enemigosescuadra && !asalto)
                        {
                            GameObject pollones = Instantiate(EnemigoTocho, transform.position, transform.rotation);
                            pollones.SendMessage("waypoint", elwaypoint);
                            pollones.GetComponent<ManageEnemyStatus>().tipo = "tochogamma";
                            pollones.GetComponent<ManageEnemyStatus>().spawnergay = yolol;
                            Controlador.enemigostochosgamma += 1;
                            enemigosahora += 1;
                            enemigosgenerados += 1;
                        }
                    }
                }

                if (camperos && Controlador.enemigoscampersgamma < maximocamperos)
                {
                    GameObject pollones = Instantiate(EnemigoCampero, transform.position, transform.rotation);
                    pollones.SendMessage("waypoint", elwaypoint);
                    pollones.GetComponent<ManageEnemyStatus>().tipo = "camperogamma";
                    Controlador.enemigoscampersgamma += 1;
                    camperosiniciales += 1;
                }
            }











            timingay = 0;
              
        }
    }
}
