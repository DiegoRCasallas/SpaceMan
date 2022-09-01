using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /*Algoritmo que permite generar bloques a lo largo del nivel*/
    /*anade fragmento de nivel*/
    /*desaparece bloque de nivel que van quedando atrás*/

    /*Singleton para el generador de niveles*/
    public static LevelManager sharedInstance;

    //Listas que contendrán los bloque de nivel (LevelBlock)
    public List<LevelBlock>allTheLevelBlocks= new List<LevelBlock>();
    public List<LevelBlock>currentLevelBlocks= new List<LevelBlock>();
   
    public Transform initialPosition;
    void Awake()
    {
        if (sharedInstance == null)
        {
           sharedInstance=this;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //llamada para generar los bloques iniciales
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddLevelBlock()
    {

    }
    public void RemoveLevelBlock()
    {

    }
    public void RemoveAllLevelBlocks()
    {

    }
    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {
            AddLevelBlock();

        }

    }
}
