using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardTransform : MoveTowardPosition
{
    public Transform TargetObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TargetObject != null)
        {
            base.goToPosition(TargetObject.position);
        }
    }
}
