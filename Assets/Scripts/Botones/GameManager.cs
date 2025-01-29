using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool enPausa = false;
    public MonoBehaviour[] elementosDesactivarPausa; 

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void Pausar(bool p)
    {
    //inactiva los elementos en pausa
        foreach (MonoBehaviour elemento in elementosDesactivarPausa)
        {
            elemento.enabled = !p;
            Debug.Log("activado");
        }
        enPausa = p;
        if (p)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
