using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovimientoPerso : MonoBehaviour
{

    private Rigidbody rb;
    //velocidad personaje
    [Range(1,100)]
    public float velocidadjug = 2;
    //rotacion personaje
    public float horSpeed = 10.0f;
    public float vertSpeed = 10.0f;
    //limitar rotacion
    public float minVertical = -50.0f;
    public float maxVertical = 50.0f;
    private float vertical = 0;

    [Header("Menu Manager")]
    MenuManager menuManager;

     [SerializeField]
    Transform[] Positions;

    Transform SpawnPos;
     Transform PosicionesMain;

    AudioSource audioData;

    private RigidbodyConstraints originalConstraints;

    public Animator anim;

    public GameObject jugador;

    public KeyCode createKey = KeyCode.P;

    public GameObject TextObject;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();

        //originalConstraints = rb.constraints;

        SpawnPos = Positions[0]; //posicion Inicial jugador
        audioData = GetComponent<AudioSource>();

        menuManager = FindObjectOfType<MenuManager>();

        anim = gameObject.GetComponent<Animator>();

        menuManager.cargarnpc();

        jugador.transform.position = PosicionesMain.position; //mover jugador posicion inicial

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(createKey))
        {
            Menupausa();
        }


    }

     public void mercadona()
    {
        PosicionesMain = Positions[3]; //posicion jugador
        //jugador.transform.position = PosicionesMain.position;
    }

    public void inicio()
    {
        PosicionesMain = Positions[0]; //posicion  jugador
        //jugador.transform.position = PosicionesMain.position;
    }

    public void globoP()
    {
        PosicionesMain = Positions[2]; //posicion  jugador
       //jugador.transform.position = PosicionesMain.position;
    }

    public void llaves()
    {
        PosicionesMain = Positions[1]; //posicion  jugador
        //jugador.transform.position = PosicionesMain.position;
    }

     private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "coches":
                jugador.transform.position = SpawnPos.position; //mover jugador posicion inicial
                break;
            case "SuSuelo":
                jugador.transform.position = SpawnPos.position; //mover jugador posicion inicials
                audioData.Play(0);
                break;
            case "CheckPoint":
                //check = true;
                SpawnPos = Positions[1]; //posicion Inicial jugador
                break;
            case "Finish":
               velocidadtextos();
                break;
            case "Dinero":
                menuManager.AnadirDinero();
                menuManager.cartera();
                break;

            default:
                break;
        }
    }

    void FixedUpdate () {

        //Capturo el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal") * velocidadjug;
        float movimientoV = Input.GetAxis("Vertical") * velocidadjug;

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidadjug
        //Vector3 movimiento = new Vector3(movimientoH * velocidadjug, 0.0f, movimientoV * velocidadjug);

        transform.Translate(movimientoH * Time.deltaTime, 0, movimientoV * Time.deltaTime);

        //Aplico ese movimiento al RigidBody del jugador
        // rb.AddForce(movimiento);

        //rotacion personaje
        float horizontal = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * horSpeed;
        
        vertical -= vertSpeed * Input.GetAxis("Vertical");
        vertical = Mathf.Clamp(vertical, minVertical, maxVertical);

        if (movimientoV != 0 || movimientoH != 0)
        {
            transform.localEulerAngles = new Vector3(vertical, horizontal, 0); 
            anim.SetBool("Quieto", false);
        }
        else{
            anim.SetBool("Quieto", true);
        }
        
    }

    public void cambiocasero(){
        menuManager.dineroLlaves();
    }
    public void cambiocas(){
        menuManager.cambiocas();
    }
    public void cambiowilly(){
        menuManager.cambiowilly();
    }

    public void cambioalberto(){
        menuManager.cambioalb();
    }

    public void cambiorodri(){
        menuManager.cambiorod();
    }

    public void cambiochema(){
        menuManager.cambioache();
    }

    public void cambiomari(){
        menuManager.cambiomar();
    }

     public void velocidadtextos()
    {
        //parar movimiento jugador
        velocidadjug = 0;
    }

    public void velocidadNormal()
    {
        //velocidad jugador
        velocidadjug = 2;
    }

    public void Velocidad()
    {
        //velocidad jugador mapa esquivar coches
        velocidadjug = 20;
    }
    public void Velocidadsuper()
    {
        //velocidad jugador mapa supermercado
        velocidadjug = 2;
    }

    public void TpMisionUno()
    {
        SceneManager.LoadScene("Scene Mision1");
    }

    public void TpMisionDos()
    {
        SceneManager.LoadScene("juego2");
    }

    public void TpMisionTres()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void TpMisionCuatro()
    {
        SceneManager.LoadScene("trilero");
    }

    public void TpCreditosFinales()
    {
        SceneManager.LoadScene("Creditos");
    }

     public void TpMenuInicio()// volver al menu principal
    {
        SceneManager.LoadScene("Scene Menu");
    }

    public void TpFinish()
    {
       SceneManager.LoadScene("Main Scene"); // El nombre de la escena que desea cambiar
    }

    public void Menupausa()// pausar el juego
    {
        velocidadtextos();
        TextObject.SetActive(true);
    }

     public void MenupausaOff()// reanudar el juego
    {
        velocidadNormal();
        TextObject.SetActive(false);
    }

    public void Quit()// cerrar el juego
    {
        Application.Quit();
    }

    public void DevolverLlaves()
    {
        menuManager.vueltallaves();
        velocidadNormal();
        llaves();
    }

    public void Devolverninos()
    {
        menuManager.vueltanino();
        
    }
  

     
}
