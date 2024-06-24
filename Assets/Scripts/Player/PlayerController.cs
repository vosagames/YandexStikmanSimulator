using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private Transform _playerCamera;

    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _rotateSpeed = 3f;

    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private float _gravityValue = -9.8f;
    [SerializeField] private float _rayDistance;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _player3Dmodel;

    private bool _groundedPlayer;
    private Vector3 _playerVelocity;
    

    private void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _playerVelocity = Vector3.zero;
        _characterController = GetComponent<CharacterController>();
        _animator = _player3Dmodel.GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {

        _groundedPlayer = _characterController.isGrounded;
        if(_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = Quaternion.Euler(0, _playerCamera.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0f, vertical).normalized;

        if(direction != Vector3.zero) 
        {
            Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime);
        }

        _characterController.Move(direction * _moveSpeed * Time.deltaTime);

        float speed = direction.magnitude;
        stopRun();

        if (speed >= 0.1f)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && speed >= 0.1f)
        {
            startRun(speed);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            stopRun();
        }

        if(Input.GetKeyDown(KeyCode.Space) && _groundedPlayer)
        {
            Debug.Log("Jump");
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3f * _gravityValue);
        }

    
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
        _animator.SetBool("Jump", true);

        Vector3 rayDirection = new Vector3(0, -1, 0);
        Ray ray = new Ray(transform.position, rayDirection);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, _rayDistance)) 
        {
            Debug.DrawRay(transform.position, rayDirection * _rayDistance, Color.red);
            if(hit.collider.gameObject != null && !hit.collider.gameObject.CompareTag("Player"))
            {
                _animator.SetBool("Jump", false);
                Debug.Log("!= null");
            }
        }
    }
    private void startRun(float speed)
    {
        _moveSpeed = 7f;
        _animator.SetBool("Run", true);
        if (speed < 0.1f)
        {
            stopRun();
        }
    }

    private void stopRun()
    {
        _moveSpeed = 4f;
        _animator.SetBool("Run", false);
    }
}