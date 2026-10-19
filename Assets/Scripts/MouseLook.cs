using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 300f;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Не рухаємо камеру під час паузи
        if (Time.timeScale == 0f)
            return;

        // Блокуємо курсор під час гри
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Look();
    }

    private void Look()
    {
        if (Mouse.current == null)
            return;

        Vector2 mouseInput =
            Mouse.current.delta.ReadValue();

        float mouseX = mouseInput.x *
                       mouseSensitivity * Time.deltaTime;

        float mouseY = mouseInput.y *
                       mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(
            xRotation, -90f, 90f
        );

        transform.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}