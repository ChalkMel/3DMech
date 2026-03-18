using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    private InputSystem_Actions _inputSystemActions;
    
    private void Awake()
    {
        _inputSystemActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        Bind();
        _inputSystemActions.Enable();
    }

    private void Bind()
    {
        _inputSystemActions.Player.Jump.performed += OnJump;
    }

    private void LateUpdate()
    {
        RotateCamera();
        ZoomCamera();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = _inputSystemActions.Player.Move.ReadValue<Vector2>();
        playerMovement.Move(direction); 
    }

    private void RotateCamera()
    {
        Vector2 lookInput = _inputSystemActions.Camera.Look.ReadValue<Vector2>();
        cameraController.RotateCamera(lookInput);
    }

    private void ZoomCamera()
    {
        float zoomInput = _inputSystemActions.Camera.Zoom.ReadValue<float>();
        cameraController.ZoomCamera(zoomInput);
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        playerMovement.Jump();
    }

    private void Expose()
    {
        _inputSystemActions.Player.Jump.performed -= OnJump;
    }

    private void OnDisable()
    {
        _inputSystemActions.Disable();
        Expose();
    }
}