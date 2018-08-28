using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShiftHightlight : MonoBehaviour
{

    public ShiftToNearestSquare parentScript;

    void Update()
    {
        this.transform.position = parentScript.getShiftPosition();
        transform.eulerAngles = parentScript.getShiftEulerAngles();
    }
}
