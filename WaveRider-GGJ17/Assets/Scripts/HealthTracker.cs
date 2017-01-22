using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{

    private int hitPoints = 3;
    public GameObject[] hearts;
    public Text RestartText;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        takeDamage();
    }

    private void takeDamage()
    {
        --hitPoints;
        hearts[hitPoints].SetActive(false);
        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
            RestartText.enabled = true;
        }
    }
}
