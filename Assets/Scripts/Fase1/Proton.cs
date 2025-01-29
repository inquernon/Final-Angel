using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Proton : MonoBehaviour, IPointerClickHandler
{
    public MiniGameProtones gameManager;

    private void Start()
    {
        // Obtén la referencia del GameManager usando el Singleton
        gameManager = MiniGameProtones.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager no encontrado en la escena. Asegúrate de que exista un objeto GameManager.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Notificar al controlador que el protón fue recolectado
        gameManager.CollectProton(gameObject);
    }
}