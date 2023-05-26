using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiosScena : MonoBehaviour
{
    public int numScene; // Nombre de la escena a la que se cambiará

    private bool dentroDelArea; // Indica si el jugador está dentro del área

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Comprueba si el jugador ha entrado en el área
        {
            SceneManager.LoadScene(numScene);
        }
    }   

   
}
