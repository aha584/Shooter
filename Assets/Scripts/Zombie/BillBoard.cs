using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        LookTowardCamera();
    }

    // Update is called once per frame
    void Update()
    {
        LookTowardCamera();
    }

    private void LookTowardCamera()
    {
        transform.forward = - mainCamera.transform.forward;
    }
}
