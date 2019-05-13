using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class MusicImageSetting : MonoBehaviour
    {
        private Image[] _mMusicListImage;

        public Sprite[] mMusicImage;

        // Use this for initialization
        void Start()
        {
            _mMusicListImage = new Image[3];
            for (int i = 0; i < 3; i++)
            {
                _mMusicListImage[i].sprite = mMusicImage[i];
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void MusicPick(int num)
        {
          // _mMusicListImage[num].transform.position = new Vector3()
        }
    }

