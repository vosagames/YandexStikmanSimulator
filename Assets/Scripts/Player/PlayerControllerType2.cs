using UnityEngine;
using YG;
public class PlayerControllerType2 : MonoBehaviour
{

    public bool isMove;

    [SerializeField] private CharacterController controller;

    [SerializeField] private Transform _playerCamera;

    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _rotateSpeed = 3f;
    [SerializeField] private float _gravityValue = -9.8f;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _player3Dmodel;

    [SerializeField] private Joystick _joystick;

    [SerializeField] private bool JoystickInput = false;

    [SerializeField] private GameObject MobileInput;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    private float horizontal;
    private float vertical;

    private void Start()
    {
        isMove = true;

        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _playerVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
        _animator = _player3Dmodel.GetComponent<Animator>();

        if (YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true)
        {
            MobileInput.SetActive(true);
            JoystickInput = true;
        }
        else if (YandexGame.EnvironmentData.isDesktop == true)
        {
            MobileInput.SetActive(false);
            JoystickInput = false;
        }
    }
    private void Update()
    {
        if (isMove == true)
        {
            Move();
        }
        else
        {
            Debug.Log("Move STOP!");
            _animator.SetFloat("MSed", 0f);
        }
    }
    private void Move()
    {
        _groundedPlayer = controller.isGrounded;
        if(_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        if(JoystickInput == true)
        {
            horizontal = _joystick.Horizontal;
            vertical = _joystick.Vertical;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
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
