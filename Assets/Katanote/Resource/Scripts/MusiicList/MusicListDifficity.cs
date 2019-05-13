using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests {
    public class MusicListDifficity : MonoBehaviour, IInputClickHandler
    {

       static internal int Mode;
        public Material[] Difficity;
        private void Start()
        {
            Easy();
        }

        public void Easy()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Difficity[i].color = new Color(255, 255, 255);
                }
                else
                {
                    Difficity[i].color = new Color(0, 0, 0);
                }
            }
            Mode = 1;
        }

        public void Normal()
        {
            Difficity[0].color = new Color(0, 0, 0);
            Difficity[1].color = new Color(255, 255, 255);
            Difficity[2].color = new Color(0, 0, 0);
            Mode = 2;
        }

        public void Hard()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    Difficity[i].color = new Color(255, 255, 255);
                }
                else
                {
                    Difficity[i].color = new Color(0, 0, 0);
                }
            }
            Mode = 3;
        }



        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (eventData.selectedObject == gameObject)
            {
                if (gameObject.tag == "Easy")
                {
                    
                    Easy();
                    Debug.Log(Mode);
                }


                if (gameObject.tag == "Normal")
                {
                    Normal();
                    Debug.Log(Mode);
                }

                if (gameObject.tag == "Hard")
                {

                    Hard();
                    Debug.Log(Mode);
                }
            }
        }
        
    }
}

