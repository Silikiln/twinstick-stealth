using UnityEngine;
using System.Collections;

public class SoundEmitter : MonoBehaviour {

    public float maxRadius;
    public float midRadius;
    public float minRadius;

    private Vector3 soundOrigin;
    

    private Vector3 sphereTest = new Vector3(0.0f,0.0f,2f);

	// Use this for initialization
	void Start () {
        
    }

    void OnEnable()
    {
        StartCoroutine(PulseHandler());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(sphereTest, minRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sphereTest, midRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(sphereTest, maxRadius);
    }

    //toDo, investigate using a layermask to selectively ignore colliders when casting ray(anything that is not the player)
    private void SoundPulse(Vector3 pulseStart, float pulseRadius)
    {
        //get a list of all colliders in the pulse
        Collider[] hitColliders = Physics.OverlapSphere(pulseStart, pulseRadius);
        foreach(Collider col in hitColliders){
           if(col.gameObject.tag == "Player"){
                //toDo use sendMessage to call a function on the player if hit
                Debug.Log("Player hit by sound pulse");
                Debug.Log("OnCoroutine: " + Time.time);
            }
        }
        
    }

    IEnumerator PulseHandler()
    {
        while (true)
        {
            
            SoundPulse(soundOrigin, minRadius);
            yield return new WaitForSeconds(1f);

            SoundPulse(soundOrigin, midRadius);
            yield return new WaitForSeconds(1f);

            SoundPulse(soundOrigin, maxRadius);
            yield return new WaitForSeconds(1f);
        }
    }
}
