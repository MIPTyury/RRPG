using UnityEngine;

public class MovementControlls : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalSpeed;
    private float VerticalSpeed;
    [SerializeField] private float speed = 5;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing!");
            enabled = false; // Отключаем компонент, если Rigidbody2D не найден
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        
        HorizontalSpeed = Input.GetAxisRaw("Horizontal");
        VerticalSpeed = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(HorizontalSpeed, VerticalSpeed).normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
