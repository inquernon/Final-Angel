using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameProtones : MonoBehaviour
{

    public GameObject protonPrefab; // Prefab del protón (círculo pequeño)
    public Transform panel; // Panel donde aparecerán los protones
    public GameObject atom; // Átomo central (círculo grande)
    public int requiredProtons = 10; // Número de protones necesarios para ganar
    public float spawnInterval = 1f; // Intervalo de aparición de protones
    public float protonLifetime = 3f; // Tiempo antes de que un protón desaparezca

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
        // Crear un protón en una posición aleatoria dentro del panel
        Vector2 randomPosition = new Vector2(
            Random.Range(0, panel.GetComponent<RectTransform>().rect.width)/2,
            Random.Range(0, panel.GetComponent<RectTransform>().rect.height)/2
        );

        GameObject proton = Instantiate(protonPrefab, panel);
        proton.GetComponent<RectTransform>().anchoredPosition = randomPosition;

        // Configurar destrucción del protón si no se presiona a tiempo
        Destroy(proton, protonLifetime);
    }

    public void CollectProton(GameObject proton)
    {
        // Destruir el protón y añadirlo al átomo
        Destroy(proton);
        collectedProtons++;
        UpdateAtom();

        // Verificar si se ganó el minijuego
        if (collectedProtons >= requiredProtons)
        {
            GameWon();
        }
    }

    void UpdateAtom()
    {
        // Incrementar el tamaño del átomo central
        float scale = 1f + (float)collectedProtons / requiredProtons;
        atom.transform.localScale = new Vector3(scale, scale, 1f);
    }

    void GameWon()
    {
        gameOver = true;
        Debug.Log("¡Has formado el compuesto!");
        // Aquí puedes cargar el siguiente minijuego o mostrar una interfaz de victoria
    }

    public void GameLost()
    {
        gameOver = true;
        Debug.Log("¡Has fallado!");
        // Aquí puedes cargar la pantalla de derrota
    }
}
