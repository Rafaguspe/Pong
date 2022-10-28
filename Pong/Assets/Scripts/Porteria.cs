using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porteria : MonoBehaviour
{
    //detecto si la bola atraviesa la porteria

    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.name == "Bola")
        {
            //Si es la porter�a izquierda
            if (this.name == "Izquierda")
            {
                //Cuento el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Derecha");
            }
            //Si es la porter�a derecha
            else if (this.name == "Derecha")
            {
                //Cuento el gol y reinicio la bola
                bola.GetComponent<Bola>().reiniciarBola("Izquierda");
            }
        }
    }
}