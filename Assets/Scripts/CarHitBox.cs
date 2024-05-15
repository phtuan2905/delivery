using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitBox : MonoBehaviour
{
    public bool Block = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Player"))
        {
            Block = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Player"))
        {
            Block = false;
        }
    }
}
