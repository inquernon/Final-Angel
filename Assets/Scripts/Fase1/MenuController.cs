using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu; // Referencia al menú (Canvas o Panel)
    public Button targetButton; // Botón que se iluminará
    private Color originalColor; // Guardar el color original del botón
    public Color highlightColor = Color.yellow; // Color para iluminar el botón

    void Start()
    {
        if (menu != null)
        {
            menu.SetActive(false); // Asegurar que el menú está desactivado al inicio
        }

        if (targetButton != null)
        {
            originalColor = targetButton.image.color; // Guardar color original del botón
        }
    }

    void Update()
    {
        // Activar menú al presionar la tecla "M"
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (menu != null)
        {
            bool isActive = !menu.activeSelf; // Invertir el estado actual
            menu.SetActive(isActive);

            if (targetButton != null)
            {
                // Si el menú está activo, iluminar el botón, si no, restaurar color
                targetButton.image.color = isActive ? highlightColor : originalColor;
            }
        }
    }
}
