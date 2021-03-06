﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class EatFood : MonoBehaviour
{

    [SerializeField]
    private float howMuchFoodNeed = 10;

    private float _amountHasBeenEaten = 0;
    
    [SerializeField]
    private FoodAndNutrition[] tastyFoodsNutrition;

    private Dictionary<string, float> _foodAndNutrition;
    
    [SerializeField]
    private Slider howMuchToBeFed;

    // Start is called before the first frame update
    void Start()
    {
        _foodAndNutrition = new Dictionary<string, float>();
        foreach (var foodAndNutrition in tastyFoodsNutrition)
        {
            _foodAndNutrition.Add(foodAndNutrition.gameObject.name, foodAndNutrition.nutrition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static event WellFedAnimalEventHandler RaiseWellFedAnimalEvent;
    
    public delegate void WellFedAnimalEventHandler(object sender, WellFedAnimalEventArgs args);
    
    protected virtual void OnRaiseWellFedAnimalEvent(WellFedAnimalEventArgs e)
    {
        var raiseEvent = RaiseWellFedAnimalEvent;
        raiseEvent?.Invoke(this, e);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Food"))
        {
            float _value;
            var foodName = other.gameObject.name.Replace("(Clone)","");
            if (_foodAndNutrition.TryGetValue(foodName, out _value))
            {
                Eat(other, _value);
            }
            else
            {
                GetSick();
            }
        }
    }

    private void GetSick()
    {
        _amountHasBeenEaten -= 2;
        howMuchToBeFed.value = _amountHasBeenEaten / howMuchFoodNeed;
    }

    private void Eat(Collider other, float _foodNutrition)
    {
        _amountHasBeenEaten += _foodNutrition;
        Destroy(other.gameObject);
        howMuchToBeFed.value = _amountHasBeenEaten / howMuchFoodNeed;
        if (_amountHasBeenEaten >= howMuchFoodNeed)
        {
            var animalName = gameObject.name.Replace("(Clone)", "");
            OnRaiseWellFedAnimalEvent(new WellFedAnimalEventArgs(animalName, howMuchFoodNeed));
            Destroy(gameObject);
        }
    }

    [Serializable]
    public struct FoodAndNutrition
    {
        public GameObject gameObject;
        public float nutrition;
    }
}
