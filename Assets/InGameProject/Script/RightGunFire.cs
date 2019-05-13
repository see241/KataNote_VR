using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGunFire : MonoBehaviour
{

    public GameObject A;
    public GameObject mBulletObject;
    [SerializeField]
    private GameObject _mFirePos;
    private bool _mIsShoot;
    private float _mTimer;
    public float mFireDelay;
    private Animator _mAnimator;
    private AudioSource _audio;
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
        Ray ray = new Ray(_mFirePos.transform.position, _mFirePos.transform.position + mBulletObject.transform.position);
        Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit hit;
        Debug.Log(ray.direction);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            
            Debug.Log("레이가 오브젝트랑 맞음");
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
                    hit.collider.gameObject.GetComponent<NoteControl>().mIsShootRight = true;
                }
            }


        }
    }

    #region Shot

    public void ShotChick()
    {
        _mFirePos = GameObject.Find("RightController");
        _audio = GetComponent<AudioSource>();
        _mAnimator = GetComponent<Animator>();
        
        if (!_mIsShoot)
        {
            mBulletObject.GetComponent<Bullet>().fireVec = _mFirePos.transform.forward;
            mBulletObject.transform.position = new Vector3(_mFirePos.transform.position.x, _mFirePos.transform.position.y, _mFirePos.transform.position.z);
            mBulletObject.transform.rotation = _mFirePos.transform.rotation;
            Instantiate(mBulletObject,mBulletObject.transform.position,Quaternion.Euler(mBulletObject.transform.rotation.x + 35f, mBulletObject.transform.rotation.y+2f, mBulletObject.transform.rotation.z));
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
  
    public void StartShot()
    {
        StartCoroutine(Shot());
        StopCoroutine(Shot());
    }

  public IEnumerator Shot()
    {
        if (GameObject.Find("Manager-Note").GetComponent<NoteManager>().mDuringPlay)
        {
            ShotChick();
        }
        else {
            ShotChick();
        }

        yield return null;
    }

    #endregion
}
