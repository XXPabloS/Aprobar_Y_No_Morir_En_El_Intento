using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform jugador;

    public Vector3 offset;

    //Smooth factor se encarga d ela rotacion de la camara
    public float smoothFactor = 0.5f;

    //Esto se encarga de checkear si la camara mira al target o no
    public bool lookAtTarget = false;

    //[SerializeField]
    //Transform[] Positions;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = jugador.transform.position + offset;
        Vector3 newPosition = jugador.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        //Rotacion de la camara
        if (lookAtTarget)
        {
            transform.LookAt(jugador);
        }
    }
}
