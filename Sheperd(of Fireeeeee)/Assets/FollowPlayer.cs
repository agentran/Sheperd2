using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject Player;

    public float speed;

    private Quaternion _lookRotation;

    public float _rotateSpeed;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if(Player.GetComponent<PlayerScript>().isMoving)
        {

            Vector3 _direction = (Player.transform.position - transform.position).normalized;

            _lookRotation = Quaternion.LookRotation(_direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _rotateSpeed);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }

    }
}
