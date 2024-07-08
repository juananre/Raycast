using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    private float mouseX, mouseY;
    [SerializeField] float velocity = 100f;
    float rotatioinX = 0f;
    [SerializeField] Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        mouseX= Input.GetAxis("Mouse X") * velocity * Time.deltaTime;
        mouseY= Input.GetAxis("Mouse Y") * velocity * Time.deltaTime;

        rotatioinX -= mouseY;
        rotatioinX = Mathf.Clamp(rotatioinX,-90f, 90f);

        transform.localRotation= Quaternion.Euler(rotatioinX,0f,0f);
        Player.Rotate(Vector3.up * mouseX);
    }
}
