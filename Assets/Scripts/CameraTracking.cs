using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Awake()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not set in CameraTracking.");
            enabled = false; // Отключаем скрипт, чтобы избежать ошибок
        }
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Устанавливаем позицию камеры равной позиции игрока
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
