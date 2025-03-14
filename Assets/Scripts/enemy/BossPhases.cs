using UnityEngine;

public class BossPhases : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public int currentPhase = 1;  // Fase 1 por defecto

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Este método se llamará cada vez que el boss reciba daño
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckPhase();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Comprueba y actualiza la fase en función del porcentaje de salud restante
    void CheckPhase()
    {
        float healthPercentage = currentHealth / maxHealth;

        if (healthPercentage < 0.5f && currentPhase == 1)
        {
            currentPhase = 2;
            Debug.Log("El boss entra en Fase 2");
            // Aquí puedes, por ejemplo, aumentar la velocidad de ataque, cambiar ataques, etc.
        }
        if (healthPercentage < 0.25f && currentPhase == 2)
        {
            currentPhase = 3;
            Debug.Log("El boss entra en Fase 3");
            // En la fase 3 puedes implementar aún más agresividad o ataques especiales
        }
    }

    void Die()
    {
        Debug.Log("El boss ha sido derrotado");
        // Aquí disparas animaciones de muerte o destruyes el objeto
        Destroy(gameObject);
    }
}
