using UnityEngine;
using System.Collections;

public class MoveLight : MonoBehaviour {

    private Rigidbody rb;
    public float runSpeed = 0f;
    public float normalSpeed = 0f;
    public float creepSpeed = 0f;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
    //called based on time use for physics
    void FixedUpdate(){
        //Time for physics
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        rb.velocity = Vector3.zero;

        //if any of the movement buttons(joysticks...) are being moved
        if(moveHorizontal != 0 || moveVertical != 0){
            //check if any modifiers are being used
            if (Input.GetKey(KeyCode.LeftShift)){
                //Use sprinting speed
                rb.velocity = movement * runSpeed;
            }
            else if (Input.GetKey(KeyCode.Space)){
                //use creeping speed
                rb.velocity = movement * creepSpeed;
            }
            else {
                //use normal move speed
                rb.velocity = movement * normalSpeed;
            }
        }
    }

	// Update is called once per frame
	void Update () {

	}
}
