using UnityEngine;

public class PlayerMovement : MonoBehaviour // Component
{
    public CharacterController CharacterController;
    public Camera playerCamera;
    public float Speed;
    public float RotationSpeed;

    private float _horizontalInput = 0f;
    private float _verticalInput = 0f;
    
    private float _turnSmoothVelocity;

    private void GetDirections()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void DoMovement()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0f, _verticalInput);

        if (movement.magnitude >= 0.1f)
        {
            var targetRotation = DoRotate();
            
            Vector3 moveDirection = Quaternion.Euler(0f, targetRotation, 0f) * Vector3.forward;
            CharacterController.Move(moveDirection.normalized * (Speed * Time.deltaTime));
        }
    }

    private float DoRotate()
    {
        var targetRotation = Mathf.Atan2(_horizontalInput, _verticalInput) * Mathf.Rad2Deg + playerCamera.transform.eulerAngles.y; // La rotacion objetivo
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _turnSmoothVelocity, RotationSpeed);
        transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);

        return targetRotation;
    }

    private void Update() // Cada vez de todos los frames en 1 segundo que el CPU logre procesar, 147FPS = 147 veces
    {
        GetDirections();
        DoMovement();
        // TODO: Queda pendiente añadir gravedad al jugador
    }   
}
