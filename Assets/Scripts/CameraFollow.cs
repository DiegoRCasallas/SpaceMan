using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variable Transform para perseguir el objetivo
    public Transform target;
    //Variavle para saber a que distancia serguir al objetivo
    public Vector3 offset = new Vector3(0.2f, 0.0f, -10f);
    //Tiempo de amortigucacion efecto para la camara
    public float dampingTime = 0.3f;
    //Velocidad a la oque tiene que ir la camara
    public Vector3 velocity = Vector3.zero;




    void Awake()
    {
        /*Frame que seran mostrados (60fps).Porque podría ir a más si 
        lo permite el la potncia del dispositivo*/
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera(true);
    }

    //para que la camara vuelva a la posicion acuando el personaje es reseteado
    public void ResetCameraPosition()
    {
        MoveCamera(false);
    }

    //partial hacer un movimiento suave y hacer un barrido cuando se muera
    void MoveCamera(bool smooth)
    {
        //Destino al oque queire ir la camara
        Vector3 destination = new Vector3(
        //objetivo seguir a target(objetivo)
        target.position.x ,
        /*seguimiento vertical .y*/
        target.position.y - offset.y,
         offset.z
        );

        if (smooth)
        {
            this.transform.position = Vector3.SmoothDamp(
                /*posicion actual camara*/
                this.transform.position,
                /*objetivo al que quiero ir*/
                destination,
                /*paso por referencia.pasamos nuestros scrip a uno propio de unity para que haga 
                calculos y nos retorne un valor a nuestro script*/
                ref velocity,
                /*tiempo animacion*/
                dampingTime
            );
        }
        else
        {
            this.transform.position = destination;
        }
    }


}
