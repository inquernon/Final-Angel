using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // damageType puede ser un string o un enum para diferenciar tipos de daño
    public void TakeDamage(float damage, string damageType)
    {
        // Aquí puedes incluir lógica para modificar el daño según el tipo
        // Por ejemplo: if(damageType == "fire") { damage *= 1.2f; } etc.
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} recibió {damage} de daño ({damageType}). Salud restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ha muerto");
        // Ejecuta la animación de muerte, efectos, o destruye el objeto
        Destroy(gameObject);
    }
}
