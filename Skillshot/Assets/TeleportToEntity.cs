using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToEntity : MonoBehaviour {

    public Transform entity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float newX = entity.transform.position.x;
        float newY = entity.transform.position.y;
        float newZ = this.transform.position.z;

        Quaternion newRotation = entity.transform.rotation;
        this.transform.position = new Vector3(newX, newY, newZ);
        //this.transform.SetPositionAndRotation(new Vector3(newX, newY, newZ), 0);
    }
}
