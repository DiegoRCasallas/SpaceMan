using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    /*variable que contiene el estado predeterminado del juego*/
    public GameState currenGameState = GameState
    .menu;

    //utilizando el patron singleton que me permitira evitar la creacion de 1 objeto por esta clase (GameManager)
    public static GameManager sharedInstance;

    void Awake()
    {
        /*si la instacia no ha sido inicializada se asigna a this*/
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }


    }




    /*El manager es el encargardo de avisar si el juego esta puasado, en marcha, si estamos en el menú
    e indica las reglas que gobierna el juego en cada uno de esos estados*/
    /*Crearemos 3 metodos diferentes (iniciar partida, finalizar partida(muere), irmenuprincipal*/
    void Start()
    {

    }

    void Update()
    {
        /*cond permite inicializar el juego, camciamos a estado inGame*/
        if (Input.GetButtonDown("Start"))
        {
            StartGame();
        }
        else if (Input.GetButtonDown("Pause"))
        {
            BackToMenu();
        }

            
    }




    /*inicia el juego*/
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }
    /*finaliza el modo juego*/
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    /*Regresa al menu*/
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }







    /*unico Metodo para cambiar el estado  del juego(singleton)*/
    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO: colocal la logica dle menu

        }
        else if (newGameState == GameState.inGame)
        {
            //TODO: hay que preparar la escenapara jugar

        }
        else if (newGameState == GameState.gameOver)
        {
            //TODO:perparar el jeugo para el game over
        }

        this.currenGameState = newGameState;
    }

}