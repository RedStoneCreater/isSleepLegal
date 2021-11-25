using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public Slider slider;
    public GameObject killCam;
    public GameObject enemy;
    public GameObject gameOverScreen;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void Update()
    {
        if(slider.value == 0)
        {
            Destroy(player);
            Instantiate(killCam, enemy.transform);
            gameOverScreen.SetActive(true);
        }
    }
}

