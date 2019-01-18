using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherScript : MonoBehaviour {


    public GameObject Crossroad;
    private WaypointCrossroad cross;
    private NextPoint next;



    private void Start()
    {
        cross = Crossroad.GetComponent<WaypointCrossroad>();
        next = Crossroad.GetComponent<NextPoint>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && touch.phase == TouchPhase.Ended)
                {

                    if (next.NextPointLoc == cross.Point1)
                    {
                        next.NextPointLoc = cross.Point2;
                    }
                    else
                    {
                        next.NextPointLoc = cross.Point1;
                    }
                }
            }
        }
    }
}
