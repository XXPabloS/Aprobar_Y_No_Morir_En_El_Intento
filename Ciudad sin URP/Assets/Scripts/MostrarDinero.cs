using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MostrarDinero : MonoBehaviour
{
    [Header("Menu Manager")]
    MenuManager menuManager;

    public TextMeshProUGUI countText;

    public float Dinero;
    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Dinero = menuManager.peru;
        countText.text = "Cartera: " + Dinero.ToString();


    }
}
