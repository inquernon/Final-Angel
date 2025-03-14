using System;
using UnityEngine;

public class CogerEspada : MonoBehaviour
{
    public GameObject sword; 
    public Animator animator;

    private bool isSwordEquipped = false;
    private void Start()
    {
        sword.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            ToggleSword();
        }
    }

    void ToggleSword()
    {
        isSwordEquipped = !isSwordEquipped;

        if (isSwordEquipped)
        {
            animator.SetTrigger("DrawSword"); // Activa la animación

            
        }
        else
        {
            animator.SetTrigger("SheathSword"); // Activa la animacióna
        }
    }
    public void ActivarEspada()
    {
        sword.SetActive(true);
    }
    public void DesactivarEspada()
    {
        sword.SetActive(false);
    }
}
