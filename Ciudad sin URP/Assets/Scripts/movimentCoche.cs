using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movimentCoche : MonoBehaviour
{
    [Header("objetos")]
    private Rigidbody rb;

    [Header("movimiento Jugador")]
    public float speed = 80;

    private float movementX;

    private float movementY;

    [Header("Canvas")]
    private int count;

    [Header("Menu Manager")]
    MenuManager menuManager;

    public TextMeshProUGUI countText;

     public KeyCode createKey = KeyCode.P;

     public GameObject TextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

    }

    void Update(){
         if (Input.GetKeyDown(createKey))
        {
            Menupausa();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Entregas: " + count.ToString();
    }

    void FixedUpdate()
    {
       /* Vector3 direction =
            Vector3.forward * variableJoystick.Horizontal +
            Vector3.left * variableJoystick.Vertical; //cambio joystick
        rb
            .AddForce(direction * speed * Time.fixedDeltaTime,
            ForceMode.VelocityChange); //cambio joystick*/


        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "PickUp":
                other.gameObject.SetActive(false);
                count = count + 1;
                menuManager = FindObjectOfType<MenuManager>();
                menuManager.globo();
                menuManager.cartera();
                SetCountText();

                break;
            case "Finish":
                SceneManager.LoadScene("Main Scene"); // El nombre de la escena que desea cambiar
                break;
            default:
                break;
        }
    }

    public void velocidadtextos()
    {
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        speed = 0;
    }

    public void velocidadNormal()
    {
        //rb.constraints = originalConstraints;
        speed = 80;
    }

     public void TpMenuInicio()
    {
        SceneManager.LoadScene("Scene Menu");
    }

     public void Menupausa()
    {
        velocidadtextos();
        TextObject.SetActive(true);
    }

     public void MenupausaOff()
    {
        velocidadNormal();
        TextObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
