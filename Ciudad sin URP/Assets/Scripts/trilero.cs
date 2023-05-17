using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;

public class trilero : MonoBehaviour
{

    public float apostar = 0, Dinero = 0;

    public TextMeshProUGUI countText;

    public GameObject TextObject, PausaObject, ruleta;

    public KeyCode createKey = KeyCode.P;

    public string caer = "";

    public string ludo = "verde";

    [Header("Menu Manager")]
    MenuManager menuManager;

    [SerializeField] private Button uiSpinButton;
    //[SerializeField] private Text uiSpinButtonText;
    [SerializeField] private PickerWheel pickerWheel;
    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();

    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(createKey))
        {
            Menupausa();
        }

        Dinero = menuManager.peru;
        countText.text = "Cartera: " + Dinero.ToString();//mostrar dinero del jugador
    }

    public void tirar(){

        pickerWheel.OnSpinStart (() =>  {
            Debug.Log ("Spin start...");
            menuManager.tirardinero();
        });
        pickerWheel.OnSpinEnd(WheelPiece => {
            Debug.Log("Spin end :");
            apostar = WheelPiece.Amount;
            ganar();
        });
        pickerWheel.Spin();
    }
    public void ganar(){

        switch (apostar)
        {
            case 5:
                menuManager.ganar5();
                menuManager.cartera();
                break;
            case 10:
                menuManager.ganar10();
                menuManager.cartera();
                break;
            case 15:
                menuManager.ganar15();
                menuManager.cartera();
                break;
            case 100:
                menuManager.ganar100();
                menuManager.cartera();
                break;
            default:
                break;
        }
        
    }

    public void Menupausa()
    {
        PausaObject.SetActive(true);
    }

     public void MenupausaOff()
    {
        PausaObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

     public void TpMenuInicio()
    {
        SceneManager.LoadScene("Scene Menu");
    }
    
    public void TpCiudad()
    {
        SceneManager.LoadScene("Main Scene");
    }


}
