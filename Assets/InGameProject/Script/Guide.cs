using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour {
    Renderer rend;

    public GameObject test;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
       

        // 
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward,out hit,7))
        {
            if (hit.collider.gameObject.tag == "Nodes")
            {
                //hit.collider.gameObject.GetComponent<NoteControl>().mDisFromGuide = hit.collider.gameObject.transform.position.z - transform.position.z;
                rend.enabled = true;
            }
            
        }
        else
        {
               
            rend.enabled = false;
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
