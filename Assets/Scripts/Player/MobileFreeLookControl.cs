using UnityEngine;
using Cinemachine;
using YG;

public class MobileFreeLookControl : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    // [SerializeField] private Rect touchArea; // Здесь вы можете указать область на экране, в которой должно происходить вращение камеры
    [SerializeField] private Joystick _joystick;

    private bool isDragging = false;
    private Vector2 lastPosition;
    private Touch touch;


    private void Start()
    {
        freeLookCamera = GetComponent<CinemachineFreeLook>();
        if(YandexGame.EnvironmentData.isMobile == true || YandexGame.EnvironmentData.isTablet == true )
        {
            freeLookCamera.m_XAxis.m_InputAxisName = null;
            freeLookCamera.m_YAxis.m_InputAxisName = null;
        }
        else if(YandexGame.EnvironmentData.isDesktop == true)
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        }
    }
    /*
       void Update()
       {
           if (Input.touchCount > 0)
           {
               if(Input.touchCount == 1) 
               {
                   touch = Input.GetTouch(0);
               }
               else if(Input.touchCount > 1)
               {
                   touch = Input.GetTouch(1);
               }

               if (touch.phase == TouchPhase.Began && touchArea.Contains(touch.position))
               {
                   isDragging = true;
                   lastPosition = touch.position;
               }
               else if (touch.phase == TouchPhase.Moved && isDragging)
               {
                   Vector2 delta = touch.position - lastPosition;
                   freeLookCamera.m_XAxis.Value += delta.x * 5f * Time.deltaTime; // Изменение горизонтального вращения камеры
                   freeLookCamera.m_YAxis.Value -= delta.y * 0.05f * Time.deltaTime; // Изменение вертикального вращения камеры
                   lastPosition = touch.position;
               }
               else if (touch.phase == TouchPhase.Ended)
               {
                   isDragging = false;
               }
           }
       }
    */
    private void Update()
    {
        freeLookCamera.m_XAxis.Value += _joystick.Horizontal * 6f;
        freeLookCamera.m_YAxis.Value -= _joystick.Vertical * 0.020f;
    }
}


