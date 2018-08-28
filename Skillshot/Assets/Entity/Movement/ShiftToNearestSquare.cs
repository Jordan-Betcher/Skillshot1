using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftToNearestSquare : Movement
{

    public Movement[] disableDuringShift;
    public Vector2 centerOfObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position = new Vector2(Mathf.FloorToInt(transform.position.x + centerOfObject.x), Mathf.FloorToInt(transform.position.y + centerOfObject.y));
            transform.eulerAngles = new Vector3();

            foreach(Movement script in  disableDuringShift)
            {
                script.stopMovement();
            }
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            foreach (Movement script in disableDuringShift)
            {
                script.startMovement();
            }
        }
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
