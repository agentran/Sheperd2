using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HerdMovement : MonoBehaviour {

    NavMeshAgent m_Agent;
    public List<Transform> waypoints;
    public GameObject wayPointsParent;
    public bool CalledStop = false;
    public List<GameObject> BehindMe;
    public float CheckInFrontLength = 1;
    public GameObject inFrontOfMe;

    public GameObject intialpointObject;
    private Vector3 initialPoint;
    // Use this for initialization
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        /*for (int i = 0; i < wayPointsParent.transform.childCount; i++)
        {
            waypoints.Add(wayPointsParent.transform.GetChild(i));
        }*/

        intialpointObject = GameObject.FindGameObjectWithTag("First Point");
        initialPoint = intialpointObject.transform.position;
        m_Agent.SetDestination(initialPoint);

        inFrontOfMe = GetInFrontofMe();



    }

    // Update is called once per frame
    void Update()
    {
        StoppingClick();
        if (m_Agent.enabled)
        {
            if (CalledStop)
            {
                m_Agent.isStopped = true;
            }
            if (!CalledStop)
            {
                m_Agent.isStopped = false;
            }
            if (inFrontOfMe != null)
            {
                if (Vector3.Distance(transform.position, inFrontOfMe.transform.position) <= 2.5f && CheckIfInFrontOfMeStopped())
                {
                    m_Agent.isStopped = true;
                }
            }

        }

        //WayPointsMove();

    }

    /*public void WayPointsMove()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            Transform waypoint = null;
            if (waypoints[i] != null)
            {
                waypoint = waypoints[i];
            }
            if (!m_Agent.pathPending)
            {

                if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
                {
                    if (waypoints[i] != null)
                    {
                        waypoints.RemoveAt(i);
                    }
                    if (!m_Agent.hasPath || m_Agent.velocity.sqrMagnitude == 0f)
                    {
                        m_Agent.SetDestination(waypoint.position);

                    }
                }
            }
        }

    }*/



    public void GetBehindMe()
    {
        Ray ray = new Ray
        {
            origin = transform.position,
            direction = Vector3.left
        };
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, Vector3.left, 100.0F);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if(hit.transform.CompareTag("Player"))
            {
                BehindMe.Add(hit.transform.gameObject);
            }

        }

        BehindMe.RemoveAt(0);
    }

    public void StoppingClick()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && touch.phase == TouchPhase.Ended)
                {
                    CalledStop = !CalledStop;
                }
            }
        }
    }


    public bool CheckIfInFrontOfMeStopped()
    {
        if(inFrontOfMe.GetComponent<NavMeshAgent>().enabled && inFrontOfMe.GetComponent<NavMeshAgent>().isStopped)
        {
            return true;
        }
        return false;
    }

    public GameObject GetInFrontofMe()
    {
        Ray ray = new Ray
        {
            direction = transform.TransformDirection(Vector3.forward),
            origin = transform.position
        };

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform != transform && hit.transform.CompareTag("Player"))
            {
                return hit.transform.gameObject;
            }
        }

        return null;
    }


}
