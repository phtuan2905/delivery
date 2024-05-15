using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public List<GameObject> Ways;
    public bool Change = false;
    public int UnblockWayIndex;
    public float TrafficTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("ControlTraffic");
    }

    IEnumerator ControlTraffic()
    {
        if (!Change)
        {
            Change = true;

            Ways[UnblockWayIndex].transform.localPosition += new Vector3(0f, 5f, 0f);

            yield return new WaitForSeconds(TrafficTime);

            Ways[UnblockWayIndex].transform.localPosition -= new Vector3(0f, 5f, 0f);

            if (UnblockWayIndex == Ways.Count - 1)
            {
                UnblockWayIndex = 0;
            }
            else
            {
                UnblockWayIndex++;
            }
            Change = false;
        }
    }
}
