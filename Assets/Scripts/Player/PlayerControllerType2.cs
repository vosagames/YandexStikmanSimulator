using UnityEngine;
public class PlayerControllerType2 : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private Transform _playerCamera;

    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _rotateSpeed = 3f;
    [SerializeField] private float _gravityValue = -9.8f;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _player3Dmodel;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    private void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _playerVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
        _animator = _player3Dmodel.GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _groundedPlayer = controller.isGrounded;
        if(_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = Quaternion.Euler(0, _playerCamera.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0f, vertical).normalized;

        if(direction != Vector3.zero)
        {
            Quaternion TargetRot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRot, _rotateSpeed * Time.deltaTime);
        }

        controller.Move(direction * _moveSpeed * Time.deltaTime);

        float speed = direction.magnitude;

        if (speed >= 0.1f)
        {
            _animator.SetFloat("MSed", 1f);
        }
        else
        {
            _animator.SetFloat("MSed", 0f);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);
    }
}
