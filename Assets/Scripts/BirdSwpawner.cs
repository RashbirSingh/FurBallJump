using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSwpawner : MonoBehaviour {

    public float maxYpos;
    public float SpawnTime;
    public GameObject Bird1;
    public GameObject Bird2;
    public GameObject Bird3;
    public GameObject Bird4;

	// Use this for initialization
	void Start () {
       // StartSpwaningBirds();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StopSpwaningBirds(){
        CancelInvoke("SpwanBird");
    }

    public void StartSpwaningBirds(){
        InvokeRepeating("SpwanBird", 0.2f + Time.deltaTime, SpawnTime);
    }

    void SpwanBird(){
        Instantiate(Bird1, new Vector3(transform.position.x + Random.Range(4, 7), Random.Range(-maxYpos, maxYpos) + Random.Range(0, 6),0),Quaternion.identity);
        Instantiate(Bird2, new Vector3(transform.position.x + Random.Range(5, 8), Random.Range(-maxYpos, maxYpos) + Random.Range(-1, 1), 0), Quaternion.identity);
        Instantiate(Bird3, new Vector3(transform.position.x + Random.Range(6, 9), Random.Range(-maxYpos, maxYpos) + Random.Range(-4, 1), 0), Quaternion.identity);
        Instantiate(Bird4, new Vector3(transform.position.x + Random.Range(8, 10), Random.Range(-maxYpos, maxYpos) + Random.Range(0, 8), 0), Quaternion.identity);
       
    }
}
