using UnityEngine;

public class Type3PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.1f;
    [SerializeField] private float _rotateSpeed = 3f;
    [SerializeField] private float _roationPSe;
    [SerializeField] private float _gravityValue = -9.8f;


    [SerializeField] private Transform _playerCamera;

    [SerializeField] private GameObject _playerModel;

    [SerializeField] private CharacterController controller;

    private bool _playerGrounded;
    private Vector3 _playerVelocity;

    private void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _playerGrounded = controller.isGrounded;
        if (_playerGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float VerticalMove = Input.GetAxis("Vertical");
        float HorizontalMove = Input.GetAxis("Horizontal");

        Vector3 move = Quaternion.Euler(0, _playerCamera.transform.eulerAngles.y, 0) * new Vector3(HorizontalMove, 0, VerticalMove).normalized;

        if(move != Vector3.zero)
        {
            Quaternion TargetRot = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRot, _rotateSpeed * Time.deltaTime);
        }

        controller.Move(move * _speed * Time.deltaTime);

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime);

        if (move.magnitude >= 0.2f)
        {
            _playerModel.transform.Rotate(0f, _roationPSe, 0f);
        }
    }
}
