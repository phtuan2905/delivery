using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionTimer : MonoBehaviour
{
    public float time;
    public float MaxTime;
    public int MissionCount;

    public Image CountDownUI;
    public GameObject EndGamePanel;
    public TextMeshProUGUI DeliveryCount;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("CountDown");
        DeliveryCount.text = MissionCount.ToString();
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
            time = MaxTime;
        }
    }
}
