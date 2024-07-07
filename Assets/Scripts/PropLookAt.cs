using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLookAt : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
    }
}
