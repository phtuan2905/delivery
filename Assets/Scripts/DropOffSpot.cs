using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffSpot : MonoBehaviour
{
    public bool isDelivered = false;
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
        if (other.transform.CompareTag("Player") && other.gameObject.GetComponent<PlayerCheckDelivery>().GetDelivery)
        {
            isDelivered = true;
        }
    }
}
