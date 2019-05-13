using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGunFire : MonoBehaviour
{
    public GameObject mBulletObject;
    [SerializeField]
    private GameObject _mFirePos;
    private bool _mIsShoot;
    private float _mTimer;
    public float mFireDelay;
    private AudioSource _audio;
    private Animator _mAnimator;
    private int _mLayMask;
    public ParticleSystem mPtc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DestroyCheck()
    {
        Ray ray = new Ray(_mFirePos.transform.position, _mFirePos.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Nodes")
            {
                if (!hit.collider.gameObject.GetComponent<NoteControl>().mIsDouble)
                {
                    mPtc.transform.position = hit.collider.gameObject.transform.position;
                    Instantiate(mPtc);
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<NoteControl>().mIsDouble)
                {
                    hit.collider.gameObject.GetComponent<NoteControl>().mIsShootLeft = true;
                }
            }
        }
    }
    #region Shot

    public void ShotChlik()
    {
        _audio = GetComponent<AudioSource>();
        _mAnimator = GetComponent<Animator>();
        _mFirePos = GameObject.Find("LeftGun(Clone)").transform.GetChild(2).gameObject;
        Debug.Log(_mFirePos.transform.position);
        Debug.Log(_mFirePos.transform.localPosition);
        if (!_mIsShoot)
        {

            mBulletObject.GetComponent<Bullet>().fireVec = _mFirePos.transform.forward;
            mBulletObject.transform.position = _mFirePos.transform.localPosition;
            Instantiate(mBulletObject);
            _audio.Play();
            DestroyCheck();
            _mIsShoot = true;
            _mAnimator.SetBool("IsShoot", _mIsShoot);

        }
        if (_mIsShoot)
        {
            _mTimer += Time.deltaTime;
            if (_mTimer > mFireDelay)
            {
                _mIsShoot = false;
                _mAnimator.SetBool("IsShoot", _mIsShoot);
                _mTimer = 0;
            }
        }
    }


    IEnumerator Shot()
    {
        if (GameObject.Find("Manager-Note").GetComponent<NoteManager>().mDuringPlay)
        {
            ShotChlik();
        }
        yield return null;
    }
    #endregion

}
