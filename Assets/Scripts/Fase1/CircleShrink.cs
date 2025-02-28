using UnityEngine;
using UnityEngine.UI;

public class CircleShrink : MonoBehaviour
{
    public Image innerCircle;  // El círculo central
    public Image outerCircle;  // El círculo que se encoge
    public float shrinkSpeed = 1f;  // Velocidad a la que se encoge el círculo
    private bool isShrinking = true;
    private bool hasShrunk = false;
    private float originalOuterSize;  // Tamaño original del círculo exterior
    public GameObject invo;
    bool igual = false;

    void Start()
    {
        // Guardamos el tamaño original del círculo exterior
        originalOuterSize = outerCircle.rectTransform.rect.width;
    }

    void Update()
    {
        if (isShrinking && !hasShrunk)
        {
            // Hacemos que el círculo exterior se encoja
            float newSize = outerCircle.rectTransform.rect.width - shrinkSpeed * Time.deltaTime;
            outerCircle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize);
            outerCircle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize);
            

            // Verificamos si los círculos se han tocado
            if (newSize <= innerCircle.rectTransform.rect.width+10 && newSize >= innerCircle.rectTransform.rect.width - 10)
            {
                igual = true;
                Debug.Log("entro");
                // Los círculos se han tocado, cambiamos los bordes a verde
                outerCircle.GetComponent<Outline>().effectColor = Color.green;
                innerCircle.GetComponent<Outline>().effectColor = Color.green;
            }
            else 
            {
                // Si el círculo exterior es más pequeño que el interior, restauramos el borde a negro
                outerCircle.GetComponent<Outline>().effectColor = Color.black;
                innerCircle.GetComponent<Outline>().effectColor = Color.black;
                igual = false;
                Debug.Log("no entro");
            }

        }
    }

    public bool iguales()
    {
        return igual;
    }
    public void StopShrinking()
    {
        isShrinking = false;  // Detenemos el encogimiento cuando el jugador presiona la tecla
    }
    public void invocacion()
    {
        invo.SetActive(true);
        outerCircle.enabled = false;

        innerCircle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 240);
        innerCircle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 240);
    }
}