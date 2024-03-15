using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomSpawn : MonoBehaviour
{
    private Vector3 spawnLocation;
    public bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckWall()
    {
        if (!isSpawning)
        {
            spawnLocation = new Vector3(Random.Range(-50, 50), 5, Random.Range(-25, 25));
            transform.position = spawnLocation;
            isSpawning = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {

        }
    }
}
