using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas; 
    public Transform player; 
    public GameObject cameraPausa;
    public InputActionProperty pause;

    private bool isPaused = false;
    private void Start()
    {
        pause.action.Enable();
        pause.action.performed += ps => TogglePauseMenu();
    }
    void Update()
    {
    }

    void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuCanvas.SetActive(isPaused);

        if (isPaused)
        {
            // Pausar el juego
            Time.timeScale = 0.05f;
            GameManager.singleton.Pausar(true);

            // Apuntar la cámara al jugador
            cameraPausa.SetActive(true);
        }
        else
        {
            // Reanudar el juego
            Time.timeScale = 1f;
            GameManager.singleton.Pausar(false);
            cameraPausa.SetActive(false);
        }
    }

    // Función para salir del juego (asociar al botón Salir)
    public void ExitGame()
    {
        Time.timeScale = 1f; // Reanudar el tiempo antes de salir
        SceneManager.LoadScene("MenuInicio"); // Reemplaza "MainMenu" con el nombre de tu escena de menú principal
    }
}