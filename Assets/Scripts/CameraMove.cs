using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float MoveSpeed = 4f;

    [Header("Zoom")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform player;
    [SerializeField] private float maxZoomOut = 20f; 
    private float standardZoom;
    [SerializeField] private float zoomSpeed = 5f; 
    [SerializeField] private float rightScreenBoundary = 8f; 


    private bool stopCamera = false;


    private void Start()
    {
        //setting standard zoom to orthographic size set in virtual camera
        standardZoom = virtualCamera.m_Lens.OrthographicSize; 
    }

    private void Update()
    {
        if ((!stopCamera))
        {
            //making camera move at constant speed is not stopped
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }

        //player to camera position
        float playerToCameraDistance = player.position.x - Camera.main.transform.position.x;

       
        if (playerToCameraDistance > rightScreenBoundary)
        {
            //zoom out
            float targetZoom = Mathf.Clamp(playerToCameraDistance, standardZoom, maxZoomOut);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
            
        }
        
        else if (virtualCamera.m_Lens.OrthographicSize > standardZoom)
        {
            //zoom back to standard orthographic size
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, standardZoom, Time.deltaTime * zoomSpeed);
            
        }

    }

    public void StopCamera()
    {
        stopCamera = true;
    }
}
