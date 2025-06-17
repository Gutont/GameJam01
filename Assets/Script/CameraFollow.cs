using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;
    private void LateUpdate()
    {
        // Posição que a câmera quer alcançar.
        Vector3 targetPosition = target.position + offset;

        // Move a câmera de forma suave.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
