using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    public GameObject mObjectGuide;
    public float speed;
    public float mDisFromGuide;
    float timer;
    public bool mIsDouble;
    public bool mIsShootLeft;
    public bool mIsShootRight;

    // Use this for initialization
    void Start()
    {
        mDisFromGuide = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        mDisFromGuide = transform.position.z + 15;
        if (transform.position.z < -15.25f)
        {
            Destroy(gameObject);
        }
        if (mIsDouble)
        {
            if (mIsShootLeft && mIsShootRight)
                Destroy(gameObject);
        }


    }
    private void OnDestroy()
    {
        Debug.Log("Dis=" + mDisFromGuide+"//Pos="+transform.position.z);
        GameObject.Find("GameManager").GetComponent<GameManager>().ProcesNote(mDisFromGuide);
    }
}



