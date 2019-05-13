using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleNoteControl : MonoBehaviour {

    public GameObject mObjectGuide;
    public float speed;
    public float mDisFromGuide;
    float timer;
    // Use this for initialization
    void Start()
    {
        mDisFromGuide = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.z < -15)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("Dis=" + mDisFromGuide);
        GameObject.Find("GameManager").GetComponent<GameManager>().ProcesNote(mDisFromGuide);
    }
}
