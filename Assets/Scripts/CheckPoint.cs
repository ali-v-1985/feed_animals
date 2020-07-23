using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Text pointText;
    
    [SerializeField]
    private Canvas levelWonCanvas;
    
    [SerializeField]
    private Text levelWonText;
    
    private WellFedAnimalEvent _wellFedAnimalEvent;

    private int _point = 0;
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private int pointPerLevel = 50;

    // Start is called before the first frame update
    void Start()
    {
        EatFood.RaiseWellFedAnimalEvent += HandleWellFedAnimalEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (_point >= level * pointPerLevel)
        {
            levelWonText.text = $"Won level {level} with {_point} points!";
            levelWonCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void HandleWellFedAnimalEvent(object sender, WellFedAnimalEventArgs e)
    {
        _point = (int) (Int32.Parse(pointText.text) + e.AnimalPoint);
        pointText.text = _point.ToString();
    }
}