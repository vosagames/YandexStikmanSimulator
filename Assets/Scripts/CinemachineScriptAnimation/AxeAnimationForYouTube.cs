using UnityEngine;
using Cinemachine;

public class AxeAnimationForYouTube : MonoBehaviour
{
    [SerializeField] private Transform PositionOne, PositionTwo, PositionThree;

    [SerializeField] private CinemachineVirtualCamera VirtualCamera;


    void Start()
    {
        LookPos1();
        Invoke("LookPos2", 3.6f);
        Invoke("LookPos3", 6f);
        Invoke("LookPos2", 9f);
        Invoke("LookPos1", 11f);
    }

    private void LookPos1()
    {
        VirtualCamera.m_LookAt = PositionOne;
        VirtualCamera.m_Lens.FieldOfView = 40f;
    }
    private void LookPos2()
    {
        VirtualCamera.m_LookAt = PositionTwo;
        VirtualCamera.m_Lens.FieldOfView = 70f;
    }
    private void LookPos3()
    {
        VirtualCamera.m_LookAt = PositionThree;
        VirtualCamera.m_Lens.FieldOfView = 80f;
    }


}
