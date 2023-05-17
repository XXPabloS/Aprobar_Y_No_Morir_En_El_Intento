using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    int Pbola;

    public GameObject pelota;

    // Start is called before the first frame update
    void Start()
    {

        Pbola = Random.Range(1,3);

          switch (Pbola)
          {
            case 0:
                transform.position = new Vector3(-100, 116, 538);
                break;
            case 1:
               transform.position = new Vector3(-421, 116, 538);
                break;
            case 2:
                transform.position = new Vector3(-726, 116, 538);
                break;
            default:
                break;
          }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
