using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuNavigation : MonoBehaviour
{
    public List<Button> buttons;  // Lista de botones para navegaci�n
    private int currentButtonIndex = 0; // �ndice del bot�n seleccionado actualmente
    private bool isButtonSelected = false;

    public GameObject[] panels; // Los paneles que aparecer�n cuando se seleccione un bot�n

    void Update()
    {
        // Navegar a trav�s de los botones con el joystick derecho (usando el eje vertical)
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0.5f) // Se mueve hacia arriba
        {
            currentButtonIndex = (currentButtonIndex > 0) ? currentButtonIndex - 1 : buttons.Count - 1;
            UpdateButtonSelection();
        }
        else if (verticalInput < -0.5f) // Se mueve hacia abajo
        {
            currentButtonIndex = (currentButtonIndex < buttons.Count - 1) ? currentButtonIndex + 1 : 0;
            UpdateButtonSelection();
        }

        // Seleccionar el bot�n con la tecla "A"
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && !isButtonSelected)  // Joystick Button A
        {
            SelectButton();
        }
    }

    void UpdateButtonSelection()
    {
        // Resaltar el bot�n seleccionado
        for (int i = 0; i < buttons.Count; i++)
        {
            Button button = buttons[i];
            Outline outline = button.GetComponent<Outline>();

            if (i == currentButtonIndex)
            {
                // Resaltar el bot�n seleccionado con un borde azul
                button.GetComponent<Image>().color = new Color(0f, 1f, 1f); // Cambiar color de fondo (cyan) para indicar selecci�n
                if (outline != null)
                {
                    outline.enabled = true; // Activar el borde (Outline)
                    outline.effectColor = new Color(0f, 1f, 1f); // Establecer el color del borde a azul (00FFFF)
                    outline.effectDistance = new Vector2(4, 4); // Ajusta el grosor del borde si es necesario
                }
            }
            else
            {
                // Restablecer el estilo de los dem�s botones
                button.GetComponent<Image>().color = Color.white; // Color normal
                if (outline != null)
                {
                    outline.enabled = false; // Desactivar el borde (Outline) para los botones no seleccionados
                }
            }
        }
    }

    void SelectButton()
    {
        Button selectedButton = buttons[currentButtonIndex];
        selectedButton.GetComponent<Image>().color = Color.gray; // Cambiar el color para indicar que est� deshabilitado

        // Activar el panel correspondiente al bot�n seleccionado
        panels[currentButtonIndex].SetActive(true); // Activar el panel correspondiente
        isButtonSelected = true; // Indicar que un bot�n fue seleccionado
    }

    // M�todo para restablecer la selecci�n de botones cuando sea necesario
    public void ResetSelection()
    {
        isButtonSelected = false;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = true; // Habilitar todos los botones
            buttons[i].GetComponent<Image>().color = Color.white; // Restablecer el color del bot�n
            Outline outline = buttons[i].GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = false; // Desactivar el borde cuando se restablece la selecci�n
            }
        }
    }
}
