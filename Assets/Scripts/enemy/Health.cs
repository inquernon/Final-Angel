using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // damageType puede ser un string o un enum para diferenciar tipos de da�o
    public void TakeDamage(float damage, string damageType)
    {
        // Aqu� puedes incluir l�gica para modificar el da�o seg�n el tipo
        // Por ejemplo: if(damageType == "fire") { damage *= 1.2f; } etc.
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} recibi� {damage} de da�o ({damageType}). Salud restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ha muerto");
        // Ejecuta la animaci�n de muerte, efectos, o destruye el objeto
        Destroy(gameObject);
    }
}
