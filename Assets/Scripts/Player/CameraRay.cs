using UnityEngine;
using UnityEngine.UI;
using YG;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 4f;
    [SerializeField] private float _smoothTime = 0.2f;

    [SerializeField] private Transform _transformCamera;
    [SerializeField] private Transform DragPosition;

    [SerializeField] private GameObject _buttonInputE;

    [SerializeField] private GameObject _aimArm;

    [SerializeField] private GameObject _aimPoint;

    private Vector3 velocity = Vector3.zero;

    private GameObject DragObject;

    private bool Grab = false;

    private bool UseButtonE;

    private bool GrabReload;

    private void Awake()
    {
        _aimArm = GameObject.FindGameObjectWithTag("AimArm");
        _aimPoint = GameObject.FindGameObjectWithTag("AimPoint");
        _aimPoint.SetActive(true);
        _aimArm.SetActive(false);
    }
    public void Start()
    {
        _transformCamera = GameObject.FindGameObjectWithTag("Ray").transform;
        Invoke("DragPosFind", 0.0001f);
        if (YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true)
        {
            Invoke("ButtonEUse", 0.0001f);
        }
        else
        {
            _buttonInputE = null;
        }
    }
    void Update()
    {
        transform.rotation = _transformCamera.rotation; 
        transform.position = _transformCamera.position;

        Ray ray = new Ray(transform.position, _transformCamera.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, _transformCamera.forward * _rayDistance, Color.black);


        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("UseInput") || hit.collider.gameObject.CompareTag("GrabBody"))
            {
                _aimPoint.SetActive(false);
                _aimArm.SetActive(true);
            }
            else
            {
                _aimPoint.SetActive(true);
                _aimArm.SetActive(false);
            }

            if (hit.collider.gameObject.CompareTag("UseInput"))
            {
                if (hit.collider.gameObject.GetComponent<LeverSwitch>() && Input.GetKeyDown(KeyCode.E) || UseButtonE == true && hit.collider.gameObject.GetComponent<LeverSwitch>())
                {
                    hit.collider.gameObject.GetComponent<LeverSwitch>().UseHandle();
                }
                if (hit.collider.gameObject.GetComponent<BigButtonSwitch>() && Input.GetKeyDown(KeyCode.E) || UseButtonE == true && hit.collider.gameObject.GetComponent<BigButtonSwitch>())
                {
                    hit.collider.gameObject.GetComponent<BigButtonSwitch>().PressButton();
                }
                if (hit.collider.gameObject.GetComponent<Door>() && Input.GetKeyDown(KeyCode.E) || UseButtonE == true && hit.collider.gameObject.GetComponent<Door>())
                {
                    hit.collider.gameObject.GetComponent<Door>().OpenDoor();
                }
            }

            if(hit.collider.gameObject.CompareTag("GrabBody"))
            {
                if (hit.rigidbody && Input.GetKeyDown(KeyCode.E) && Grab == false && hit.collider.gameObject.CompareTag("GrabBody") || UseButtonE == true && hit.rigidbody && Grab == false && hit.collider.gameObject.CompareTag("GrabBody"))
                {
                    DragObject = hit.rigidbody.gameObject;
                    DragObject.GetComponent<Rigidbody>().isKinematic = true;
                    Grab = true;
                    GrabReload = true;
                    Debug.Log("Grab");
                }
            }

        }

        if (Grab == true)
        {
            DragObject.transform.position = Vector3.SmoothDamp(DragObject.transform.position, DragPosition.position, ref velocity, _smoothTime);
            Invoke("ReloadGrab", 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.E) && Grab == true && GrabReload == false || UseButtonE == true && Grab == true && GrabReload == false)
        {
            Grab = false;
            DragObject.GetComponent<Rigidbody>().isKinematic = false;
            DragObject = null;
        }

    }

    private void DragPosFind() => DragPosition = GameObject.FindGameObjectWithTag("Drag").transform;

    public void UseButtonEForMobile()
    {
        UseButtonE = true;
        Invoke("UseButtonEFalse", 0.1f);
        Debug.Log("UseForMibile");
    }
    private void UseButtonEFalse() => UseButtonE = false;

    private void ReloadGrab()
    {
        GrabReload = false;
        Debug.Log(GrabReload + "Reload");
        Debug.Log(Grab + " Grab");
    }
    private void ButtonEUse()
    {
        _buttonInputE = GameObject.FindGameObjectWithTag("ButtonEUI");
        Button btn = _buttonInputE.GetComponent<Button>();
        btn.onClick.AddListener(UseButtonEForMobile);
    }   
}
