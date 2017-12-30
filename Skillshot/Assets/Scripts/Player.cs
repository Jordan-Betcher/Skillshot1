using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IWeapon weapon;
    private bool EDown = false;
    // Use this for initialization
    void Start()
    {
        weapon = this.GetComponent<IWeapon>();

        if (weapon != null)
        {
            Debug.Log("No weapon found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EDown = true;
        }
    }

    void FixedUpdate()
    {
        if(weapon != null)
        {
            if (EDown)
            {
                weapon.EActive();
                EDown = false;
            }
        }
    }
}
