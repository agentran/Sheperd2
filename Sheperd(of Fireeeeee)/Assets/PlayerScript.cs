using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public bool isMoving;
    public bool isBuilding;
    public float speed;

    private Quaternion _lookRotation;

    public float _rotateSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isBuilding)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        isMoving = true;
                        Vector3 _direction = (hit.point - transform.position).normalized;

                        _lookRotation = Quaternion.LookRotation(_direction);

                        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _rotateSpeed);
                        transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);

                    }
                    if (hit.collider.CompareTag("MoveOnObject"))
                    {
                        isMoving = true;
                        Vector3 _direction = (hit.point - transform.position).normalized;

                        _lookRotation = Quaternion.LookRotation(_direction);

                        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _rotateSpeed);
                        transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);

                    }
                }

            }
            else
            {
                isMoving = false;

            }
        }
        else
        {
            isMoving = false;
        }
	}
}
