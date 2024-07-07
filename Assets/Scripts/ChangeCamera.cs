using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject MainCamera;
    public bool CameraMode = false;

    public void ChangingCamera()
    {
        if (!CameraMode)
        {
            CameraMode = true;
            //MainCamera.transform.localPosition = Vector3.MoveTowards(MainCamera.transform.localPosition, new Vector3(0, 1.8f, -0.2f), 2 * Time.deltaTime);
            MainCamera.transform.localPosition = new Vector3(0, 1.8f, -0.2f);
            MainCamera.GetComponent<Camera>().fieldOfView = 70;
        }
        else
        {
            CameraMode = false;
            //MainCamera.transform.localPosition = Vector3.MoveTowards(MainCamera.transform.localPosition, new Vector3(0, 4, -5.8f), 2 * Time.deltaTime);
            MainCamera.transform.localPosition = new Vector3(0, 4, -5.8f);
            MainCamera.GetComponent<Camera>().fieldOfView = 50;
        }
    }
}
