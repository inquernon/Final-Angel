using UnityEngine;
using UnityEngine.InputSystem;

public class MoleculeExcitationController : MonoBehaviour
{
    public MoleculeController[] molecules; // Referencia a las mol�culas
    public float maxExcitation = 10f; // Nivel m�ximo de excitaci�n
    public float excitationSpeedIncrement = 0.2f; // Incremento de velocidad
    public float excitationIntensityIncrement = 0.02f; // Incremento de intensidad

    private float currentExcitation = 0f; // Nivel actual de excitaci�n
    private Vector2 joystickInput; // Entrada del joystick derecho

    void Update()
    {
        // Detectar el movimiento del joystick derecho
        float joystickMagnitude = joystickInput.magnitude;

        if (joystickMagnitude > 0.1f) // Ignorar valores peque�os
        {
            currentExcitation += joystickMagnitude * Time.deltaTime;

            foreach (var molecule in molecules)
            {
                //molecule.Excite(excitationSpeedIncrement * Time.deltaTime, excitationIntensityIncrement * Time.deltaTime);
            }

            if (currentExcitation >= maxExcitation)
            {
                WinGame();
            }
        }
    }

    public void OnRightStick(InputAction.CallbackContext context)
    {
        joystickInput = context.ReadValue<Vector2>(); // Leer el Vector2 del joystick derecho
    }

    void WinGame()
    {
        Debug.Log("�Ganaste el minijuego!");
    }
}