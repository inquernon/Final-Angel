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

    // Este m�todo se llamar� cada vez que el boss reciba da�o
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckPhase();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Comprueba y actualiza la fase en funci�n del porcentaje de salud restante
    void CheckPhase()
    {
        float healthPercentage = currentHealth / maxHealth;

        if (healthPercentage < 0.5f && currentPhase == 1)
        {
            currentPhase = 2;
            Debug.Log("El boss entra en Fase 2");
            // Aqu� puedes, por ejemplo, aumentar la velocidad de ataque, cambiar ataques, etc.
        }
        if (healthPercentage < 0.25f && currentPhase == 2)
        {
            currentPhase = 3;
            Debug.Log("El boss entra en Fase 3");
            // En la fase 3 puedes implementar a�n m�s agresividad o ataques especiales
        }
    }

    void Die()
    {
        Debug.Log("El boss ha sido derrotado");
        // Aqu� disparas animaciones de muerte o destruyes el objeto
        Destroy(gameObject);
    }
}
