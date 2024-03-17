using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisMaSys : MonoBehaviour
{
    public GameObject Delivery;
    public GameObject DropoffSpot;
    bool onMission = false;
    public GameObject platform;
    public GameObject CheckBox;
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
            GameObject cloneDelivery = Instantiate(Delivery);
            

            GameObject cloneDropoffSpot = Instantiate(DropoffSpot);


            onMission = true;
        }
        else
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Drop-off Spot") && child.GetComponent<DropOffSpot>().isDelivered)
                {
                    Destroy(child.gameObject);
                    onMission = false;
                }
            }
        }
    }
}
