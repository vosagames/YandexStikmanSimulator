using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;
using YG;

public class MobileFreeLookControl : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;

    [SerializeField] private Rect touchArea;

    private Touch touch;

    private bool mobile;

    private void Start()
    {
        if (Screen.width <= 1334)
        {
            touchArea = new Rect(500f, 0f, 2000f, 2000f);
        }
        else
        {
            touchArea = new Rect(1000f, 0f, 2000f, 2000f);
        }
        freeLookCamera = GetComponent<CinemachineFreeLook>();
        if(YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true )
        {
            freeLookCamera.m_XAxis.m_InputAxisName = null;
            freeLookCamera.m_YAxis.m_InputAxisName = null;
            mobile = true;
        }
        else if(YandexGame.EnvironmentData.isDesktop == true)
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        }
    }
    
    private void Update()
    {
        if(mobile == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.touchCount > 0)
        {
            if(Input.touchCount == 1) 
            {
                touch = Input.GetTouch(0);
            }

            if(Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);
            }
        }

        if (touch.phase == TouchPhase.Moved && touchArea.Contains(touch.position))
        {
            Vector2 touchDelta = touch.deltaPosition;
            FreeLookCam(touchDelta);
        }
    }
    private void FreeLookCam(Vector2 delta)
    {
        float HorizontalRotation = delta.x * 0.1f;
        float VerticalRotation = delta.y * 0.1f;

        freeLookCamera.m_XAxis.Value -= HorizontalRotation * 6f;
        freeLookCamera.m_YAxis.Value += VerticalRotation * 0.020f;
    }
  
}