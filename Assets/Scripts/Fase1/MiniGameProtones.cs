using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameProtones : MonoBehaviour
{

    public GameObject protonPrefab; // Prefab del prot�n (c�rculo peque�o)
    public Transform panel; // Panel donde aparecer�n los protones
    public GameObject atom; // �tomo central (c�rculo grande)
    public int requiredProtons = 10; // N�mero de protones necesarios para ganar
    public float spawnInterval = 1f; // Intervalo de aparici�n de protones
    public float protonLifetime = 3f; // Tiempo antes de que un prot�n desaparezca

    private int collectedProtons = 0; // Contador de protones recolectados
    private bool gameOver = false;

    public static MiniGameProtones Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnProtons());
    }

    IEnumerator SpawnProtons()
    {
        while (!gameOver)
        {
            SpawnProton();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnProton()
    {
        // Crear un prot�n en una posici�n aleatoria dentro del panel
        Vector2 randomPosition = new Vector2(
            Random.Range(0, panel.GetComponent<RectTransform>().rect.width)/2,
            Random.Range(0, panel.GetComponent<RectTransform>().rect.height)/2
        );

        GameObject proton = Instantiate(protonPrefab, panel);
        proton.GetComponent<RectTransform>().anchoredPosition = randomPosition;

        // Configurar destrucci�n del prot�n si no se presiona a tiempo
        Destroy(proton, protonLifetime);
    }

    public void CollectProton(GameObject proton)
    {
        // Destruir el prot�n y a�adirlo al �tomo
        Destroy(proton);
        collectedProtons++;
        UpdateAtom();

        // Verificar si se gan� el minijuego
        if (collectedProtons >= requiredProtons)
        {
            GameWon();
        }
    }

    void UpdateAtom()
    {
        // Incrementar el tama�o del �tomo central
        float scale = 1f + (float)collectedProtons / requiredProtons;
        atom.transform.localScale = new Vector3(scale, scale, 1f);
    }

    void GameWon()
    {
        gameOver = true;
        Debug.Log("�Has formado el compuesto!");
        // Aqu� puedes cargar el siguiente minijuego o mostrar una interfaz de victoria
    }

    public void GameLost()
    {
        gameOver = true;
        Debug.Log("�Has fallado!");
        // Aqu� puedes cargar la pantalla de derrota
    }
}
