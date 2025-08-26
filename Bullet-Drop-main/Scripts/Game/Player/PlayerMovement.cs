using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private float rotationSpeed;

   

    private Rigidbody2D _rigidbody;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref movementInputSmoothVelocity,
            0.1f
        );

        _rigidbody.linearVelocity = smoothedMovementInput * speed;
    }

    public class PlayerLook : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;

        void Update()
        {
            if (cam == null) return;

            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = cam.WorldToScreenPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, cam.WorldToScreenPoint(transform.position).z));

            Vector2 direction = (mouseWorldPos - transform.position).normalized;

            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(angle, 0, 0);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
