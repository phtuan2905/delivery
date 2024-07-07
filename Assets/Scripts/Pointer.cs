using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject Missions;
    public PlayerCheckDelivery Player;
    Vector3 Target;
    Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        PointAt();
    }

    void FollowPlayer()
    {
        transform.position = Player.transform.position;
        transform.position += new Vector3(0, 2.5f, 0);
    }

    void PointAt()
    {
        if (Player.GetDelivery)
        {
            foreach (Transform child in Missions.transform)
            {
                if (child.gameObject.CompareTag("Drop-off Spot"))
                {
                    Target = child.position;
                }
            }
        }
        else
        {
            foreach (Transform child in Missions.transform)
            {
                if (child.gameObject.CompareTag("Pick-up Spot"))
                {
                    Target = child.position;
                }
            }
        }
        
        Target = new Vector3(Target.x, transform.position.y, Target.z);
        transform.LookAt(Target);
    }
}
