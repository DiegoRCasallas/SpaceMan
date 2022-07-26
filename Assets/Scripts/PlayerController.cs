using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //  VARS MOV PERSONAJE

    //Fuerza de salto
    public float jumpForce = 6f;
    //Rigidbody es un tipo de variable que me permite controlar mi personaje
    Rigidbody2D rigidBody;
    //Var para identificar que elemtos son tipo suelo o plataforma
    public LayerMask groundMask;




    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame. 
    /*Se ejecuta hasta 60xseg*/
    void Update()
    {
        /*Si se pulsa tecla espacio o mouse click der*/
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    /*Awake sirve para despertar los objetos y cosas del juego antes 
    decimal que funione*/
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }
    //Metodo para que salete mi personaje
    void Jump()
    {
        /*JUMP solo si esta tocando el suelo*/
        if (IsTouchingTheGround())
        {
            /*Add force recbie dos parametro(hacia_donde_y_valor, tipo_de_fuerza_aplicada)*/
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    //Metodo que me dice si el personaje está tocando el suelo(Ground)
    bool IsTouchingTheGround()
    {
        //Physics objeto que tiene un metodo(Raycast) que dispara rayos invisibles
        if(Physics2D.Raycast(
            /*Posicion personaje*/this.transform.position,
            /*hacia donde disparamos el rayo(abajo)*/Vector2.down,
            /*Distancia maxima del rayo desde
             el centro del personaje (2mts)*/2f,
            /*contra que debe chocar el rayo(Ground)*/groundMask))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    
}
