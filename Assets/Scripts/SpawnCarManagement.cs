using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SpawnCarManagement : MonoBehaviour
{
    public int NumberOfCarsSpawn;
    public List<GameObject> Cars;
    public bool NearPlayer = false;
    public bool PlayerOnIt = false;
    public List<GameObject> NearRoads;
    public int CarsNumb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SpawnCar");
        //SpawnCar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOnIt = true;
            for (int i = 0; i < NearRoads.Count; i++)
            {
                NearRoads[i].GetComponent<SpawnCarManagement>().NearPlayer = true;
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            CarsNumb++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOnIt = true;
            for (int i = 0; i < NearRoads.Count; i++)
            {
                NearRoads[i].GetComponent<SpawnCarManagement>().NearPlayer = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOnIt = false;
            for (int i = 0; i < NearRoads.Count; i++)
            {
                NearRoads[i].GetComponent<SpawnCarManagement>().NearPlayer = false;
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            CarsNumb--;
        }
    }


    public bool IsSpawning = false;
    public List<int> CarsSpawnPos = new List<int>();
    IEnumerator SpawnCar()
    {
        if (NearPlayer && CarsNumb == 0 && !PlayerOnIt && !IsSpawning)
        {
            //Debug.Log("Start");
            IsSpawning = true;
            CarsSpawnPos.Clear();
            CarsSpawnPos.Add(-1);
            IsSpawning = true;
            for (int i = 0; i < NumberOfCarsSpawn; i++)
            {
                int randomPos = Random.Range(0, transform.childCount);
                while (CarsSpawnPos.Contains(randomPos) || transform.GetChild(randomPos).name == "Corner")
                {
                    randomPos = Random.Range(0, transform.childCount);
                }
                CarsSpawnPos.Add(randomPos);

                Quaternion Angle;
                if (transform.GetChild(randomPos).localPosition.z > 0)
                {
                    if (transform.GetChild(randomPos).rotation.y == 90)
                    {
                        Angle = Quaternion.Euler(new Vector3(0, 90, 0));
                        
                    }
                    else
                    {
                        Angle = Quaternion.Euler(new Vector3(0, 0, 0));
                        
                    }
                }
                else
                {
                    if (transform.GetChild(randomPos).rotation.y == 90)
                    {
                        Angle = Quaternion.Euler(new Vector3(0, -90, 0));
                    }
                    else
                    {
                        Angle = Quaternion.Euler(new Vector3(0, 180, 0));
                    }
                }
                GameObject clone = Instantiate(Cars[Random.Range(0, Cars.Count)], new Vector3(transform.GetChild(randomPos).position.x, 0.15f, transform.GetChild(randomPos).position.z), Angle);
                //clone.transform.position = new Vector3(transform.GetChild(randomPos).position.x, 0.1f, transform.GetChild(randomPos).position.z);

            }
            //Debug.Log("End");
            yield return null;
            IsSpawning = false;
        }
    }
}
