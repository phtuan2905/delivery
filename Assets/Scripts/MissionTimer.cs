using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTimer : MonoBehaviour
{
    public float time;
    public float MaxTime;
    public int MissionCount;

    public Image CountDownUI;
    public GameObject EndGamePanel;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("CountDown");   
    }

    bool startCD = false;
    IEnumerator CountDown()
    {
        if (!startCD) 
        {
            startCD = true;
            yield return new WaitForSeconds(0.1f);
            time -= 0.1f;
            CountDownUI.rectTransform.sizeDelta = new Vector2((time / MaxTime) * 340f, 15);
            startCD = false;
        }

        if (time <= 0)
        {            
            EndGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
