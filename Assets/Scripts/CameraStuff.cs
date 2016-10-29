using UnityEngine;
using System.Collections;

public class CameraStuff : MonoBehaviour {

    public GameObject target;
    private float distanceZ;

    void Start()
    {
        distanceZ = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, distanceZ);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //let the player slide the camera up a fixed distance
        }
    }
}
