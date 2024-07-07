using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckDelivery : MonoBehaviour
{
    public bool GetDelivery = false;
    public List<GameObject> Deliveries;
    public Transform DeliveryPosition;
    public MisMaSys MissionManagementSystem;
    public MissionTimer MissionTimer;
    //public Image PackageIcon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick-up Spot") && !GetDelivery)
        {
            //PackageIcon.color = new Color(255, 255, 255, 255);
            GetDelivery = true;
            GameObject cloneDelivery = Instantiate(Deliveries[Random.Range(0, Deliveries.Count)], DeliveryPosition);
            cloneDelivery.transform.position = DeliveryPosition.position;

        }
        else if (other.gameObject.CompareTag("Drop-off Spot") && GetDelivery) 
        {
            MissionManagementSystem.onMission = false;
            MissionTimer.time = MissionTimer.MaxTime;
            MissionTimer.MissionCount++;
            GetDelivery = false;
            Destroy(other.gameObject);
            foreach (Transform child in DeliveryPosition) 
            {
                if (child.gameObject.CompareTag("Delivery"))
                {
                    Destroy(child.gameObject);
                }
            }
            //PackageIcon.color = new Color(176, 176, 176, 190);
        }
    }
}
