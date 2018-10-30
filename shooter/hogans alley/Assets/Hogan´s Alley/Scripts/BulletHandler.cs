using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour {
    private Rigidbody rb;
    private AudioSource audioSource;
    public ParticleSystem ps;
    public AudioClip audioClipHit;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //ps = transform.FindChild();
	}
	
    public void Shoot (Vector3 director)
    {
        Start();
        rb.AddForce(director, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        ps.Play();
        //audioSource.clip = audioClipHit;
        audioSource.PlayOneShot(audioClipHit);


    }
	// Update is called once per frame
//	void Update () {
		
//	}
}
