using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    public Vector3 Waypoint;
    public int speed;
    public Rigidbody Obstacle;
    public GameObject HitBox;
    //public bool firstRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        Obstacle = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            int randomWaypoint = Random.Range(0, other.GetComponent<Waypoint>().nextWaypointPosis.Count);
            Waypoint = other.GetComponent<Waypoint>().nextWaypointPosis[randomWaypoint];
        }
        else if (other.gameObject.CompareTag("Road") && other.GetComponent<SpawnCarManagement>().NearPlayer == false && other.GetComponent<SpawnCarManagement>().PlayerOnIt == false)
        {
            StartCoroutine(DestroyObstacle(other.gameObject));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Road") && other.GetComponent<SpawnCarManagement>().NearPlayer == false && other.GetComponent<SpawnCarManagement>().PlayerOnIt == false) 
        {
            StartCoroutine(DestroyObstacle(other.gameObject));
        }
        /*
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine("DestroyObstacle");
        }
        */
    }

    void Moving()
    {
        Vector3 direction = new Vector3(Waypoint.x - Obstacle.position.x, 0f, Waypoint.z - Obstacle.position.z).normalized;
        Quaternion Rotation = Quaternion.LookRotation(direction, Vector3.up);
        Obstacle.velocity = new Vector3(speed * direction.x, Obstacle.velocity.y, speed * direction.z);
        /*if (!firstRotate)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 36000f * Time.deltaTime);
            firstRotate = true;
        }*/
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 360f * Time.deltaTime);
        if (HitBox.GetComponent<CarHitBox>().Block == true)
        {
            Obstacle.velocity = Vector3.zero;
        }

        if (Waypoint.x == Obstacle.position.x && Waypoint.z == Obstacle.position.z)
        {
            StartCoroutine(DestroyObstacle(null));
        }
    }

    IEnumerator DestroyObstacle(GameObject other)
    {
        yield return new WaitForSeconds(3f);
        if (other != null) 
        {
            if (other.GetComponent<SpawnCarManagement>().NearPlayer || other.GetComponent<SpawnCarManagement>().PlayerOnIt)
            {
                yield break;
            }
        }
        
        transform.position -= new Vector3(0, 10, 0);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
