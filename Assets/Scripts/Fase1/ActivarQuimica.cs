using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarQuimica : MonoBehaviour
{
    public Scrollbar scrollbar; // Referencia al Scrollbar en Unity
    public float baseResistance = 0.3f; // Resistencia base
    public float resistanceGrowth = 0.05f; // Incremento exponencial de resistencia
    public float resistanceGrowth2 = 0.1f; // Incremento exponencial de resistencia
    public float increaseRate = 0.1f; // Velocidad de subida al presionar la tecla
    public float targetValue = 0.92f; // Valor mínimo para la zona verde
    public float greenZoneDuration = 3f; // Tiempo necesario en la zona verde
    public KeyCode inputKey = KeyCode.Z; // Tecla para interactuar
    public KeyCode acceptKey = KeyCode.X; // Tecla para aceptar
    public GameObject botonX;
    public GameObject panel; // Panel actual
    public GameObject nextPanel; // Siguiente panel

    private float greenZoneTimer = 0f; // Temporizador para el tiempo en la zona verde
    private bool gameWon = false; // Verificar si el juego fue completado
    private bool nextPanelReady = false; // Indica si se puede pasar al siguiente panel

    void Start()
    {
        scrollbar.value = 0;
    }

    void Update()
    {
        if (gameWon)
        {
            // Detectar si se presiona la tecla para avanzar
            if (Input.GetKeyDown(acceptKey) && nextPanelReady)
            {
                panel.SetActive(false); // Desactiva el panel actual
                nextPanel.SetActive(true); // Activa el siguiente panel
                Debug.Log("Avanzando al siguiente panel...");
            }
            return;
        }

        float currentResistance = baseResistance;

        // Resistencia exponencial: aumenta según el valor actual del Scrollbar
        if (scrollbar.value > 0.3f && scrollbar.value < 0.92)
        {
            currentResistance += (scrollbar.value * resistanceGrowth);
        }
        else if (scrollbar.value >= 0.92)
        {
            currentResistance += (scrollbar.value * resistanceGrowth2);
        }
        else
        {
            currentResistance = baseResistance;
        }

        // Reducir el valor del Scrollbar constantemente
        scrollbar.value -= currentResistance * Time.deltaTime;
        scrollbar.value = Mathf.Clamp(scrollbar.value, 0f, 1f); // Limitar entre 0 y 1

        // Incrementar el valor del Scrollbar al presionar la tecla (solo pulsaciones)
        if (Input.GetKeyDown(inputKey))
        {
            scrollbar.value += increaseRate;
            scrollbar.value = Mathf.Clamp(scrollbar.value, 0f, 1f);
        }

        // Verificar si está en la zona verde
        if (scrollbar.value >= targetValue)
        {
            greenZoneTimer += Time.deltaTime; // Aumentar el temporizador
            if (greenZoneTimer >= greenZoneDuration)
            {
                gameWon = true;
                OnGameWon();
            }
        }
        else
        {
            greenZoneTimer = 0f; // Reiniciar el temporizador si sale de la zona verde
        }
    }

    void OnGameWon()
    {
       
        nextPanelReady = true; // Permitir avanzar al siguiente panel
        Debug.Log("¡Minijuego completado! Presiona 'X' para continuar.");
    }
}