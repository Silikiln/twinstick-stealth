using UnityEngine;
using System.Collections;

public class MoveLight : MonoBehaviour {
    private Transform pos;
    private Rigidbody vel;
    private float delta = 1f;

	// Use this for initialization
	void Start () {
        pos = this.GetComponent<Transform>();
        vel = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
            vel.AddForce(new Vector3(0, 0, delta));
        if (Input.GetKey(KeyCode.S))
            vel.AddForce(new Vector3(0, 0, -delta));
        if (Input.GetKey(KeyCode.A))
            vel.AddForce(new Vector3(-delta, 0, 0));
        if (Input.GetKey(KeyCode.D))
            vel.AddForce(new Vector3(delta, 0, 0));
	}
}
