using UnityEngine;
using UnityEngine.UI;

public class NeonPulse : MonoBehaviour
{
    private Outline outline;
    public float pulseSpeed = 2f; // Velocidad del pulso

    void Start()
    {
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        if (outline != null)
        {
            float alpha = Mathf.PingPong(Time.time * pulseSpeed, 1f);
            outline.effectColor = new Color(0f, 1f, 1f, alpha); // Azul neón con transparencia
        }
    }
}