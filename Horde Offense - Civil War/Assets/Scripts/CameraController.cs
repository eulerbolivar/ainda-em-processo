using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject player;
    [SerializeField] public float rotationSpeed = 3f;
    
    private float initialCameraRotationX;

    void Start()
    {
        initialCameraRotationX = virtualCamera.transform.rotation.eulerAngles.x;
    }

    void Update()
    {
        rotateCamera();
        returnNeutralCamera();
        cameraZoom();
    }

    void rotateCamera()
    { 
        checkRightClick();

        if (isRotating == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            
            Vector3 playerRotation = player.transform.eulerAngles;
            playerRotation.y += mouseX;
            player.transform.eulerAngles = playerRotation;
            
            Quaternion cameraRotationX = Quaternion.Euler(0f, mouseX, 0f);
            Quaternion cameraRotationY = Quaternion.Euler(-mouseY, 0f, 0f);

            float RotateX = virtualCamera.transform.rotation.eulerAngles.x;
            float RotateY = virtualCamera.transform.rotation.eulerAngles.y;

            Quaternion targetRotation = Quaternion.Euler(RotateX - mouseY, RotateY + mouseX, 0f);
        
        if (targetRotation.eulerAngles.x < initialCameraRotationX - 90f || targetRotation.eulerAngles.x > initialCameraRotationX + 90f)
        {
            targetRotation = Quaternion.Euler(virtualCamera.transform.rotation.eulerAngles.x, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
        }
    
        virtualCamera.transform.rotation = targetRotation;
        }
    }

    float lastClick = 0f;
    float checkDoubleClick = 0.3f;
    void returnNeutralCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - lastClick < checkDoubleClick)
            {
                virtualCamera.transform.position = Vector3.zero;
                virtualCamera.transform.rotation = Quaternion.Euler(15f, transform.rotation.eulerAngles.y, 0f);
                transform.rotation = Quaternion.Euler(0f, virtualCamera.transform.rotation.eulerAngles.y, 0f);
            }
            
            lastClick = Time.time;
        }
    }

    public float minFOV = 10f;
    public float maxFOV = 90f;
    [SerializeField] public float cameraSensibility = 25f;
    void cameraZoom()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScroll != 0f)
        {
            float zoomAmount = mouseScroll * cameraSensibility;
            float adjustedFov = virtualCamera.m_Lens.FieldOfView - zoomAmount;
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(adjustedFov, minFOV, maxFOV);
        }

    }

    private bool isRotating = false;
    void checkRightClick()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
    }
}