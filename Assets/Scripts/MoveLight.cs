using UnityEngine;
using System.Collections;

public class MoveLight : MonoBehaviour {

    private Rigidbody rb;
    public float runSpeed = 0f;
    public float normalSpeed = 0f;
    public float defaultRotationX;

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

        //if any of the movement buttons(toDO: controller support) are being moved
        if (moveHorizontal != 0 || moveVertical != 0){
            //Determine which movement type to use.  (toDO: change runSpeed to call altMove on character class)
            rb.velocity = movement * (Input.GetKey(KeyCode.Space) ?  runSpeed : normalSpeed);
        }

        //This rotates the player to face the mouse(toDO: controller support)
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mousePosition.y;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log(Input.mousePosition + " -> " + mousePosition);
        transform.eulerAngles = new Vector3(defaultRotationX, 0, Mathf.Atan2((mousePosition.z - transform.position.z), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);
        //Debug.Log(transform.eulerAngles);

    }

	// Update is called once per frame
	void Update () {

    }

}
