using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovimientoPerso : MonoBehaviour
{

    private Rigidbody rb;
    //velocidad personaje
    [Range(1,100)]
    public float velocidad = 1;
    //rotacion personaje
    public float horSpeed = 10.0f;
    public float vertSpeed = 10.0f;
    //limitar rotacion
    public float minVertical = -50.0f;
    public float maxVertical = 50.0f;
    private float vertical = 0;

     [SerializeField]
    Transform[] Positions;

    Transform SpawnPos;

    AudioSource audioData;

    public GameObject TextObject;

    private RigidbodyConstraints originalConstraints;

    public Animator anim;

     public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();

        //originalConstraints = rb.constraints;

        SpawnPos = Positions[0]; //posicion Inicial jugador
        audioData = GetComponent<AudioSource>();

        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                activarCanvas();
                break;
            default:
                break;
        }
    }

    void FixedUpdate () {

        //Capturo el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal") * velocidad;
        float movimientoV = Input.GetAxis("Vertical") * velocidad;

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
        //Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);

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

     public void velocidadtextos()
    {
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        velocidad = 0;
    }

    public void velocidadNormal()
    {
        //rb.constraints = originalConstraints;
        velocidad = 1;
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

    public void TpFinish()
    {
       SceneManager.LoadScene("Main Scene"); // El nombre de la escena que desea cambiar
    }

    public void activarCanvas(){
        TextObject.SetActive(true);
    }

    public void desactivarCanvas(){
        TextObject.SetActive(false);
    }

     
}
