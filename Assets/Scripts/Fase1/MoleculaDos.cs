using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculaDos : MonoBehaviour
{
    [Range(0, 1)]
    public float exitacion;
    public float radio;
    public float frecuecia = 5;
    private Vector3 posInicial;
    public Vector2 rangosFrecuencia;
    // Start is called before the first frame update
    void Start()
    {
        frecuecia = Random.Range(rangosFrecuencia.x, rangosFrecuencia.y);
        frecuecia *= (Random.Range(0f, 1f) > 0.5) ? 1 : -1;
        posInicial = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Posicionar();
    }
    public void Posicionar()
    {
        transform.localPosition = posInicial + (new Vector3(Mathf.Cos(Time.time * exitacion *frecuecia),Mathf.Sin(Time.time * exitacion * frecuecia),0))*radio*exitacion;
    }
}
