using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    // Transform-поле игрока (для слежения за ним)
    [SerializeField] private Transform player;
    // определение смещения между игроком и камерой
    private Vector3 offset;

    // определение начального смещения
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Метод постоянного вычислния новой позиции камеры
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = newPosition;
    }
}
