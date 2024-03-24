using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // HorizontalSpeed = Input.GetAxisRaw("Horizontal");
        // VerticalSpeed = Input.GetAxisRaw("Vertical");
        // Vector2 movement = new Vector2(HorizontalSpeed, VerticalSpeed).normalized * speed * Time.deltaTime;
    }
}
