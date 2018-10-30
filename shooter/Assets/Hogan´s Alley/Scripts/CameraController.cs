using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraController : MonoBehaviour {
    public float camSens = 0.5f;
    public GameObject bala;
    Vector3 lastMouse = new Vector3(255,255,255);
    float impulso = 10f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!UnityEngine.XR.XRSettings.enabled){
            CameraMovement();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ShotABullet();
        }
        
    }

    void CameraMovement()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }

    void ShotABullet()
    {
        GameObject cloneBullet = Instantiate(bala, transform.position, transform.rotation);
        BulletHandler bh = cloneBullet.GetComponent<BulletHandler>();
        bh.Shoot(transform.forward * impulso);
        Destroy(cloneBullet, 3f);
    }
}
