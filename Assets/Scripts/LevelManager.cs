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
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    public Transform levelStartPosition;
    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
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
        /*Agregar un nuevo bloque Aleatorio*/
        int randomIdx = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock block;

        Vector3 spawnPosition = Vector3.zero;

        /* Si no se ha añadido ningun bloque, agregamos el bloque que
         esta dentro de all the levelblocks[0] */
        if (currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlocks[0]);
            spawnPosition = levelStartPosition.position;

        }
        else
        {
            block = Instantiate(allTheLevelBlocks[randomIdx]);
            spawnPosition = currentLevelBlocks
            [currentLevelBlocks.Count - 1].exitPoint.position;
        }


       /* Establecer el padre del bloque en la transformación del LevelManager. */
       
        block.transform.SetParent(this.transform, false);


        /*hacer conincidir el punto de salida de uno con el punto de entrada del otro
        en principio concviven en un espacio diferente, similar al cambio de ubicacion usando el plano cartesiano con ejes x,y
        restamos el punto de */
        Vector3 correction = new Vector3(
            /* eje x */
            spawnPosition.x - block.starPoint.position.x,
            /*eje y*/
            spawnPosition.y - block.starPoint.position.y,
            0
        );

        block.transform.position = correction;
        /*agremaos a la lista el objeto LevelBlcck block*/
        currentLevelBlocks.Add(block);

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
