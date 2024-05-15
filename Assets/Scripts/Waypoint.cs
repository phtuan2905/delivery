using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> nextWaypoints;
    public List<Vector3> nextWaypointPosis;
    // Start is called before the first frame update
    void Start()
    {
        FindNextWaypoint();

        for (int i = 0; i < nextWaypointPosis.Count; i++)
        {
            nextWaypointPosis[i] = nextWaypoints[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindNextWaypoint()
    {
        int Index = transform.GetSiblingIndex();
        if (Index + 1 == transform.parent.childCount)
        {
            return;
        }
        else
        {
            if (transform.parent.GetChild(Index + 1).localPosition.z > 0 && transform.localPosition.z > 0)
            {
                nextWaypoints.Add(transform.parent.GetChild(Index + 1).gameObject);
            }
            else if (transform.parent.GetChild(Index + 1).localPosition.z < 0 && transform.localPosition.z < 0)
            {
                nextWaypoints.Add(transform.parent.GetChild(Index + 1).gameObject);
            }
            else
            {
                return;
            }
        }
        
    }
}
