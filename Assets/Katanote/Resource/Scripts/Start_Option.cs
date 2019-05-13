using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class Start_Option : MonoBehaviour,IInputClickHandler
    {
        public GameStartModule mGameStartModule;
        public OptionModule mOptionModule;
        
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if(eventData.selectedObject == gameObject)
            {
                if (gameObject.tag == "option")
                {
                    mGameStartModule._isStart = true;
                    mOptionModule._isOption = true;
                    Debug.Log("옵션화면");
                }

                 if(gameObject.tag == "Back")
                {
                    mGameStartModule._isStart = false;
                    mOptionModule._isOption = false;
                    mGameStartModule.StartObjectEnable();
                    mOptionModule.OptionObjectDisable();
                }
            }
        }

    }
}