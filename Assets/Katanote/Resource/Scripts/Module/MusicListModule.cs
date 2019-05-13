using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicListModule : MonoBehaviour {
    [Header("음악 이미지")]
    public Button mMusicImage1, mMusicImage2, mMusicImage3;

    [Header("음악 사운드")]
    public AudioSource mMusicSound1, mMusicSound2, mMusicSound3;

    [SerializeField]
    private GameObject mEnemyButton;
    [SerializeField]
    private AudioSource mEnemySound;

    [Header("음악 UI 오브젝트")]
    public GameObject mObjectMusicList;


    [SerializeField]
    [Header("음악 구분 변수")]
    internal int _mMusicPick = 0;
    [Header("음악 난이도 구분 변수")]
    [SerializeField]
    internal int _mMusicDifficity = 0;

    [SerializeField]
    static internal int _mChlike = 0;

    [Header("랭크 이미지")]
    public Sprite[] mGameRank;

    [Header("Rank")]
    public Image mRankPos;

    [Header("FC이미지,SS이미지")]
    public GameObject mFC, mSS;

    [SerializeField]
    [Header("점수")]
    internal int[] _mScore = { 0, };
    static internal int mScore;


    [SerializeField]
    [Header("콤보")]
    internal int[] _mCombo = { 0, };
    static internal int mCombo;

    [Header("음악 선택창 콤보 스코어 Text")]
    public Text mTopScore, mBestCombo;

    [Header("음악 이름 텍스트")]
    public Text mMusicName;

    internal bool _isMusicList;
    
    


    

    private void Start()
    {
        mMusicName.text = "Music Name : 당신은 그안에";
        _mMusicPick = 2;
        _mMusicDifficity = 1;
        ScoreAndComboRopu();
    }

    public void MusicListObjectEnable()
    {
        mObjectMusicList.SetActive(true);
    }

    public void MusicListObjectDisable()
    {
        mObjectMusicList.SetActive(false);
    }

    #region MusicStart

    public void Chlik()
    {
        StartCoroutine(mStartSelect(_mMusicPick, _mMusicDifficity));
        StopCoroutine(mStartSelect(_mMusicPick, _mMusicDifficity));
        SceneManager.LoadScene("InGame");
    }

    void ScoreCOmboSave(int i)
    {
        mScore = _mScore[i];
        mCombo = _mCombo[i];
    }

    public IEnumerator mStartSelect(int MusicPick, int Difficity)
    {
        Debug.Log("1");
        if (MusicPick == 1 && Difficity == 1)
        {
            PlayerPrefs.SetInt("LastHeroes", 1);
            _mChlike = 0;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 1 && Difficity == 2)
        {
            PlayerPrefs.SetInt("LastHeroes", 2);
            _mChlike = 1;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 1 && Difficity == 3)
        {
            PlayerPrefs.SetInt("LastHeroes", 3);
            _mChlike = 2;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 2 && Difficity == 1)
        {
            PlayerPrefs.SetInt("당신은그안에", 1);
            _mChlike = 3;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 2 && Difficity == 2)
        {
            PlayerPrefs.SetInt("당신은그안에", 2);
            _mChlike = 4;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 2 && Difficity == 3)
        {
            PlayerPrefs.SetInt("당신은그안에", 3);
            _mChlike = 5;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 3 && Difficity == 1)
        {
            PlayerPrefs.SetInt("FlashBack", 1);
            _mChlike = 6;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 3 && Difficity == 2)
        {
            PlayerPrefs.SetInt("FlashBack", 2);
            _mChlike = 7;
            ScoreCOmboSave(_mChlike);
        }

        else if (MusicPick == 3 && Difficity == 3)
        {
            PlayerPrefs.SetInt("FlashBack", 3);
            _mChlike = 8;
            ScoreCOmboSave(_mChlike);
        }

        yield return null;
    }

    #endregion

    #region MusicSelectButton

    public void RightButtonSelect()
    {
        mEnemyButton.GetComponent<Button>().image.sprite = mMusicImage1.image.sprite;
        mMusicImage1.image.sprite = mMusicImage2.image.sprite;
        mMusicImage2.image.sprite = mMusicImage3.image.sprite;
        mMusicImage3.image.sprite = mEnemyButton.GetComponent<Button>().image.sprite;
        mEnemySound = mMusicSound1;
        mMusicSound1 = mMusicSound2;
        mMusicSound2 = mMusicSound3;
        mMusicSound3 = mEnemySound;
        MusicZip(mMusicSound2.name);

    }

    public void LeftButtonSelect()
    {
        mEnemyButton.GetComponent<Button>().image.sprite = mMusicImage3.image.sprite;
        mMusicImage3.image.sprite = mMusicImage2.image.sprite;
        mMusicImage2.image.sprite = mMusicImage1.image.sprite;
        mMusicImage1.image.sprite = mEnemyButton.GetComponent<Button>().image.sprite;
        mEnemySound = mMusicSound3;
        mMusicSound3 = mMusicSound2;
        mMusicSound2 = mMusicSound1;
        mMusicSound1 = mEnemySound;
        MusicZip(mMusicSound2.name);
    }


    public void MusicZip(string MusicName)
    {
        SoundManager.Instance.StopAllSound();
        SoundManager.Instance.PlaySound(mMusicSound2.name);
        MusicNamepick(MusicName);
    }

    public void MusicNamepick(string MusicName)
    {
        switch (MusicName) {

            case "LastHeroesSound":
                _mMusicPick = 1;
                break;
            case "당신은 그안에Sound":
                mMusicName.text = "Music Name : 당신은 그안에";
                _mMusicPick = 2;
                break;

            case "FlashBackSound":
                mMusicName.text = "Music Name : Flash Back";
                _mMusicPick = 3;
                break;
        }

    }

    #endregion

    #region MusicDifficity

    public void ButtonEvnetEasy()
    {
        _mMusicDifficity = 1;
    }

    public void ButtonEvnetNormal()
    {
        _mMusicDifficity = 2;
    }
    public void ButtonEvnetHard()
    {
        _mMusicDifficity = 3;
    }


    #endregion

    #region PrePrft

   private void SetPrePrft(string Name)
    {
        if (PlayerPrefs.GetInt(Name)==1)
        {
            FCEnable();
        }
        else
        {
            FCDisaBle();
        }
    }

    #endregion

    #region Rank

    public void Rank(int a)
    {
        SSDisable();
        if ((80 <= a) && (a <= 89))
        {
            mRankPos.sprite = mGameRank[4];
        }
        else if ((90 <= a) && (a <= 99))
        {
            mRankPos.sprite = mGameRank[3];
        }
        else if ((100 <= a) && (a <= 109))
        {
            mRankPos.sprite = mGameRank[2];
        }
        else if ((110 <= a) && (a <= 119))
        {
            mRankPos.sprite = mGameRank[1];
        }
        else if (120 <= a)  
        {
            mRankPos.sprite = mGameRank[0];
            SSEnable();
        }
        else
        {
            mRankPos.sprite = mGameRank[5];
        }
     }


    #endregion

    #region FC,SS Enable and Disable

    private void SSEnable()
    {
        mSS.SetActive(true);
    }

    private void SSDisable()
    {
        mSS.SetActive(false);
    }

    private void FCEnable()
    {
        mFC.SetActive(true);
    }

    private void FCDisaBle()
    {
        mFC.SetActive(false);
    }
    #endregion

    #region Score And Combo

    public void ScoreAndComboChange(int GameScore, int GameCombo)
    {
        if(_mScore[_mChlike] <= GameScore)
        {
            _mScore[_mChlike] = GameScore;
            _mCombo[_mChlike] = GameCombo;
        }
    }



    #endregion

    #region TextEnable

   public void ScoreAndComboRopu()
    {
        StartCoroutine(_mTopScoreAndCombo());
        StopCoroutine(_mTopScoreAndCombo());
    }

   IEnumerator  _mTopScoreAndCombo() {

        switch (_mMusicPick) {
            case 1:
                if(_mMusicDifficity == 1)
                {
                    Rank(_mScore[0]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[0];
                    mBestCombo.text = _mCombo[0] + "Combo";
                }
                else if(_mMusicDifficity == 2)
                {
                    Rank(_mScore[1]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[1];
                    mBestCombo.text = _mCombo[1] + "Combo";
                }
                else if(_mMusicDifficity == 3) {
                    Rank(_mScore[2]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[2];
                        mBestCombo.text = _mCombo[2] + "Combo";
                    }
                break;

            case 2:
                if (_mMusicDifficity == 1)
                {
                    Rank(_mScore[3]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[3];
                    mBestCombo.text = _mCombo[3] + "Combo";
                }
                else if (_mMusicDifficity == 2)
                {
                    Rank(_mScore[4]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[4];
                    mBestCombo.text = _mCombo[4] + "Combo";
                }
                else if (_mMusicDifficity == 3)
                {
                    Rank(_mScore[5]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[5];
                    mBestCombo.text = _mCombo[5] + "Combo";
                }
                break;

            case 3:
                if (_mMusicDifficity == 1)
                {
                    Rank(_mScore[6]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[6];
                    mBestCombo.text = _mCombo[6] + "Combo";
                }
                else if (_mMusicDifficity == 2)
                {
                    Rank(_mScore[7]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[7];
                    mBestCombo.text = _mCombo[7] + "Combo";
                }
                else if (_mMusicDifficity == 3)
                {
                    Rank(_mScore[8]);
                    mTopScore.text = "TopScore" + "\n" + _mScore[8];
                    mBestCombo.text = _mCombo[8] + "Combo";
                }
                break;
        }


        yield return null;
    }


    #endregion
}
