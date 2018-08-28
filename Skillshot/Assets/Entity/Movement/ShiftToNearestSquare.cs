using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftToNearestSquare : Movement
{

    public Movement[] disableDuringShift;
    public Vector2 centerOfObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position = getShiftPosition();
            transform.eulerAngles = getShiftEulerAngles();

            foreach (Movement script in disableDuringShift)
            {
                script.stopMovement();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            foreach (Movement script in disableDuringShift)
            {
                script.startMovement();
            }
        }
    }

    public Vector2 getShiftPosition()
    {
        return new Vector2(Mathf.FloorToInt(transform.position.x + centerOfObject.x), Mathf.FloorToInt(transform.position.y + centerOfObject.y));
    }

    public Vector3 getShiftEulerAngles()
    {
        return new Vector3();
    }

    public override void startMovement()
    {
        enabled = true;
    }

    public override void stopMovement()
    {
        enabled = false;
    }
}
