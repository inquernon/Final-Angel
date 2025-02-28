using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingButton : MonoBehaviour
{

    public GameObject botonX; // Bot�n que parpadear�
    public float blinkInterval = 0.5f; // Intervalo de tiempo entre parpadeos

    private bool isBlinking = false;

    private void Start()
    {
    }
    void OnEnable()
    {
        // Inicia el parpadeo cuando el objeto est� activo
        if (!isBlinking)
        {
            StartCoroutine(Blink());   
        }
    }

    void OnDisable()
    {
        // Detiene el parpadeo cuando el objeto est� desactivado
        StopAllCoroutines();
        isBlinking = false;
    }

    IEnumerator Blink()
    {
        isBlinking = true;

        while (true)
        {
            botonX.SetActive(!botonX.activeSelf); // Alterna la visibilidad del bot�n
            yield return new WaitForSeconds(blinkInterval); // Espera el intervalo definido
            Debug.Log("parpadeando");
        }
    }
    public void DetenerParpadeo()
    {
        isBlinking = false;
        botonX.SetActive(true);
        StopAllCoroutines();
    }
}