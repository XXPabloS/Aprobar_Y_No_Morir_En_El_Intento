using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarCanvas : MonoBehaviour
{

    public GameObject TextObject;
    public GameObject PickUp;
    public bool a = false;
    public MovimientoPerso MovimientoPerso;
    float vel=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (a == true){
            switch (other.tag)
            {
            
                case "Player":
                    activarCanvas();
                break;
        
                default:
                break;
            }
        }
        
    }

    public void activarCanvas(){
        TextObject.SetActive(true);
    }

    public void desactivarCanvas(){
        TextObject.SetActive(false);
    }

    public void activarObjecto()
    {
        PickUp.SetActive(false);
    }
    public void desactivarObjeto()
    {
        PickUp.SetActive(false);
    }
}
