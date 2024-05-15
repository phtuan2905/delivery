using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckDelivery : MonoBehaviour
{
    public bool GetDelivery = false;
    public List<GameObject> Deliveries;
    public Transform DeliveryPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick-up Spot"))
        {
            GetDelivery = true;
            GameObject cloneDelivery = Instantiate(Deliveries[Random.Range(0, Deliveries.Count)], DeliveryPosition);
            cloneDelivery.transform.position = DeliveryPosition.position;
        }
        else if (other.gameObject.CompareTag("Drop-off Spot"))
        {
            foreach (Transform child in DeliveryPosition) 
            {
                if (child.gameObject.CompareTag("Delivery"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
