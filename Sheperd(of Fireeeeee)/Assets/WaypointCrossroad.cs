using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCrossroad : MonoBehaviour {

    public GameObject Point1;
    public GameObject Point2;

	// Use this for initialization
	void Start () {
        GetComponent<NextPoint>().NextPointLoc = Point1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
