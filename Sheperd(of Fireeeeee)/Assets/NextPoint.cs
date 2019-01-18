using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NextPoint : MonoBehaviour {

    public GameObject NextPointLoc;


    Vector3 NextPointLocation;


    private void Update()
    {
        if (NextPointLoc != null)
        {
            NextPointLocation = NextPointLoc.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && NextPointLocation != null)
        {
            other.GetComponent<NavMeshAgent>().SetDestination(NextPointLocation);
        }
    }

}
