using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mManager;
    public bool mIsStop;
    public int mChain;
    public float mTotalScore;
    public  float mNoteScore;
    public Image mPauseImage;
    public Image mResultImage;
    public Text mScoreText;
    public int mMaxChain;
    public float mNoteCount;
    public float mChainScore;
    public int mCurSong;
    // Use this for initialization
    void Start()
    {
        mCurSong = mManager.GetComponent<NoteManager>().mCurSong;
        mResultImage.enabled = false;
        mScoreText.enabled = false;
        mPauseImage.enabled = false;
        mNoteCount = mManager.GetComponent<NoteManager>().mNoteCount;
        mNoteScore = 100/mNoteCount;
        mChain = 0;
        mIsStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mManager.GetComponent<NoteManager>().mDuringPlay)
        {
            if (!mIsStop)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (mManager.GetComponent<NoteManager>().mIsPlaySong)
                    {
                        GamePause();
                        mManager.GetComponent<NoteManager>().mIsPlaySong = false;
                        mPauseImage.enabled = true;
                            return;
                    }
                }
            }
            if (mIsStop)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!mManager.GetComponent<NoteManager>().mIsPlaySong)
                    {
                        GameRePlay();
                        mManager.GetComponent<NoteManager>().mIsPlaySong = true;
                        mPauseImage.enabled = false;
                        return;
                    }
                }
            }
        }
        if (mManager.GetComponent<NoteManager>().mIsGameEnd)
        {
            mResultImage.enabled = true;
            mChainScore = (20 / mNoteCount) * mMaxChain;
            mScoreText.text = "Your Score : "+(mTotalScore+mChainScore).ToString();
            PlayerPrefs.SetFloat("pff_GameScore_"+mCurSong , mTotalScore);
            PlayerPrefs.SetInt("pff_GameCombo"+mCurSong, mMaxChain);
            PlayerPrefs.SetFloat("pff_GameChainScore" + mCurSong, mChainScore);
            mScoreText.enabled = true;
        }
    }

    private void GamePause()
    {
        Time.timeScale = 0;
        GameObject.Find("Manager-Note").GetComponent<NoteManager>().PauseSong();
        Debug.Log("Pause");
        mIsStop = true;
    }
    private void GameRePlay()
    {
        Time.timeScale = 1;
        GameObject.Find("Manager-Note").GetComponent<NoteManager>().PlaySong();
        Debug.Log("Replay");
        mIsStop = false;

    }
    public void ProcesNote(float dis)
    {
        if (dis < 2)
            SuccessNote(dis);
        else
            FailNote();

    }

    public void FailNote()
    {
        mChain = 0;
        Debug.Log("Fail");
    }
    public void SuccessNote(float dis)
    {
        if (dis > 0.5&&dis<-0.15f)
        {
            mTotalScore += mNoteScore* 0.6f;
            mChain++;
            if (mChain > mMaxChain)
            {
                mMaxChain = mChain;
            }
        }
        if (dis <= -0.15f)
        {
            FailNote();
        }
        else
        {
            mTotalScore += mNoteScore;
            mChain++;
            if (mChain > mMaxChain)
            {
                mMaxChain = mChain;
            }
        }
    }

}
