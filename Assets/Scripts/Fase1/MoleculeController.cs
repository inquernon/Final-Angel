using UnityEngine;

public class MoleculeController : MonoBehaviour
{
    public float vibrationSpeed = 0.1f; // Velocidad inicial de vibraci�n
    public float vibrationIntensity = 0.1f; // Intensidad de la vibraci�n

    private Vector3 originalPosition; // Para mantener la posici�n base

    void Start()
    {
        originalPosition = transform.position; // Guardar la posici�n inicial
    }

    void Update()
    {
        // Aplica vibraci�n simulando movimiento aleatorio cerca de la posici�n original
        transform.position = originalPosition + new Vector3(
            Mathf.Sin(Time.time * vibrationSpeed) * vibrationIntensity,
            Mathf.Cos(Time.time * vibrationSpeed) * vibrationIntensity,
            0
        );
    }

    // M�todo para aumentar la excitaci�n de la mol�cula
    public void Excite(float speedIncrement, float intensityIncrement)
    {
        vibrationSpeed += speedIncrement;
        vibrationIntensity += intensityIncrement;
        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, vibrationIntensity);
    }
}
