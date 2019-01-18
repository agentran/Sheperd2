using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject ShotPrefab;
    public float Timer;
    public float ShotsCount;
    public float timeLeft;
	// Use this for initialization
	void Start () {
        timeLeft = Timer;
	}
	
	// Update is called once per frame
	void Update () {

        if(timeLeft <= 0)
        {
           GameObject temp = Instantiate(ShotPrefab, transform.position, Quaternion.identity);
           timeLeft = Timer;

        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }



}
