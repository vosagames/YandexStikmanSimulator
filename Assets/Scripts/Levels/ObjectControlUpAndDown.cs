using UnityEngine;

public class ObjectControlUpAndDown : MonoBehaviour
{
    public bool Power = true;

    [SerializeField] private float _speed;
    [SerializeField] private float _positionY;

    [SerializeField] private Transform _targetObject;

    [SerializeField] private bool Up_Down;

    private void OnEnable()
    {
        if(transform.position.y ==  _positionY)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        if(Power == true)
        {
            _targetObject.transform.position = Vector3.MoveTowards(_targetObject.transform.position, new Vector3(_targetObject.transform.position.x, _positionY, _targetObject.transform.position.z), _speed * Time.deltaTime);

            if (Up_Down == true && _targetObject.transform.position.y >= _positionY)
            {
                gameObject.SetActive(false);
            }
            if (Up_Down == false && _targetObject.transform.position.y <= _positionY)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
