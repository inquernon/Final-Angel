using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu; // Referencia al men� (Canvas o Panel)
    public Button targetButton; // Bot�n que se iluminar�
    private Color originalColor; // Guardar el color original del bot�n
    public Color highlightColor = Color.yellow; // Color para iluminar el bot�n

    void Start()
    {
        if (menu != null)
        {
            menu.SetActive(false); // Asegurar que el men� est� desactivado al inicio
        }

        if (targetButton != null)
        {
            originalColor = targetButton.image.color; // Guardar color original del bot�n
        }
    }

    void Update()
    {
        // Activar men� al presionar la tecla "M"
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
                // Si el men� est� activo, iluminar el bot�n, si no, restaurar color
                targetButton.image.color = isActive ? highlightColor : originalColor;
            }
        }
    }
}
