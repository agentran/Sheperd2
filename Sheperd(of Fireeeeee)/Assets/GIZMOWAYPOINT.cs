using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIZMOWAYPOINT : MonoBehaviour {

    public float pointRadius = 1.0f;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pointRadius);
    }
}
