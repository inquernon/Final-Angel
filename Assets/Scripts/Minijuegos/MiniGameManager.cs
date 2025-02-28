using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    // Lista de minijuegos
    public GameObject[] minijuegos; // Minijuegos en el orden que se activarán
    private int currentMinijuegoIndex = 0;

    void Start()
    {
        // Asegúrate de que solo el primer minijuego esté activado al inicio
        ActivarMinijuego(currentMinijuegoIndex);
    }

    // Método que activa el siguiente minijuego
    public void CompletarMinijuego()
    {
        // Desactiva el minijuego actual
        minijuegos[currentMinijuegoIndex].SetActive(false);

        // Incrementa el índice del minijuego actual
        currentMinijuegoIndex++;

        // Verifica que haya más minijuegos disponibles
        if (currentMinijuegoIndex < minijuegos.Length)
        {
            // Activa el siguiente minijuego
            ActivarMinijuego(currentMinijuegoIndex);
        }
        else
        {
            // Si no hay más minijuegos, el jugador ha completado todos
            Debug.Log("Todos los minijuegos han sido completados.");
        }
    }

    // Método para activar un minijuego
    private void ActivarMinijuego(int index)
    {
        if (index >= 0 && index < minijuegos.Length)
        {
            minijuegos[index].SetActive(true);
        }
    }
}
