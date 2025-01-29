using UnityEngine;

public class DualCameraManager : MonoBehaviour
{
    public Camera leftCamera;
    public Camera rightCamera;
    public float wobbleIntensity = 0.05f;
    public float wobbleSpeed = 2f;

    void Update()
    {
        if (leftCamera && rightCamera)
        {
            float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleIntensity;

            leftCamera.transform.localPosition = new Vector3(-0.1f + wobble, leftCamera.transform.localPosition.y, leftCamera.transform.localPosition.z);
            rightCamera.transform.localPosition = new Vector3(0.1f - wobble, rightCamera.transform.localPosition.y, rightCamera.transform.localPosition.z);
        }
    }
}