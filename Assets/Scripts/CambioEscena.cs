using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string nextSceneName;
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public Camera playerCamera;
    public Camera newCamera;
    public Animator characterAnimator;
    public string animationTrigger = "T-pose@agony";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Animal"))
        {
            if (characterAnimator != null) characterAnimator.SetTrigger(animationTrigger);

            StartCoroutine(MoveCameraToPosition());
            StartCoroutine(LoadSceneAfterAnimation());
        }
    }

    private IEnumerator MoveCameraToPosition()
    {
        // Pausar el controlador del jugador
        GameManager.singleton.Pausar(true);

        playerCamera.gameObject.SetActive(false);
        newCamera.gameObject.SetActive(true);

        Vector3 initialPosition = newCamera.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < smoothSpeed)
        {
            Vector3 targetPosition = player.position + player.forward * 2f + offset;
            newCamera.transform.position = Vector3.Lerp(newCamera.transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(player.position - newCamera.transform.position);
            newCamera.transform.rotation = Quaternion.Slerp(newCamera.transform.rotation, targetRotation, 2f * Time.deltaTime);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator LoadSceneAfterAnimation()
    {
        yield return new WaitForSeconds(3f); // Ajusta este tiempo según lo necesites
        SceneManager.LoadScene(nextSceneName);
    }
}
