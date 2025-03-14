using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingButton : MonoBehaviour
{

    public GameObject botonX; // Botón que parpadeará
    public float blinkInterval = 0.5f; // Intervalo de tiempo entre parpadeos

    private bool isBlinking = false;

    private void Start()
    {
    }
    void OnEnable()
    {
        // Inicia el parpadeo cuando el objeto está activo
        if (!isBlinking)
        {
            StartCoroutine(Blink());   
        }
    }

    void OnDisable()
    {
        // Detiene el parpadeo cuando el objeto está desactivado
        StopAllCoroutines();
        isBlinking = false;
    }

    IEnumerator Blink()
    {
        isBlinking = true;

        while (true)
        {
            botonX.SetActive(!botonX.activeSelf); // Alterna la visibilidad del botón
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