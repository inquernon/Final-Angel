using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;          // Referencia al jugador
    public NavMeshAgent agent;        // Componente para navegación
    public float attackRange = 2.0f;    // Distancia para poder atacar
    public float dodgeChance = 0.2f;    // Probabilidad de esquivar antes de atacar
    public float attackCooldown = 2f;   // Tiempo entre ataques

    private float nextAttackTime = 0f;

    // Definición de estados del boss
    private enum BossState { Idle, Chase, Attack, Dodge }
    private BossState currentState = BossState.Idle;

    void Start()
    {
        // Asignamos el NavMeshAgent si no lo hemos hecho en el inspector
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Calculamos la distancia al jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Decisión de cambio de estado
        if (distance > attackRange)
        {
            currentState = BossState.Chase;
        }
        else
        {
            // Con cierta probabilidad, el boss decide esquivar
            if (Random.value < dodgeChance)
                currentState = BossState.Dodge;
            else
                currentState = BossState.Attack;
        }

        // Ejecutamos el comportamiento según el estado
        switch (currentState)
        {
            case BossState.Chase:
                ChasePlayer();
                break;
            case BossState.Attack:
                AttackPlayer();
                break;
            case BossState.Dodge:
                Dodge();
                break;
            case BossState.Idle:
            default:
                // Comportamiento en reposo
                break;
        }
    }

    // El boss se mueve hacia el jugador
    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    // El boss se detiene y ejecuta un ataque (podemos definir varios tipos)
    void AttackPlayer()
    {
        // Nos detenemos para atacar
        agent.SetDestination(transform.position);

        if (Time.time >= nextAttackTime)
        {
            // Seleccionamos aleatoriamente un ataque (por ejemplo, 3 tipos)
            int attackType = Random.Range(0, 3);
            switch (attackType)
            {
                case 0:
                    Debug.Log("Ataque: Corte lateral");
                    // Aquí insertas la lógica o animación del ataque tipo corte lateral
                    break;
                case 1:
                    Debug.Log("Ataque: Estocada");
                    // Aquí insertas la lógica o animación del ataque tipo estocada
                    break;
                case 2:
                    Debug.Log("Ataque: Golpe contundente");
                    // Aquí insertas la lógica o animación del ataque tipo golpe contundente
                    break;
            }
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    // Un movimiento rápido lateral para esquivar
    void Dodge()
    {
        // Elegimos una dirección lateral al azar
        Vector3 dodgeDirection = transform.right * (Random.value > 0.5f ? 1 : -1);
        // Realizamos un movimiento rápido; este ejemplo modifica la posición directamente,
        // aunque podrías animar este movimiento o usar un coroutine para un efecto más pulido.
        transform.position += dodgeDirection * 3f * Time.deltaTime;
        Debug.Log("El boss está esquivando");

        // Después de esquivar, volvemos al estado de persecución
        currentState = BossState.Chase;
    }
}