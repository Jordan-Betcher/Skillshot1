using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPosition : Movement {

    public Vector2 targetPosition;

    public override void startMovement()
    {
        this.enabled = true;
    }

    public override void stopMovement()
    {
        this.enabled = false;
    }

    void FixedUpdate()
    {
        if(targetPosition != null)
        {
            Vector3 object_pos = this.transform.position;
            targetPosition.x = targetPosition.x - object_pos.x;
            targetPosition.y = targetPosition.y - object_pos.y;

            float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
            angle -= 90;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
