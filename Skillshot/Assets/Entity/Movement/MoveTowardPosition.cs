﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPosition : Movement
{
    public float speed = 0.05f;
    private Vector2 targetPosition;
    public bool moving = false;

    void Start()
    {
        if(targetPosition == null)
        {
            targetPosition = this.transform.position;
        }
    }

    public void goToPosition(Vector2 newGoalPosition)
    {
        targetPosition = newGoalPosition;
        moving = true;
    }

    public Vector2 getCurrentTargetPosition()
    {
        return targetPosition;
    }

    public bool isCurrentlyMoving()
    {
        return moving;
    }

    void FixedUpdate()
    {
        if (isAlreadyAtTarget())
        {
            moving = false;
        }
        else if (moving == true)
        {
            Debug.Log("Moving");
            move();
        }
    }

    private bool isAlreadyAtTarget()
    {
        Vector2 currentPosition = getCurrentPositionXY();
        return targetPosition.Equals(currentPosition);
    }

    private void move()
    {
        Vector2 currentPosition = getCurrentPositionXY();
        Vector2 distanceBetween = targetPosition - currentPosition;

        if (distanceBetween.magnitude <= speed)
        {
            setPositionXY(targetPosition);
        }
        else
        {
            distanceBetween.Normalize();
            distanceBetween.Scale(new Vector2(speed, speed));
            Vector3 newPosition = currentPosition + distanceBetween;

            setPositionXY(newPosition);
        }
    }

    private Vector2 getCurrentPositionXY()
    {
        Vector2 currentPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        return currentPosition;
    }

    private void setPositionXY(Vector2 newPosition)
    {
        this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);
    }

    public override void stopMovement()
    {
        targetPosition = new Vector2();
        moving = false;
        enabled = false;
    }

    public override void startMovement()
    {
        enabled = true;
    }
}
