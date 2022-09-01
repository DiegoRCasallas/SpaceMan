using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }
    /*metodo que me dice si el collider ha sido atravezado por otro colider*/
     private void OnTriggerEnter2D(Collider2D collision)
     {
        /*SI ha sido atravezado por un collision que tenga el tag de Player*/
        if(collision.tag =="Player"){
            /*Traemos a PlayerControler y asignamos en la variable controller*/
            PlayerController controller= collision.GetComponent<PlayerController>();
            /*ejecutamos el metodo Die que esta en la instacia controller que hereda de playerController*/
            controller.Die();
        }
     }
}
