using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageIcon : MonoBehaviour
{
    public PlayerCheckDelivery player;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Image>().color = new Color(176, 176, 176, 190);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetDelivery)
        {
            transform.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            transform.GetComponent<Image>().color = new Color(176, 176, 176, 190);
        }
    }
}
