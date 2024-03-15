using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.SetParent(collision.transform);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.position = new Vector3(collision.transform.position.x, 1.25f, collision.transform.position.z);
        }
    }
}
