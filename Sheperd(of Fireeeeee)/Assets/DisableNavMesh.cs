using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DisableNavMesh : MonoBehaviour {

    public GameManagerScript gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<NavMeshAgent>().enabled = false;
            gm.UpdateScore(10f);
        }
    }
}
