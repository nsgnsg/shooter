using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    public Transform[] spawnPoints1;
    [SerializeField]
    public Transform[] spawnPoints2;
    [SerializeField]
    public GameObject[] prefabs;
    float min = 4f, max = 10f;
    public static bool diana = false;
   
    private bool stop = false;



	// Use this for initialization
	void Start () {
        
            StartCoroutine(SpawnPerson1());
 
    }
	

    IEnumerator SpawnPerson1()
    {
        while (stop == false)
        {
            yield return new WaitForSeconds(Random.Range(min,max));
            if (!diana)
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPoints1[Random.Range(0, spawnPoints1.Length)]);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(min, max));
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPoints2[Random.Range(0, spawnPoints2.Length)]);
            }
        }

    }

    
    // Update is called once per frame
    public void Stop()
    {
        stop = true;
    }

    public static void disparoDiana()
    {
        
        diana = !diana;
        
    }

    void Update () {
		
	}
}
