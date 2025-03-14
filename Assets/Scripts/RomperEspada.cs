using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperEspada : MonoBehaviour
{
    public int contador=0, cantGolpes=4;
    public GameObject hojaAntigua, hojaRota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Espada")
        {
            contador++;
            if(contador >= cantGolpes) {
                Destruir();
                Destroy(this);
            }
        }
    }
    [ContextMenu("destruir")]
    public void Destruir()
    {
        hojaAntigua.SetActive(false);
        Instantiate(hojaRota, hojaAntigua.transform.position, hojaAntigua.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
