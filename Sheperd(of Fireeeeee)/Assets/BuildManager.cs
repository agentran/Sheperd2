using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public PlayerScript player;
    [SerializeField]
    private GameObject Temp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Temp != null)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        Temp.transform.position = hit.point;
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        player.isBuilding = false;
                        Temp = null;
                    }
                }
            }
            if (Input.touchCount == 2)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                     //   Temp.transform.Rotate(Vector3.up, )
                    }
                }
            }
        }
    }

    public void MoveAndPlaceObject(Object ORIGINAL)
    {
        Temp = Instantiate(ORIGINAL, Vector3.zero, Quaternion.identity) as GameObject;
        player.isBuilding = true;
        
    }
}
