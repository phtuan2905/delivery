using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisMaSys : MonoBehaviour
{
    public GameObject Delivery;
    public GameObject DropoffSpot;
    public bool isMission = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDelivey();
    }

    void CheckDelivey()
    {
        if (!isMission)
        {
            GameObject cloneDelivery = Instantiate(Delivery, transform);
            cloneDelivery.transform.position = new Vector3(Random.Range(-100, 101), 0.25f, Random.Range(-100, 101));
            GameObject cloneDropoffSpot = Instantiate(DropoffSpot, transform);
            cloneDropoffSpot.transform.position = new Vector3(Random.Range(-100, 101), 1f, Random.Range(-100, 101));
            isMission = true;
        }
        else
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Drop-off Spot") && child.GetComponent<DropOffSpot>().isDelivered)
                {
                    Destroy(child.gameObject);
                    isMission = false;
                }
            }
        }
    }
}
