using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_zombies : MonoBehaviour
{
 public GameObject objetoAEspawnear;

    void Start()
    {
        // Llama al método "SpawnObjeto" cada 3 segundos después de 1 segundo de espera inicial
        InvokeRepeating("SpawnObjeto", 1f, 3f);
    }

    void SpawnObjeto()
    {
        // Crea una instancia del objeto a spawnear en la posición actual del spawner
        Instantiate(objetoAEspawnear, transform.position, Quaternion.identity);
    }
}