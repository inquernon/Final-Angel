using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Para cargar una nueva escena

public class VisionBorrosa : MonoBehaviour
{
    public RawImage lr, rr;
    [Range(0, 1)]
    public float borrosoValue = 0.5f;
    public float distancia = 0.5f;
    public Transform cd, ci;
    [Range(1, 4)]
    public float a;
    private bool teclaPresionada = false;
    private float tiempoEsperado = 0f;
    public float frecuencia = 2;
    public float velAumentoLocura=0.2f;
    public KeyCode teclaContrarrestar = KeyCode.E;
    public bool gano = false;
    public Animator animator;  // Para controlar la animación
    public float tiempoEsperadoParaEscena = 2f; // Tiempo de espera antes de cambiar la escena
    public bool inicioJuego = false;

    void Update()
    {
        if (!gano)
        {
            cd.localPosition = Vector3.right * distancia * borrosoValue * (Mathf.Sin(Time.time * frecuencia) + a * borrosoValue) * borrosoValue;
            ci.localPosition = Vector3.right * -distancia * borrosoValue * (Mathf.Sin(Time.time * frecuencia) + a * borrosoValue) * borrosoValue;
            borrosoValue = Mathf.Clamp(borrosoValue + velAumentoLocura * Time.deltaTime, 0, 1);
            Color cCamara = new Color(1, 1, 1, 0.5f * borrosoValue);
            lr.color = cCamara;
            rr.color = cCamara;

            if (inicioJuego)
            {
                if (Input.GetKey(teclaContrarrestar) && borrosoValue > 0 && !teclaPresionada && tiempoEsperado <= 0f)
                {
                    borrosoValue -= 0.05f;
                    if (borrosoValue < 0)
                    {
                        borrosoValue = 0;
                    }

                    teclaPresionada = true;
                    tiempoEsperado = 0.2f;
                }

                if (tiempoEsperado > 0f)
                {
                    tiempoEsperado -= Time.deltaTime;
                }
                else
                {
                    teclaPresionada = false;
                }
            }
        }
        if (borrosoValue>0.7f)
        {
            inicioJuego = true;
        }
        // Activar animación cuando el efecto esté completamente contrarrestado
        if (borrosoValue <= 0)
        {
            gano = true;
            // Activa la animación
            animator.SetBool("idle", true);
            // Espera 2 segundos antes de cambiar de escena
            tiempoEsperadoParaEscena -= Time.deltaTime;
            if (tiempoEsperadoParaEscena <= 0)
            {
                // Cambiar de escena después de 2 segundos
                SceneManager.LoadScene("3 Combate");  // Cambia el nombre de la escena
            }
        }
    }
}
