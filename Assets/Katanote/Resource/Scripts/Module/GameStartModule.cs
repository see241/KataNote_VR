using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartModule : MonoBehaviour {

    public GameObject mObjectStart;

    internal bool _isStart = false;

    public void StartObjectEnable()
    {
        mObjectStart.SetActive(true);
    }

    public void StartObjectDisable()
    {
        mObjectStart.SetActive(false);
    }
}
