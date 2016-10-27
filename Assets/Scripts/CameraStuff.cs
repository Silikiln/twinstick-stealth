using UnityEngine;
using System.Collections;

public class CameraStuff : MonoBehaviour {

    public GameObject target;
    private float distanceY;

    void Start()
    {
        distanceY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, distanceY, target.transform.position.z);
    }
}
