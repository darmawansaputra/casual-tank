using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    public GameObject background;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //background.transform.position = target.position;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}
}
