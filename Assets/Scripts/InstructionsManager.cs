using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionsManager : MonoBehaviour
{
    public GameObject[] instructionViews; // Lista de vistas de instrucciones
    public GameObject instructionsPanel; // El panel principal
    private int currentViewIndex = 0; // Índice de la vista actual
    public InputActionProperty pause;

    private bool tutorial = true;
    void Start()
    {
        ShowView(0); // Mostrar la primera vista al inicio
        pause.action.Enable();
        pause.action.performed += ps => TogglePauseMenu();
    }

    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) // Botón "A" del joystick
        {
            NextView();
        }
    }
    void TogglePauseMenu()
    {
        //tutorial = !tutorial;

        if (tutorial)
        {
            // Pausar el juego
            GameManager.singleton.Pausar(true);
        }
        else
        {
            // Reanudar el juego
            GameManager.singleton.Pausar(false);
        }
    }

    // Mostrar una vista específica
    void ShowView(int index)
    {
        // Desactivar todas las vistas
        foreach (GameObject view in instructionViews)
        {
            view.SetActive(false);
        }

        // Activar la vista correspondiente
        if (index < instructionViews.Length)
        {
            instructionViews[index].SetActive(true);
        }
    }

    // Cambiar a la siguiente vista o cerrar el panel
    void NextView()
    {
        currentViewIndex++;

        if (currentViewIndex >= instructionViews.Length)
        {
            // Si se pasan todas las vistas, cerrar el panel
            instructionsPanel.SetActive(false);
            tutorial = false;
            GameManager.singleton.Pausar(false); // Reanuda el juego
        }
        else
        {
            // Mostrar la siguiente vista
            ShowView(currentViewIndex);
            tutorial = true;
        }
    }
}