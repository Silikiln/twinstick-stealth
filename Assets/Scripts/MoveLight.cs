using UnityEngine;
using System.Collections;
using System;

public class MoveLight : MonoBehaviour {

    private Rigidbody rb;
    public float runSpeed = 0f;
    public float normalSpeed = 0f;
    public float defaultRotationX;
    public float perceptionRadius;
    public float soundCheckRate;

    private int soundLayerMaskIndex = 1 << 8;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
        StartCoroutine(SoundCheckRepeat(soundCheckRate));
    }

    private IEnumerator SoundCheckRepeat(float soundCheckRate)
    {
        while (true){
            SoundCheck();
            //Debug.Log("Sound Emit: " + Time.time);
            yield return new WaitForSeconds(soundCheckRate);
        }
    }

    //called based on time use for physics(50 times per second)
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
        transform.eulerAngles = new Vector3(defaultRotationX, 0, Mathf.Atan2((mousePosition.z - transform.position.z), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);

    }

    //toDo, investigate using a layermask to selectively ignore colliders when casting ray(anything that is not the player)
    private void SoundCheck()
    {
        //get a list of all colliders in the pulse
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, perceptionRadius, soundLayerMaskIndex);
        foreach (Collider col in hitColliders)
        {
            Debug.Log("HIT COLLIDER");
            if (col.gameObject.tag == "SoundObj")
            {
                //toDo use sendMessage to call a function on the player if hit
                Debug.Log("Detected SoundObj: " + col.gameObject.name);

                //use sendMessage to call the play soundWave function
                col.gameObject.SendMessage("DisplaySoundWaves");
            }
        }

    }

    //use cyan for sounds
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, perceptionRadius);
    }

}
