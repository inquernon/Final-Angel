using UnityEngine;
using UnityEngine.UI;

public class CircleShrink : MonoBehaviour
{
    public Image innerCircle;  // El c�rculo central
    public Image outerCircle;  // El c�rculo que se encoge
    public float shrinkSpeed = 1f;  // Velocidad a la que se encoge el c�rculo
    private bool isShrinking = true;
    private bool hasShrunk = false;
    private float originalOuterSize;  // Tama�o original del c�rculo exterior
    public GameObject invo;
    bool igual = false;

    void Start()
    {
        // Guardamos el tama�o original del c�rculo exterior
        originalOuterSize = outerCircle.rectTransform.rect.width;
    }

    void Update()
    {
        if (isShrinking && !hasShrunk)
        {
            // Hacemos que el c�rculo exterior se encoja
            float newSize = outerCircle.rectTransform.rect.width - shrinkSpeed * Time.deltaTime;
            outerCircle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize);
            outerCircle.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize);
            

            // Verificamos si los c�rculos se han tocado
            if (newSize <= innerCircle.rectTransform.rect.width+10 && newSize >= innerCircle.rectTransform.rect.width - 10)
            {
                igual = true;
                Debug.Log("entro");
                // Los c�rculos se han tocado, cambiamos los bordes a verde
                outerCircle.GetComponent<Outline>().effectColor = Color.green;
                innerCircle.GetComponent<Outline>().effectColor = Color.green;
            }
            else 
            {
                // Si el c�rculo exterior es m�s peque�o que el interior, restauramos el borde a negro
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