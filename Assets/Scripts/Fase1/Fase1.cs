using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1 : MonoBehaviour
{
    public GameObject cameraPausa; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraPausa.SetActive(true);

        }
    }
}
