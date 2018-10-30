using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    private static GamePlayManager instance;

    private float timezero;
    private float playingtime = 60f;
    public TextMesh textmesh;

    public float points = 0f;


	// Use this for initialization
	void Start () {
        timezero = Time.realtimeSinceStartup;
        instance = this;
	}
	
    public static GamePlayManager GetInstance()
    {
       return instance;
    }
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup > (timezero + playingtime)  )
        {
            Debug.Log("Fiin");
            Application.Quit();
        }
        textmesh.text = "Time : " + (int)(Time.realtimeSinceStartup - timezero) + "\nScore : " + points;
    }
}
