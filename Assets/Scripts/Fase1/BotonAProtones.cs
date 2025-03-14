using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAProtones : MonoBehaviour
{
    public CircleShrink circleShrinkScript;  // Referencia al script que hace que el círculo se encoja

    void Update()
    {
        // Detectamos si el jugador presiona la tecla "A" en el joystick Xbox
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && circleShrinkScript.iguales())  // El botón "A" en un joystick Xbox
        {
            Debug.Log("paro de moverse a");
            circleShrinkScript.StopShrinking();  // Detenemos el encogimiento cuando se presiona "A"
            circleShrinkScript.invocacion();
        }

        // O si estás usando el mapeo por defecto de Unity (Fire1 que corresponde a "A")
        if (Input.GetButtonDown("Fire1") && circleShrinkScript.iguales())
        {
            circleShrinkScript.StopShrinking();
            circleShrinkScript.invocacion();
        }
    }
}