using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GateScript : MonoBehaviour {


    private HerdMovement[] herds;
	// Use this for initialization
	void Start () {
        herds = FindObjectsOfType<HerdMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (HerdMovement herd in herds)
        {
            if (herd != null)
            {
                if (Vector3.Distance(transform.position, herd.transform.position) <= 3f)
                {
                    herd.CalledStop = true;
                }
            }
        }
	}

}
