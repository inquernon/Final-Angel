using UnityEngine;
using UnityEngine.UI;

public class VisionDoble : MonoBehaviour
{
    public Camera mainCamera; // Cámara principal del jugador
    public Material visionDobleMaterial; // Material para el efecto de visión doble
    public float intensidadMaxima = 1.0f; // Máxima separación de la visión
    public float velocidadIncremento = 0.1f; // Velocidad con la que aumenta la intensidad
    public float velocidadRecuperacion = 0.05f; // Velocidad con la que disminuye la intensidad
    public KeyCode teclaContrarrestar = KeyCode.E; // Tecla que debe presionar el jugador

    private float intensidadActual = 0.0f; // Intensidad actual de la visión doble
    private bool efectoActivo = false;

    void Start()
    {
        if (visionDobleMaterial != null)
        {
            visionDobleMaterial.SetFloat("_Separation", 0); // Inicializa el material
        }

    }

    void Update()
    {
        if (efectoActivo)
        {
            // Incrementa la intensidad mientras no alcance el máximo
            if (intensidadActual < intensidadMaxima)
            {
                intensidadActual += velocidadIncremento * Time.deltaTime;
                visionDobleMaterial.SetFloat("_Separation", intensidadActual);
            }

            // Contrarresta el efecto al presionar la tecla repetidamente
            if (Input.GetKeyDown(teclaContrarrestar))
            {
                intensidadActual -= 0.2f; // Reduce la intensidad al presionar la tecla
                if (intensidadActual < 0)
                {
                    intensidadActual = 0;
                    DesactivarVisionDoble();
                }
                visionDobleMaterial.SetFloat("_Separation", intensidadActual);
            }
        }
    }

    public void ActivarVisionDoble()
    {
        efectoActivo = true;
        intensidadActual = 0; // Reinicia la intensidad
        visionDobleMaterial.SetFloat("_Separation", intensidadActual);
        Debug.Log("activando vision doble...");
    }

    private void DesactivarVisionDoble()
    {
        efectoActivo = false;
        visionDobleMaterial.SetFloat("_Separation", 0); // Resetea el material
    }
}