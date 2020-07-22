using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFood : MonoBehaviour
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
        _food = foodsInventory[NextFoodIndex(0, foodsInventory.Length)];
        var playerPosition = transform.position;
        Instantiate(_food, new Vector3(playerPosition.x, 1, playerPosition.z + 2), Quaternion.identity);
    }

    private int NextFoodIndex(int min, int max)
    {
        return Random.Range(min, max);
    }
}