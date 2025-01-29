using UnityEngine;

public class MoleculeController : MonoBehaviour
{
    public float vibrationSpeed = 0.1f; // Velocidad inicial de vibración
    public float vibrationIntensity = 0.1f; // Intensidad de la vibración

    private Vector3 originalPosition; // Para mantener la posición base

    void Start()
    {
        originalPosition = transform.position; // Guardar la posición inicial
    }

    void Update()
    {
        // Aplica vibración simulando movimiento aleatorio cerca de la posición original
        transform.position = originalPosition + new Vector3(
            Mathf.Sin(Time.time * vibrationSpeed) * vibrationIntensity,
            Mathf.Cos(Time.time * vibrationSpeed) * vibrationIntensity,
            0
        );
    }

    // Método para aumentar la excitación de la molécula
    public void Excite(float speedIncrement, float intensityIncrement)
    {
        vibrationSpeed += speedIncrement;
        vibrationIntensity += intensityIncrement;
        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, vibrationIntensity);
    }
}
