using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float maxFollowDistance = 8f;
    public float cameraSpeed = 3f;

    /**private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Cursor i detta fall = Muspekaren, detta låser muspekaren till mitten av skärm och gör osynlig
        Cursor.visible = false;
    }**/
    private void LateUpdate()
    {
        if(Time.timeScale != 0)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed;

            if(newRotationY > 280 && newRotationY < 300) 
            {
                newRotationY = Mathf.Clamp(newRotationY, 300f, 360f);
            }
            if(newRotationY > 80 && newRotationY < 90)
            {
                newRotationY = Mathf.Clamp(newRotationY, 0f, 80f);
            }

            Vector3 desiredRotation = new Vector3(newRotationY, newRotationX, 0f);
            transform.localEulerAngles = desiredRotation;

            float followDistance = maxFollowDistance;

            if(Physics.SphereCast(target.position, .10f, -transform.forward, out RaycastHit hitinfo, maxFollowDistance))
            {
                followDistance = Mathf.Clamp(followDistance, 1, hitinfo.distance);
            }

            Vector3 desiredPosition = target.position - transform.forward * followDistance;
            transform.position = desiredPosition;
        }
    }
}
