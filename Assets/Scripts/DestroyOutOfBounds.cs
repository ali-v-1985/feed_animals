using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float lowBounds = -15;
    public float LowBounds
    {
        get => lowBounds;
        set => lowBounds = value;
    }

    [SerializeField] private float highBounds = 35;
    public float HighBounds
    {
        get => highBounds;
        set => highBounds = value;
    }

    [SerializeField] private float leftHorizontalBounds = -25;
    public float LeftHorizontalBounds
    {
        get => leftHorizontalBounds;
        set => leftHorizontalBounds = value;
    }

    [SerializeField] private float rightHorizontalBounds = 25;
    public float RightHorizontalBounds
    {
        get => rightHorizontalBounds;
        set => rightHorizontalBounds = value;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOutOfBounds())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutOfBounds()
    {
        var position = transform.position;
        return position.z < LowBounds || position.z > HighBounds ||
               position.x < LeftHorizontalBounds || position.x > RightHorizontalBounds;
    }
}