using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private float rotateSpeed;
  [SerializeField] private float zoomSpeed;
  [SerializeField] private float minYAngle;
  [SerializeField] private float maxYAngle;
  [SerializeField] private float maxZoom;
  [SerializeField] private float minZoom;

  [SerializeField] private Transform player;
    
  private float _rotationX;
  private float _rotationY;

  private Camera _camera;

  private void Awake()
  {
    _camera = GetComponent<Camera>();
    
    _rotationX = transform.eulerAngles.y;
    _rotationY = transform.eulerAngles.x;
  }

  private void Update()
  {
    player.rotation = Quaternion.Euler(0, _rotationX, 0);
  }

  public void RotateCamera(Vector2 lookInput)
  {
    
    _rotationX += lookInput.x * rotateSpeed * Time.deltaTime;
    _rotationY -= lookInput.y * (rotateSpeed/2) * Time.deltaTime;
    _rotationY = Mathf.Clamp(_rotationY, minYAngle, maxYAngle);
    
    player.rotation = Quaternion.Euler(0, _rotationX, 0);
    transform.rotation = Quaternion.Euler(_rotationY, _rotationX, 0f);
  }

  public void ZoomCamera(float zoomInput)
  {
    float newFOV = _camera.fieldOfView + zoomInput * zoomSpeed;
    newFOV = Mathf.Clamp(newFOV, minZoom, maxZoom);
    _camera.fieldOfView = newFOV;
  }
}