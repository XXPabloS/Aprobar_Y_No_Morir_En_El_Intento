using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject gamer;
    public GameObject menu;
    public GameObject alberto, alberto2, chema, chema2, marisa, marisa2, nino, casero, casero2, casero3, willyrex, willyrex2, rodrigo, rodrigo2;
    public float peru= 0;

    private bool a  = false, b = false, c = false, d = false, e = false, f = false , g = false;

    SkinsChanger skinchanger;

    public Material materialmenu;

   public MovimientoPerso MovimientoPerso;

    // Start is called before the first frame update
    void Start()
    {
        //Le indico que no se destruya al cargar otra escena
        DontDestroyOnLoad(gamer);
        DontDestroyOnLoad(menu);
        Debug.Log("nacio");

        Renderer renderer = GetComponent<Renderer>();

        skinchanger = FindObjectOfType<SkinsChanger>();
        materialmenu = skinchanger.material;


    }

    public void cargarnpc(){

        MovimientoPerso = FindObjectOfType<MovimientoPerso>();

        alberto = GameObject.Find("Alberto");
        alberto2 = GameObject.Find("AlbertoConLlaves");

        chema = GameObject.Find("Chema");
        chema2 = GameObject.Find("ChemaMisionHecha");

        marisa = GameObject.Find("Marisa");
        marisa2 = GameObject.Find("MarisaConNiño");
        nino = GameObject.Find("niño");

        casero = GameObject.Find("NPCCasero");
        casero2 = GameObject.Find("NPCCaseroLL");
        casero3 = GameObject.Find("NPCCaserodinero");

        willyrex = GameObject.Find("WillyRex");
        willyrex2 = GameObject.Find("WillyRexCriptoBro");

        rodrigo = GameObject.Find("Rodrigo");
        rodrigo2 = GameObject.Find("RodrigoHablado");
    }

    // Update is called once per frame
    void Update()
    {

        if(a == true){
            alberto.SetActive(false);
            alberto2.SetActive(true);
            MovimientoPerso.llaves();
            //Debug.Log("alberto");
        }else{
            alberto.SetActive(true);
            alberto2.SetActive(false);
           // Debug.Log("alberto1");
        }
        if(b == true){
            chema.SetActive(false);
            chema2.SetActive(true);
            MovimientoPerso.globoP();
            //Debug.Log("Chema");
        }else{
            chema.SetActive(true);
            chema2.SetActive(false);
            //Debug.Log("Chema1");
        }
        if(c == true){
            marisa.SetActive(false);
            marisa2.SetActive(true);
            nino.SetActive(true);
            MovimientoPerso.mercadona();
            //Debug.Log("Marisa");
        }else{
            marisa.SetActive(true);
            marisa2.SetActive(false);
            nino.SetActive(false);
            //Debug.Log("Marisa1");
        }
        if(d == true){
            casero.SetActive(false);
            casero2.SetActive(true);
            //Debug.Log("casero");
        }else{
            casero.SetActive(true);
            casero2.SetActive(false);
            //Debug.Log("casero1");
        }
        if(e == true){
            willyrex.SetActive(false);
            willyrex2.SetActive(true);
            //Debug.Log("Willyrex");
        }else{
            willyrex.SetActive(true);
            willyrex2.SetActive(false);
           // Debug.Log("Willyrex1");
        }

        if(f == true){
            casero2.SetActive(false);
            casero3.SetActive(true);
            //Debug.Log("casero2");
        }else{
            casero3.SetActive(false);
            //Debug.Log("casero12");
        }

        if(g == true){
            rodrigo.SetActive(false);
            rodrigo2.SetActive(true);
            //Debug.Log("Rodrigo");
        }else{
            rodrigo.SetActive(true);
            rodrigo2.SetActive(false);
            //Debug.Log("Rodrigo1");
        }
    }

    public void cambioalb(){
        a = true;
    }

    public void cambioache(){
        b = true;
    }

    public void cambiomar(){
        c = true;  
    }

    public void cambiocas(){
       d = true; 
    }

    public void cambiowilly(){
        e = true;
    }

    public void cambiocas2(){
        f = true;
    }

    public void cambiorod(){
        g = true;
    }

    public void dineroLlaves(){
        Debug.Log("DineroLLaves");
        if(a == true && peru >= 100){// laves y dinero
            cambiocas2();
            Debug.Log("Good ending");
        }else{
            SceneManager.LoadScene("BadEnding"); // El nombre de la escena que desea cambiar
            Debug.Log("BadEnding");
        }
    }

    public void cartera()
    {
        Debug.Log("cartera: " + peru);
    }

    public void AnadirDinero()
    {
       peru = peru + 1; //￦
       Debug.Log("dinero A?dido");
    }

    public void tirardinero()
    {
       peru = peru - 5;
       Debug.Log("dinero A?dido");
    }

    public void ganar5()
    {
       peru = peru + 5;
       Debug.Log("dinero A?dido");
    }

    public void ganar10()
    {
       peru = peru + 10;
       Debug.Log("dinero A?dido");
    }

    public void ganar15()
    {
       peru = peru + 15;
       Debug.Log("dinero A?dido");
    }

    public void ganar100()
    {
       peru = peru + 100;
       Debug.Log("dinero A?dido");
    }

    public void skinBar()
    {
       peru = peru - 100;
       Debug.Log("dinero A?dido");
    }

    public void skinDef()
    {
       peru = peru - 50;
       Debug.Log("dinero A?dido");
    }

    public void SkinOtaku()
    {
       peru = peru - 60;
       Debug.Log("dinero A?dido");
    }

    public void Skinnegro()
    {
        peru = peru - 30;
        Debug.Log("dinero A?dido");
    }

    public void SkinsPalmas()
    {
        peru = peru - 15;
        Debug.Log("dinero A?dido");
    }

    public void SkinCreeper()
    {
        peru = peru - 25;
        Debug.Log("dinero A?dido");
    }

  public void vueltallaves()
    {
        peru = peru + 30;
        Debug.Log("dinero A?dido");
    }

     public void vueltanino()
    {
        peru = peru + 40;
        Debug.Log("dinero A?dido");
    }

    public void globo()
    {
        peru = peru + 10;
        Debug.Log("dinero A?dido");
    }
}
