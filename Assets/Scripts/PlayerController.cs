using System;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _startForwardRange;

    [SerializeField] private float speed = 20.0f;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    [SerializeField] private int boundaryRange = 15;
    [SerializeField] private int forwardRange = 10;

    public int BoundaryRange
    {
        get => boundaryRange;
        set => boundaryRange = value;
    }

    public int ForwardRange
    {
        get => forwardRange;
        set => forwardRange = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _startForwardRange = ((int) transform.position.z) - 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSide();
        MoveForward();
    }

    private void MoveSide()
    {
        var moveAmount = Input.GetAxis("Move");
        var moveVector = Vector3.right * (moveAmount * Time.deltaTime * Speed);
        MoveIfInRange(-BoundaryRange, (BoundaryRange * 2), 
            moveVector,
            () => Convert.ToInt32((transform.position + moveVector).x));
    }

    private void MoveForward()
    {
        var moveForwardAmount = Input.GetAxis("MoveForward");
        var moveForwardVector = Vector3.forward * (moveForwardAmount * Time.deltaTime * Speed);
        MoveIfInRange(_startForwardRange, ForwardRange, 
            moveForwardVector,
            () => Convert.ToInt32((transform.position + moveForwardVector).z));
    }

    private void MoveIfInRange(int start, 
        int range,
        Vector3 moveVector,
        Func<int> changedPositionOnAxis)
    {
        if (Enumerable.Range(start, range)
            .Contains(changedPositionOnAxis.Invoke()))
        {
            transform.Translate(moveVector);
        }
    }
}