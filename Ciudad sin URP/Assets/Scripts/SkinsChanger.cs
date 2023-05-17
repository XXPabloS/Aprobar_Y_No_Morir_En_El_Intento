using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsChanger : MonoBehaviour
{
    public GameObject Object;

    //public Renderer rend;

    //public Material[] material;

    //public int x;
    public Material material;

    public Material materialDefault;

    public Material materialBarsa;

    public Material materialOtaku;

    public Material materialnegro;

    public Material materialLasPalmas;

    public Material materialCreeper;

    [Header("Menu Manager")]
    MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        // Obtener la referencia al componente Renderer del objeto
        Renderer renderer = GetComponent<Renderer>();

        GetComponent<Renderer>().material = menuManager.materialmenu;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PonerMatDefault()
    {
        // Cambiar el material del objeto
        GetComponent<Renderer>().material = materialDefault;
        menuManager.skinDef();
        //Object.Material = materialDefault;
        // Object.GetComponent<MeshRenderer>().material = materialDefault;
    }

    public void PonerMaterialBarsa()
    {
        GetComponent<Renderer>().material = materialBarsa;
        menuManager.skinBar();
        menuManager.materialmenu = GetComponent<Renderer>().material;
        //Object.Material = materialBarsa;
        //Object.GetComponent<MeshRenderer>().material = materialBarsa;
    }

    public void PonerMatOtaku()
    {
        GetComponent<Renderer>().material = materialOtaku;
        menuManager.SkinOtaku();
        menuManager.materialmenu = GetComponent<Renderer>().material;
        //Object.Material = materialOtaku;
        //Object.GetComponent<MeshRenderer>().material = materialOtaku;
    }

    public void PonerMatNegro()
    {
        GetComponent<Renderer>().material = materialnegro;
        menuManager.Skinnegro();
        menuManager.materialmenu = GetComponent<Renderer>().material;
        //Object.Material = materialnegro;
        //Object.GetComponent<MeshRenderer>().material = materialnegro;
    }

    public void PonerMatLasPalmas()
    {
        GetComponent<Renderer>().material = materialLasPalmas;
        menuManager.SkinsPalmas();
        menuManager.materialmenu = GetComponent<Renderer>().material;
        //Object.Material = materialLasPalmas;
        //Object.GetComponent<MeshRenderer>().material = materialLasPalmas;
    }

    public void PonerMatCreeper()
    {
        GetComponent<Renderer>().material = materialCreeper;
        menuManager.SkinCreeper();
        menuManager.materialmenu = GetComponent<Renderer>().material;
        //Object.Material = materialCreeper;
        //Object.GetComponent<MeshRenderer>().material = materialCreeper;
    }
}
