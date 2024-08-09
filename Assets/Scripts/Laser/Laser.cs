using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserMaxLength = 50f;

    [SerializeField] private GameObject physicsSphere;

    public bool Power = true;

    private void Start()
    {
        physicsSphere.SetActive(false);
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Power == true)
        {
            lineRenderer.enabled = true;
            physicsSphere.SetActive(true);
            UpdateLaser();
        }
        else
        {
            physicsSphere.SetActive(false);
            lineRenderer.enabled = false;
        }
    }

    private void UpdateLaser()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 endPosition = ray.origin + (ray.direction * laserMaxLength);

        if (Physics.Raycast(ray, out hit, laserMaxLength))
        {
            endPosition = hit.point;
            physicsSphere.transform.position = endPosition;
            if(hit.collider.gameObject.GetComponent<LegsControl>())
            {
                hit.collider.gameObject.GetComponent<LegsControl>().DamageBody();
            }
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }
}