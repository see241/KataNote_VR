using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PtcControl : MonoBehaviour {
    private ParticleSystem _mPtc;
	// Use this for initialization
	void Start () {
        _mPtc = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_mPtc.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
