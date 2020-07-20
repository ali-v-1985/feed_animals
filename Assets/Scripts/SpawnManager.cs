using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int numberOfAnimalsOnScreen = 3;
    
    public GameObject[] animals;


    [SerializeField] private float horizontalLowBound;
    public float HorizontalLowBound
    {
        get => horizontalLowBound;
        set => horizontalLowBound = value;
    }


    [SerializeField] private float horizontalHighBound;
    public float HorizontalHighBound
    {
        get => horizontalHighBound;
        set => horizontalHighBound = value;
    }

    [SerializeField]
    private int level = 1;
    public int Level
    {
        get => level;
        set => level = value;
    }

    private int _generatedAnimals;
    private const int NumberOfAnimals = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x =  GameObject.FindGameObjectsWithTag("Animal").Length;
        if (x < numberOfAnimalsOnScreen && _generatedAnimals < Level * NumberOfAnimals)
        {
            var animal = animals[NextFoodIndex(0, animals.Length)];
            var position = new Vector3(Random.Range(HorizontalLowBound, HorizontalHighBound), 
                0, 
                35);
            Instantiate(animal, position, animal.transform.rotation);
            _generatedAnimals++;
        }
    }
    
    private int NextFoodIndex(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void NextLevel()
    {
        Level++;
        _generatedAnimals = 0;
    }
}
