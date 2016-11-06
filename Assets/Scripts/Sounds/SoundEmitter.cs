using UnityEngine;
using System.Collections;

public class SoundEmitter : MonoBehaviour {

    public float maxRadius;
    public AudioSource soundToEmit;
    public float soundWaveDuration;
    public GameObject wavePrefab;
    public float testingMoveSpeed;
    public Vector3 testPoint1;
    public Vector3 testPoint2;
    private bool testGoing1 = true;

    private LayerMask startMask;
    private float soundDetectionStart = 0f;
    private float soundDetectionEnd = 0f;
    private bool allowSound = true;
    private bool displayingWaves = false;
    private GameObject soundWaves;
    //play sound
    //when sound is played allow the sound collider to be detected
    //if a collision is found with the players perception radius, display sound waves at location.

    // Use this for initialization
    void Start()
    {
        //get the starting LayerMask
        startMask = gameObject.layer;
    }

    void Update()
    {

        //slide sound object for testing
        float step = testingMoveSpeed * Time.deltaTime;
        if(testGoing1)
        {
            transform.position = Vector3.MoveTowards(transform.position, testPoint1, step);
            if (transform.position == testPoint1)
            {
                testGoing1 = false;
            }
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, testPoint2, step);
            if (transform.position == testPoint2)
            {
                testGoing1 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.T) && allowSound)
        {
            //play sound
            soundToEmit.Play();
            //allow the sound collider to be detected
            gameObject.layer = LayerMask.NameToLayer("SoundMask");
            //set the ending time of when the gameobject can be detected
            soundDetectionStart = Time.time;
            soundDetectionEnd = soundDetectionStart + soundWaveDuration;
            allowSound = false;

            Debug.Log("Sound Played. StartTime: " + soundDetectionStart + " EndTime: " + soundDetectionEnd);
        }

        if (soundDetectionStart != 0 && soundDetectionEnd != 0 && Time.time >= soundDetectionEnd){
            //reset everything 
            gameObject.layer = startMask;
            soundDetectionStart = 0;
            soundDetectionEnd = 0;
            allowSound = true;
            Destroy(soundWaves);
            displayingWaves = false;
            Debug.Log("Sound can be played again");
        }

    }

    private void DisplaySoundWaves()
    {
        Debug.Log("Sound WAVES");
        if (!displayingWaves){
            displayingWaves = true;
            soundWaves = Instantiate(wavePrefab, gameObject.transform.position, Quaternion.identity, transform) as GameObject;
        }
    }

}
