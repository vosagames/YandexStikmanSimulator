
using UnityEngine;
using UnityEngine.UI;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 4f;
    [SerializeField] private float _smoothTime = 0.2f;

    [SerializeField] private GameObject _InputE;

    [SerializeField] private Transform _transformCamera;
    [SerializeField] private Transform DragPosition;

    [SerializeField] private GameObject _buttonInputE;

    [SerializeField] private GameObject _rayPoint;

    private Vector3 velocity = Vector3.zero;

    private GameObject DragObject;

    private bool Grab = false;

    private bool UseButtonE;

    private bool GrabReload;

    public void Start()
    {
        _InputE = FindObjectOfType<ObjectLookCamera>().gameObject;
        _InputE.SetActive(false);
        _rayPoint = GameObject.FindGameObjectWithTag("Point");
        _transformCamera = GameObject.FindGameObjectWithTag("Ray").transform;
        Invoke("DragPosFind", 1f);
        Invoke("ButtonEUse", 1f);
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
            if(hit.collider.gameObject.GetComponent<Switch>())
            {
                _InputE.SetActive(true);
                _InputE.GetComponent<Animator>().SetBool("Show", true);
                _InputE.transform.position = hit.collider.gameObject.GetComponent<Switch>()._posInputE.transform.position;
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
            else if(hit.collider.gameObject.GetComponent<Switch>() == null)
            {
                _InputE.GetComponent<Animator>().SetBool("Show", false);
            }
            if(hit.rigidbody && Input.GetKeyDown(KeyCode.E) && Grab == false && hit.collider.gameObject.CompareTag("GrabBody") || UseButtonE == true && hit.rigidbody && Grab == false && hit.collider.gameObject.CompareTag("GrabBody"))
            {
                DragObject = hit.rigidbody.gameObject;
                DragObject.GetComponent<Rigidbody>().isKinematic = true;
                Grab = true;
                GrabReload = true;
                Debug.Log("Grab");
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
    private void LateUpdate()
    {
        Ray ray = new Ray(transform.position, _transformCamera.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, _transformCamera.forward * _rayDistance, Color.black);

        if(Physics.Raycast(ray, out hit, _rayDistance))
        {
            if(hit.collider.gameObject != null)
            {
                _rayPoint.SetActive(true);
                Vector3 pointPos = new Vector3(hit.point.x + 0.1f, hit.point.y + 0.1f, hit.point.z + 0.1f);
                _rayPoint.transform.position = pointPos;
            }
        }
        else
        {
            _rayPoint.SetActive(false);
        }
    }
}
