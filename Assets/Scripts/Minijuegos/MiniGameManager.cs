using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    // Lista de minijuegos
    public GameObject[] minijuegos; // Minijuegos en el orden que se activar�n
    private int currentMinijuegoIndex = 0;

    void Start()
    {
        // Aseg�rate de que solo el primer minijuego est� activado al inicio
        ActivarMinijuego(currentMinijuegoIndex);
    }

    // M�todo que activa el siguiente minijuego
    public void CompletarMinijuego()
    {
        // Desactiva el minijuego actual
        minijuegos[currentMinijuegoIndex].SetActive(false);

        // Incrementa el �ndice del minijuego actual
        currentMinijuegoIndex++;

        // Verifica que haya m�s minijuegos disponibles
        if (currentMinijuegoIndex < minijuegos.Length)
        {
            // Activa el siguiente minijuego
            ActivarMinijuego(currentMinijuegoIndex);
        }
        else
        {
            // Si no hay m�s minijuegos, el jugador ha completado todos
            Debug.Log("Todos los minijuegos han sido completados.");
        }
    }

    // M�todo para activar un minijuego
    private void ActivarMinijuego(int index)
    {
        if (index >= 0 && index < minijuegos.Length)
        {
            minijuegos[index].SetActive(true);
        }
    }
}
