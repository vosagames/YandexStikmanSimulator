using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 4f;
    [SerializeField] private float _smoothTime = 0.2f;

    [SerializeField] private GameObject _InputE;

    [SerializeField] private Transform _transformCamera;
    [SerializeField] private Transform DragPosition;

    private Vector3 velocity = Vector3.zero;

    private GameObject DragObject;

    private bool Grab = false;

    public void Start()
    {
        _InputE = FindObjectOfType<ObjectLookCamera>().gameObject;
        _InputE.SetActive(false);
        _transformCamera = GameObject.FindGameObjectWithTag("Ray").transform;
        Invoke("DragPosFind", 1f);
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
                if (hit.collider.gameObject.GetComponent<LeverSwitch>() && Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<LeverSwitch>().UseHandle();
                }
                if (hit.collider.gameObject.GetComponent<BigButtonSwitch>() && Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<BigButtonSwitch>().PressButton();
                }
                if (hit.collider.gameObject.GetComponent<Door>() && Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<Door>().OpenDoor();
                }
            }
            else if(hit.collider.gameObject.GetComponent<Switch>() == null)
            {
                _InputE.GetComponent<Animator>().SetBool("Show", false);
            }
            if(hit.rigidbody && Input.GetKeyDown(KeyCode.E) && Grab == false && hit.collider.gameObject.CompareTag("GrabBody"))
            {
                DragObject = hit.rigidbody.gameObject;
                DragObject.GetComponent<Rigidbody>().isKinematic = true;
                Grab = true;
                Debug.Log("Grab");
            }
        }

        if (Grab == true)
        {
            DragObject.transform.position = Vector3.SmoothDamp(DragObject.transform.position, DragPosition.position, ref velocity, _smoothTime);
        }
        if(Input.GetKeyDown(KeyCode.F) && Grab == true)
        {
            Grab = false;
            DragObject.GetComponent<Rigidbody>().isKinematic = false;
            DragObject = null;
        }
    }

    private void DragPosFind() => DragPosition = GameObject.FindGameObjectWithTag("Drag").transform;
}
