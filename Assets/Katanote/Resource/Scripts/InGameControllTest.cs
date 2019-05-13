using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;
public class InGameControllTest : MonoBehaviour {  
    private InteractionSourcePressedEventArgs obj;
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
