using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoleculeController : MonoBehaviour
{
    public MoleculaDos[] moleculas;
    [Range(0, 1)]
    public float exitacion;
    public InputActionProperty joystickControl;
    public Vector2 valorJoystick;
    private Vector2 posAnterior;
    public float numero;
    public float aumentoExitacion;
    Coroutine miRutina;

    private void Start()
    {
        joystickControl.action.Enable();
        moleculas = gameObject.GetComponentsInChildren<MoleculaDos>();
    }
    void Update()
    {
        valorJoystick = joystickControl.action.ReadValue<Vector2>();
        for (int i = 0; i < moleculas.Length; i++)
        {
            moleculas[i].exitacion = exitacion;
        }
    }
    IEnumerator ControlGiro()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if ((valorJoystick-posAnterior).magnitude>numero)
            {
                exitacion += aumentoExitacion;
                if (exitacion>1)
                {
                    exitacion = 1;
                }
            }
            posAnterior = valorJoystick;
        }
    }
    private void OnEnable()
    {
        if (miRutina!=null)
        {
            StopCoroutine(miRutina);
        }
        miRutina = StartCoroutine(ControlGiro());
    }
}
