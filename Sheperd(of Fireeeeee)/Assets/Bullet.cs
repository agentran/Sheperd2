using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public float Force;
    private void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Force *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BaseStats>().Health = 0;
            Destroy(transform.gameObject);
        }
    }
}
