using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform StartPosition;
    [SerializeField] private Transform EndPosition;

    [SerializeField] private float Speed = 2f;

    [SerializeField] private bool posX;
    [SerializeField] private bool posY;
    [SerializeField] private bool posZ;

    private float Position;

    private void Start()
    {
        if(posZ == true)
        {
            Position = EndPosition.position.z;
        }
        if (posX == true)
        {
            Position = EndPosition.position.x;
        }
        if (posY == true)
        {
            Position = EndPosition.position.y;
        }
    }

    private void FixedUpdate()
    {
        if(posZ == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Position), Speed * Time.deltaTime);
            if (transform.position.z >= EndPosition.position.z)
            {
                Position = StartPosition.position.z;
            }
            if (transform.position.z <= StartPosition.position.z)
            {
                Position = EndPosition.position.z;
            }
        }
        if(posX == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Position, transform.position.y, transform.position.z), Speed * Time.deltaTime);
            if (transform.position.x >= EndPosition.position.x)
            {
                Position = StartPosition.position.x;
            }
            if (transform.position.x <= StartPosition.position.x)
            {
                Position = EndPosition.position.x;
            }
        }
        if(posY == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, Position, transform.position.z), Speed * Time.deltaTime);
            if (transform.position.y >= EndPosition.position.y)
            {
                Position = StartPosition.position.y;
            }
            if (transform.position.y <= StartPosition.position.y)
            {
                Position = EndPosition.position.y;
            }
        }
    }
}

