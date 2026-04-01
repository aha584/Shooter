using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float angleOverDistance;

    public Transform cameraHolder;
    public float minPitch;
    public float maxPitch;

    private float pitch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        HorizontalRotate(mouseX);
        VerticalRotate(mouseY);
    }
    private void HorizontalRotate(float mouseX)
    {
        float deltaX = mouseX * angleOverDistance;
        transform.Rotate(0, deltaX, 0);
    }
    private void VerticalRotate(float mouseY)
    {
        float deltaY = -mouseY * angleOverDistance;
        pitch = Mathf.Clamp(pitch + deltaY, minPitch, maxPitch);
        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
