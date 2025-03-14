using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtacarEspada : MonoBehaviour
{
    public Animator animaciones;
    public InputActionProperty botonAtaque;
    // Start is called before the first frame update
    void Start()
    {
        botonAtaque.action.Enable();
        botonAtaque.action.performed += Atacar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Atacar( InputAction.CallbackContext x)
    {
        animaciones.SetTrigger("Attack");
    }
}
