using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float StartPositionZ;
    [SerializeField] private float EndPositionZ;
    [SerializeField] private float Speed = 2f;

    private float PositionZ;

    private void Start()
    {
        PositionZ = EndPositionZ;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, PositionZ), Speed * Time.deltaTime);
        if(transform.position.z >= EndPositionZ)
        {
            PositionZ = StartPositionZ;
        }
        if(transform.position.z <= StartPositionZ) 
        {
            PositionZ = EndPositionZ;
        }
    }
}

