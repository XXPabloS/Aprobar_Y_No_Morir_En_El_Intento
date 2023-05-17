using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerMainScene : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody rb;

    private float movementX;

    private float movementY;

    public GameObject jugador;

    [SerializeField]
    Transform[] Positions;

    Transform SpawnPos;
    Transform PosicionesMain;

    Transform TextoPos;

    AudioSource audioData;

    private RigidbodyConstraints originalConstraints;

    //public VariableJoystick variableJoystick;

    public Animator anim;

    void Start()
    {
        gameObject.tag = "Player";

        rb = GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;

        SpawnPos = Positions[0]; //posicion Inicial jugador
        jugador.transform.position = PosicionesMain.position; //mover jugador posicion inicial


        audioData = GetComponent<AudioSource>();

        anim = gameObject.GetComponent<Animator>();
           
    }

    void FixedUpdate()
    {
        /*rb.velocity =
            new Vector3(variableJoystick.Vertical * speed,
                rb.velocity.z,
                variableJoystick.Horizontal * speed * -1);

        if (variableJoystick.Vertical != 0 || variableJoystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("Quieto", false);
        }
        else{
            anim.SetBool("Quieto", true);
        }*/

        //Capturo el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
        Vector3 movimiento = new Vector3(movimientoH * speed, 0.0f, movimientoV * speed);

        if (movimientoV != 0 || movimientoH != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("Quieto", false);
        }
        else{
            anim.SetBool("Quieto", true);
        }

        //Aplico ese movimiento al RigidBody del jugador
        rb.AddForce(movimiento);
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Mision1":
                SceneManager.LoadScene("Scene Mision1");

                //Ahora lo hace el npc
                break;
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
                SceneManager.LoadScene("Main Scene"); // El nombre de la escena que desea cambiar
                break;
            default:
                break;
        }
    }

    public void mercadona()
    {
        PosicionesMain = Positions[3]; //posicion Inicial jugador
        jugador.transform.position = PosicionesMain.position;
    }

    public void inicio()
    {
        PosicionesMain = Positions[0]; //posicion Inicial jugador
        jugador.transform.position = PosicionesMain.position;
    }

    public void globo()
    {
        PosicionesMain = Positions[2]; //posicion Inicial jugador
       jugador.transform.position = PosicionesMain.position;
    }

    public void llaves()
    {
        PosicionesMain = Positions[1]; //posicion Inicial jugador
        jugador.transform.position = PosicionesMain.position;
    }

    public void velocidadtextos()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void velocidadNormal()
    {
        rb.constraints = originalConstraints;
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
}
