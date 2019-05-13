using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Vector3 fireVec;
    public float fireSpeed;
	// Use this for initialization
	void Start () {
        fireSpeed = 450;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(fireVec*Time.deltaTime*fireSpeed);
        if (Vector3.Distance(transform.position, Vector3.zero)>80)
        {
            Destroy(gameObject);
        }
	}
    
}
