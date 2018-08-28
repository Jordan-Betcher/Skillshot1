using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : RotateTowardsPosition
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.targetPosition = mousePosition;
    }
}
