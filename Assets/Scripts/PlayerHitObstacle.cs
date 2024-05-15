using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitObstacle : MonoBehaviour
{
    public bool IsHit;
    public GameObject EndGamePanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("SideRoad"))
        {
            if (transform.GetComponent<PlayerControl>().speed > 12)
            {
                IsHit = true;
                EndGamePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
