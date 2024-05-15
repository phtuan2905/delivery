using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisMaSys : MonoBehaviour
{
    public GameObject PickupSpot;
    public GameObject DropoffSpot;
    public GameObject Missions;
    bool onMission = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMission();
    }
    
    void SpawnMission()
    {
        if (!onMission)
        {
            int randomPickupSpot = Random.Range(0, transform.childCount);
            int randomDropoffSpot = Random.Range(0, transform.childCount);
            while (CheckDistance(transform.GetChild(randomPickupSpot).position, transform.GetChild(randomDropoffSpot).position))
            {
                randomDropoffSpot = Random.Range(0, transform.childCount);
            }

            GameObject clonePickupSpot = Instantiate(PickupSpot, Missions.transform);
            clonePickupSpot.transform.position = transform.GetChild(randomPickupSpot).position;
            //clonePickupSpot.transform.position += new Vector3(0, 0, 0);
            GameObject cloneDropoffSpot = Instantiate(DropoffSpot, Missions.transform);
            cloneDropoffSpot.transform.position = transform.GetChild(randomDropoffSpot).position;
            //cloneDropoffSpot.transform.position += new Vector3(0, 0, 0);

            onMission = true;
        }
        else
        {
            foreach (Transform child in Missions.transform)
            {
                if (child.gameObject.CompareTag("Drop-off Spot") && child.GetComponent<DropOffSpot>().isDelivered)
                {
                    Destroy(child.gameObject);
                    onMission = false;
                    Missions.GetComponent<MissionTimer>().time = Missions.GetComponent<MissionTimer>().MaxTime;
                    Missions.GetComponent<MissionTimer>().MissionCount++;
                }
            }
            
        }
    }

    bool CheckDistance(Vector3 coordinate1, Vector3 coordinate2)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(coordinate1.x - coordinate2.x, 2f) + Mathf.Pow(coordinate1.z - coordinate2.z, 2f));
        if (distance <= 50f)
        {
            return true;
        }
        return false;
    }

}
