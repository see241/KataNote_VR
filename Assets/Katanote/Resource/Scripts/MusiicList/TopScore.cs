using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScore: MonoBehaviour {


    static internal bool[] _isTopScore;             //[0]은 퍼펙트 [1]은 SS랭크 불값이다.
    private GameObject _mPrePrft;
    private GameObject _mSSRank;
	// Use this for initialization
	void Start () {

        _isTopScore = new bool[2];
        _mPrePrft = GameObject.Find("GameObject-Preprft");
        _mSSRank = GameObject.Find("GameObject-SSRank");
       for(int i=0; i<2; i++)
        {
            _isTopScore[i] = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (_isTopScore[0])
        {
            GameObject.Find("GameObject-Top Score").transform.GetChild(1);
        }
        else
        {
            _mPrePrft.SetActive(false);
        }

        if (_isTopScore[1])
        {
            GameObject.Find("GameObject-Top Score").transform.GetChild(2);
        }
        else
        {
            _mSSRank.SetActive(false);
        }
	}
}
