using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovementController : MonoBehaviour
{
    public float swerveSpeed, platformWidth, movementSpeed;
    private float swipeDelta, newx;
    private Vector3 movementPosition;
    private void Update()
    {
       
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved )
        {
            swipeDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        else if (Input.GetMouseButton(0))
        {
            swipeDelta = Input.GetAxis("Mouse X");
        }
        newx = transform.position.x + swipeDelta * swerveSpeed * Time.deltaTime;


        //newx = Mathf.Clamp(newx, -platformWidth, platformWidth);
        
        
        
        movementPosition = new Vector3(newx, transform.position.y, transform.position.z + movementSpeed * Time.deltaTime);
        transform.position = movementPosition;
    }
}
