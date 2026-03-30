using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController myController;
    public float movingSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 dir = (transform.right * hInput + transform.forward * vInput).normalized;
        /*Debug.Log(dir);
        Debug.Log(dir.magnitude);*/
        myController.SimpleMove(dir * movingSpeed);
    }
}
