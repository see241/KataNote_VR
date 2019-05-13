using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    [RequireComponent(typeof(Renderer))]
    public class StartScene: MonoBehaviour, IInputClickHandler
    {
        public GameStartModule mGameStartModule;
        public MusicListModule mMusicListModule;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if(eventData.selectedObject == gameObject)
            {
                if (gameObject.tag == "Start")
                {
                    mGameStartModule._isStart = true;
                    mMusicListModule._isMusicList = true;
                    Debug.Log("MusicListSecne");
                }


                else if(gameObject.tag == "Back")
                {
                    mGameStartModule._isStart = false;
                    mMusicListModule._isMusicList = false;
                    mGameStartModule.StartObjectEnable();
                    mMusicListModule.MusicListObjectDisable();
                }
            }
        }
    }
}

