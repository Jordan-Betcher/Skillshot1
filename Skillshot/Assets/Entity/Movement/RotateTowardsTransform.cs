using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTransform: RotateTowardsPosition
{
    public Transform target;

    void Update()
    {
        if(target != null)
        {
            base.targetPosition = target.position;
        }
        
    }
}
