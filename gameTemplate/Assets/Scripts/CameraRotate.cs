using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;
    
    public float sensitivity;
    public RotationAxes axes;
    public enum RotationAxes
    {
        MouseX = 1,
        MouseY = 2
    }
    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) 
            body.freezeRotation = true; // rotation исполняется при помощи мыши 
        Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
    }
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            
        } else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); 
            float rotationY = transform.localEulerAngles.y; 
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            
        }
    }
}
