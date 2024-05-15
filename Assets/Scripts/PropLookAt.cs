using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLookAt : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.LookAt(Player.transform.position);
    }
}
