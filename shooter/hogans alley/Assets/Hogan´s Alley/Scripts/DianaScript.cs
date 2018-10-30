using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaScript : MonoBehaviour {
   
    public GameObject camara;
    public Transform spawnPoint;
    private AudioSource audioSource;
    public AudioClip audioClipHit;
    private bool modo = true;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet" && !(SpawnManager.diana)  && modo )
        {
            audioSource.PlayOneShot(audioClipHit);
            SpawnManager.disparoDiana();
            camara.transform.position = spawnPoint.position;
            
        }

        else if (other.gameObject.tag == "bullet" && SpawnManager.diana && !modo)
        {
            audioSource.PlayOneShot(audioClipHit);
            SpawnManager.disparoDiana();
            camara.transform.position = spawnPoint.position;
        }
        modo = !modo;


    }
}
