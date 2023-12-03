using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera seguirá
    public float distanceX = 5.0f; // Distância da câmera para o objeto no eixo X
    public float height = 2.0f; // Altura da câmera em relação ao objeto
    public float smoothTime = 0.3f; // Tempo de suavização de movimento da câmera

    private Vector3 velocity = Vector3.zero;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Calcula a posição desejada da câmera
        Vector3 targetPosition = target.position;
        targetPosition.y += height;
        targetPosition.x -= distanceX; // Ajusta a posição no eixo X

        // Suaviza o movimento da câmera usando SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Mantém a orientação inicial da câmera
        transform.rotation = initialRotation;
    }
}
