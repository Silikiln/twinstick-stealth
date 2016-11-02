using UnityEngine;
using System.Collections;

public class CameraStuff : MonoBehaviour {
    //init target based vars
    public GameObject target;
    private Vector3 targetPosition;

    //init camera vars
    private float distanceY;
    public float cameraSpeed = 5f;
    public float cameraClampModX = 2f;
    public float cameraClampModZ = 2f;

    void Start()
    {
        distanceY = transform.position.y;
    }

    void Update()
    {
        //get the position of the target
        targetPosition = target.transform.position;

        //determine how the camera should move(toDO: add joystick)
        if (Input.GetKey(KeyCode.LeftShift)){
            //manual camera movement
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraSpeed);

            //Bound the movement based on player position
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, targetPosition.x - cameraClampModX, targetPosition.x + cameraClampModX),
                distanceY,
                Mathf.Clamp(transform.position.z, targetPosition.z - cameraClampModZ, targetPosition.z + cameraClampModZ));
        }
        else{
            //auto movement
            transform.position = new Vector3(targetPosition.x, distanceY, targetPosition.z);
        }
    }
}
