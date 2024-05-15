using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            other.GetComponent<PropLookAt>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            other.GetComponent<PropLookAt>().enabled = false;
        }
    }
}
