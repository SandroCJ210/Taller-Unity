using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _movementThresholdX = 5;
    [SerializeField] private float _movementThresholdY = 3;
    [SerializeField] private float smoothTime = 0.5f;
    
    Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_movementThresholdX * 2, _movementThresholdY * 2, 1));
    }
    
    void LateUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        Vector3 targetPosition = _target.transform.position;
        Vector3 cameraPosition = transform.position;
        
        Vector3 difference = targetPosition - cameraPosition;

        if (Math.Abs(difference.x) < _movementThresholdX && Math.Abs(difference.y) < _movementThresholdY)
        {
            return;
        }

        float newPosX = cameraPosition.x;
        float newPosY = cameraPosition.y;

        if (difference.x > _movementThresholdX)
        {
            newPosX = targetPosition.x - _movementThresholdX;
        }
        else if (difference.x < -_movementThresholdX)
        {
            newPosX = targetPosition.x + _movementThresholdX;
        }

        if (difference.y > _movementThresholdY)
        {
            newPosY = targetPosition.y - _movementThresholdY;
        }
        else if (difference.y < -_movementThresholdY)
        {
            newPosY = targetPosition.y + _movementThresholdY;
        }
        
        Vector3 newPosition = new Vector3(newPosX, newPosY, cameraPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothTime); 
            //Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        
        
    }
}
