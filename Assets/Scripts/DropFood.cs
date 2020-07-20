using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{
    public GameObject[] foodsInventory;

    // private readonly GameObject[] _preparedFoods = new GameObject[3];

    private GameObject _food;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DropFood"))
        {
            Drop();
        }
    }

    private void Drop()
    {
        /*_preparedFoods[0] = foodsInventory[NextFoodIndex(0, foodsInventory.Length)];
        _preparedFoods[1] = foodsInventory[NextFoodIndex(0, foodsInventory.Length)];
        _preparedFoods[2] = foodsInventory[NextFoodIndex(0, foodsInventory.Length)];
        for (var i = 0; i < _preparedFoods.Length; i++)
        {
            Instantiate(_preparedFoods[i], new Vector3(15 * (i - 1), 5, -7), Quaternion.identity);
        }*/
        _food = foodsInventory[NextFoodIndex(0, foodsInventory.Length)];
        var playerPosition = transform.position;
        Instantiate(_food, new Vector3(playerPosition.x, 2, playerPosition.z + 2), Quaternion.identity);
    }

    private int NextFoodIndex(int min, int max)
    {
        return Random.Range(min, max);
    }
}