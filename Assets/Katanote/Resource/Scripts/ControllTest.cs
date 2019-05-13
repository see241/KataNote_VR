using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;
using UnityEngine;

public class ControllTest : MonoBehaviour {
    public InteractionSourcePressedEventArgs obj;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(obj.pressType == InteractionSourcePressType.Select)
        {
            Debug.Log("1");
        }
	}
}
