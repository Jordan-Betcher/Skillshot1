using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour {

	void FixedUpdate () {
        Vector3 mouse_pos = Input.mousePosition;

        Vector3 object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        mouse_pos.z = 0;

        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        angle -= 90;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
