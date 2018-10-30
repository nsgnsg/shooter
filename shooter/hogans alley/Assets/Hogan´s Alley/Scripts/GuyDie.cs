using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyDie : MonoBehaviour {
    float max, min;
    public float pointsWhenDie = -100;
    public float pointsWhenHit = 100;
    //public float pointsWhenMiss = -200;
    private Animator animator;
    private float timeZero;
    private float waitTime;
    private float minTime = 4f;
    private float maxTime = 10f;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        timeZero = Time.realtimeSinceStartup;
        waitTime = Random.Range(minTime, maxTime);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.realtimeSinceStartup > (waitTime + timeZero  ))
        {
            animator.SetTrigger("EndNow");
            Destroy(animator.gameObject, 1f);
            GamePlayManager.GetInstance().points += pointsWhenDie;
            this.enabled = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "bullet")
        {
            animator.SetTrigger("EndNow");
            GamePlayManager.GetInstance().points += pointsWhenHit;
            Destroy(animator.gameObject, 0f);
            
            this.enabled = false;
        }
        
    }

}

