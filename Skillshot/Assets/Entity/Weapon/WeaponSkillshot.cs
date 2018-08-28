using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSkillshot : MonoBehaviour
{
    public Skillshot skillshot;
    public KeyCode key = KeyCode.E;

    void Start ()
    {
    }
	
	protected void Update ()
    {
        if (Input.GetKeyDown(key))
        {
            Use();
        }
    }

    protected void Use()
    {
        Skillshot newSkillshot = GameObject.Instantiate(skillshot, this.transform.position, this.transform.rotation);
        newSkillshot.Launch();
    }
}
