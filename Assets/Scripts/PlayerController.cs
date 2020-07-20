using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveAmount;

    [SerializeField] private float speed = 20.0f;

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    [SerializeField] private int boundaryRange = 15;

    public int BoundaryStart
    {
        get => boundaryRange;
        set => boundaryRange = value;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _moveAmount = Input.GetAxis("Move");
        var moveVector = Vector3.right * (_moveAmount * Time.deltaTime * Speed);
        if (Enumerable.Range(-BoundaryStart, (BoundaryStart * 2))
            .Contains(Convert.ToInt32((transform.position + moveVector).x)))
        {
            transform.Translate(moveVector);
        }
    }
}