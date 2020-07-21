using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHealth : MonoBehaviour
{

    [SerializeField] private float health = 5;
    [SerializeField] private float currentHealth = 5;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Slider healthSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        healthSlider.value = currentHealth / health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            currentHealth--;
            healthSlider.value = currentHealth / health;
        }
    }
}
