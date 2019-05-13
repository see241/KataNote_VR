using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{

    [Header("노말 채포 텍스트 에셋")]
    public TextAsset[] mTextAssetSong;

    [Header("노래 이름")]
    public string _mSongName;

    [Header("노드 리스트")]
    public List<Note> mNoteList;

    [Header("노트 오브젝트")]
    public GameObject mObjectShortNote;
    public GameObject mObjectHoldNote;

    [SerializeField]
    private bool _mIsParse;
    //시스템 데이터 
    public float mTurmX;
    public float mTurmY;
    public float mTurmZ;
    public float mStartPos;
    private float _mDelay;
    private float _mStartTime;
    public float mPlayTime;
    private float _mBeat;
    private AudioSource _mGameSong;

    public float mNoteCount;

    private int _mCurNote;

    public bool mDuringPlay;
    public bool mIsGameEnd;

    public bool mIsPlaySong;

    private float _mTimer;
    public int mCurSong;
    private void Awake()
    {
        mNoteList = new List<Note>();
        mNoteCount = 0;
        _mDelay = 0;
        mIsPlaySong = false;
        mDuringPlay = false;
        mIsGameEnd = false;
        mCurSong = PlayerPrefs.GetInt("pff_SelectSong");
        ParseSongTextAsset(mCurSong);
        GameStart();

    }
    private void Update()
    {
        
        if (mDuringPlay)
        {
            if (Time.time - mPlayTime > (mNoteList[_mCurNote].mCtime))
            {
                if (_mCurNote+1 < mNoteList.Count)
                {
                    mNoteList[_mCurNote].CreateNote();
                    _mCurNote++;
                }
                else
                {
                    Invoke("SetGameEnd", 6.5f);
                }
            }


        }
    }
    private void GameStart()
    {
        mDuringPlay = true;
        mPlayTime = Time.time;
        Debug.Log(mNoteList.Count);
        Invoke("PlaySong", 5);
    }
    private void SetGameEnd()
    {
        mDuringPlay = false;
        mIsGameEnd = true;
    }
    //public void FrameworkStartEvent()
    //{
    //    if (IENoteCreateFramework == null)
    //    {
    //        IENoteCreateFramework = NoteCreateFramework();
    //    }

    //    StartCoroutine(IENoteCreateFramework);
    //}

    //public void FrameworkStopEvent()
    //{
    //    if (IENoteCreateFramework != null)
    //    {
    //        StopCoroutine(IENoteCreateFramework);
    //        IENoteCreateFramework = null;
    //    }
    //}

    //IEnumerator NoteCreateFramework()
    //{
    //    int time = 0;

    //    for (int i = 0; i < mNoteList.Count; i++)
    //    {
    //        yield return new WaitForSeconds(time);
    //        //노트 리스트 제어
    //        // time = mNoteList[i].mNodeNum

    //    }
    //}

    internal void ParseSongTextAsset(int stat)
    {
        List<string> list = new List<string>(mTextAssetSong[stat].text.Split('\n'));
        for (int i = 0; i < list.Count; i++)
        {
            Process(list[i]);
        }

    }

    private void Process(string list)
    {
        if (list.StartsWith("#"))
        {
            string[] keyList = list.Split(':');
            switch (keyList[0])
            {
                case "#DELAY":
                    _mDelay = float.Parse(keyList[1]);
                    break;
                case "#SONGNAME":
                    _mSongName = keyList[1];
                    GetPlaySong();
                    break;
                case "#SPEED":
                    mObjectShortNote.GetComponent<NoteControl>().speed = float.Parse(keyList[1]);
                    mObjectHoldNote.GetComponent<NoteControl>().speed = float.Parse(keyList[1]);
                    break;
                case "#STARTPOS":
                    mStartPos = float.Parse(keyList[1]);
                    break;
                case "#STARTTIME":
                    _mStartTime = float.Parse(keyList[1]);
                    break;
                case "#BEAT":
                    _mBeat = float.Parse(keyList[1]);
                    break;
                default:
                    return;
            }
        }
        else if (list.StartsWith("@"))
            mNoteList.Add(noteProcess(list));
    }

    private Note noteProcess(string list)
    {
        list = list.Replace("@", "");
        char[] step = new char[] { '@', '/' };

        Note temp = new Note();
        string[] keylist = list.Split(step);
        temp.mNodeNum = int.Parse(keylist[0]);
        temp.mPosX = int.Parse(keylist[1].ToString()) * mTurmX;
        temp.mPosY = (int.Parse(keylist[2].ToString()) - 1) * mTurmY;
        int node = int.Parse(keylist[3].ToString());
        temp.mCtime = _mStartTime + ((temp.mNodeNum - 1) * _mBeat);

        switch (node)
        {
            case 0:
                temp.mNoteObject = mObjectShortNote;
                break;
            case 1:
                temp.mNoteObject = mObjectHoldNote;
                break;
        }
        mNoteCount++;
        return temp;
    }

    void GetPlaySong()
    {
        _mGameSong = GameObject.Find("Manager-Sound").GetComponent<SoundManager>().GetSound(_mSongName);
    }
    public void PlaySong()
    {
        _mGameSong.Play();
        mIsPlaySong = true;
    }
    public void PauseSong()
    {
        _mGameSong.Pause();
    }
}

[System.Serializable]
public class Note : MonoBehaviour
{
    public int mNodeNum;
    public float mPosX;
    public float mPosY;
    public float mCtime;
    public GameObject mNoteObject;
    public void CreateNote()
    {
        mNoteObject.transform.position = new Vector3(mPosX, mPosY, 15);
        Instantiate(mNoteObject);
    }
}
