using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] private float MoveSpeed = 4f;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform player;
    [SerializeField] private float maxZoomOut = 15f; 
    [SerializeField] private float standardZoom;
    [SerializeField] private float zoomSpeed = 5f; 
    [SerializeField] private float rightScreenBoundary = 5f; 


    private bool stopCamera = false;


    private void Start()
    {
        standardZoom = virtualCamera.m_Lens.OrthographicSize; 
    }

    private void Update()
    {
        if ((!stopCamera))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }

        float playerToCameraDistance = player.position.x - Camera.main.transform.position.x;

       
        if (playerToCameraDistance > rightScreenBoundary)
        {
            
            float targetZoom = Mathf.Clamp(playerToCameraDistance, standardZoom, maxZoomOut);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
            Debug.Log("OH NO Player is trying to ecscape!!!");
        }
        
        else if (virtualCamera.m_Lens.OrthographicSize > standardZoom)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, standardZoom, Time.deltaTime * zoomSpeed);
            Debug.Log("Zoon In!!!!!!!!");
        }

    }

    public void StopCamera()
    {
        stopCamera = true;
    }
}
