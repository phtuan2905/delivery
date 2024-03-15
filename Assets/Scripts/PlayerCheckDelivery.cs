using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckDelivery : MonoBehaviour
{
    public bool GetDelivery = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDelivery();
    }

    void CheckDelivery()
    {
        GetDelivery = false;
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Delivery"))
            {
                GetDelivery = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Drop-off Spot") && GetComponent<PlayerCheckDelivery>().GetDelivery)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Delivery"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
