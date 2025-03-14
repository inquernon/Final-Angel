using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionsManager : MonoBehaviour
{
    public GameObject[] instructionViews; // Lista de vistas de instrucciones
    public GameObject instructionsPanel; // El panel principal
    public GameObject ui; // UI
    private int currentViewIndex = 0; // Índice de la vista actual
    public InputActionProperty pause; // Acción para pausar/reanudar
    public InputActionAsset actionAsset; // InputActionAsset para controlar los mapas de acciones
    private InputActionMap uiActionMap;  // Mapa de acciones para la UI
    private InputActionMap playerActionMap; // Mapa de acciones para el jugador
    //private InputActionMap minigameActionMap; // Mapa de acciones para el minijuego

    private bool tutorial = true;

    void Start()
    {
        uiActionMap = actionAsset.FindActionMap("UI");
        playerActionMap = actionAsset.FindActionMap("Player");
        ui.SetActive(false);

        ShowView(0); // Mostrar la primera vista al inicio

        // Habilitar el mapa de UI solo para las instrucciones
        EnableUIActions();

        // Habilitar la acción de pausa
        pause.action.Enable();
        pause.action.performed += ps => TogglePauseMenu();

            GameManager.singleton.Pausar(true);



        }

        void Update()
    {
        // Solo capturar entradas del joystick para el mapa UI
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) // Botón "A" del joystick
        {
            NextView();
        }
    }

    void TogglePauseMenu()
    {
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
            ui.SetActive(true);
            GameManager.singleton.Pausar(false); // Reanuda el juego

            // Desactivar el Action Map de UI y habilitar el mapa del jugador o minijuego
            EnablePlayerActions();
        }
        else
        {
            // Mostrar la siguiente vista
            ShowView(currentViewIndex);
            tutorial = true;
        }
    }

    // Habilitar el mapa de acciones de UI y deshabilitar los otros mapas
    void EnableUIActions()
    {
        uiActionMap.Enable();
        playerActionMap.Disable();
    }

    // Habilitar el mapa de acciones del jugador (cuando se cierran las instrucciones)
    void EnablePlayerActions()
    {
        uiActionMap.Disable();
        playerActionMap.Enable();
    }

}
