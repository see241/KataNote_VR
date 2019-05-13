using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_WSA && UNITY_2017_2_OR_NEWER
using System.Collections.Generic;
using UnityEngine.XR.WSA.Input;
#endif

namespace HoloToolkit.Unity {
    public class RauseModule : MonoBehaviour
    {
        #region TouchpadSelect

        // Copyright (c) Microsoft Corporation. All rights reserved.
        // Licensed under the MIT License. See LICENSE in the project root for license information.
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
        private class ControllerState
        {
            public InteractionSourceHandedness Handedness;
            public Vector3 PointerPosition;
            public Quaternion PointerRotation;
            public Vector3 GripPosition;
            public Quaternion GripRotation;
            public bool Grasped;
            public bool MenuPressed;
            public bool SelectPressed;
            public float SelectPressedAmount;
            public bool ThumbstickPressed;
            public Vector2 ThumbstickPosition;
            public bool TouchpadPressed;
            public bool TouchpadTouched;
            public Vector2 TouchpadPosition;
        }

        private Dictionary<uint, ControllerState> controllers;
#endif

        // Text display label game objects
        public TextMesh LeftInfoTextPointerPosition;
        public TextMesh LeftInfoTextPointerRotation;
        public TextMesh LeftInfoTextGripPosition;
        public TextMesh LeftInfoTextGripRotation;
        public TextMesh LeftInfoTextGripGrasped;
        public TextMesh LeftInfoTextMenuPressed;
        public TextMesh LeftInfoTextTriggerPressed;
        public TextMesh LeftInfoTextTriggerPressedAmount;
        public TextMesh LeftInfoTextThumbstickPressed;
        public TextMesh LeftInfoTextThumbstickPosition;
        public TextMesh LeftInfoTextTouchpadPressed;
        public TextMesh LeftInfoTextTouchpadTouched;
        public TextMesh LeftInfoTextTouchpadPosition;
        public TextMesh RightInfoTextPointerPosition;
        public TextMesh RightInfoTextPointerRotation;
        public TextMesh RightInfoTextGripPosition;
        public TextMesh RightInfoTextGripRotation;
        public TextMesh RightInfoTextGripGrasped;
        public TextMesh RightInfoTextMenuPressed;
        public TextMesh RightInfoTextTriggerPressed;
        public TextMesh RightInfoTextTriggerPressedAmount;
        public TextMesh RightInfoTextThumbstickPressed;
        public TextMesh RightInfoTextThumbstickPosition;
        public TextMesh RightInfoTextTouchpadPressed;
        public TextMesh RightInfoTextTouchpadTouched;
        public TextMesh RightInfoTextTouchpadPosition;

        private void Awake()
        {
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            controllers = new Dictionary<uint, ControllerState>();

            InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;

            InteractionManager.InteractionSourceLost += InteractionManager_InteractionSourceLost;
            InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;
#endif
        }

        private void Start()
        {
            if (DebugPanel.Instance != null)
            {
                DebugPanel.Instance.RegisterExternalLogCallback(GetControllerInfo);
            }
        }

#if UNITY_WSA && UNITY_2017_2_OR_NEWER
        private void InteractionManager_InteractionSourceDetected(InteractionSourceDetectedEventArgs obj)
        {
            Debug.LogFormat("{0} {1} Detected", obj.state.source.handedness, obj.state.source.kind);
            if (obj.state.source.kind == InteractionSourceKind.Controller && !controllers.ContainsKey(obj.state.source.id))
            {
                controllers.Add(obj.state.source.id, new ControllerState { Handedness = obj.state.source.handedness });
            }
        }

        private void InteractionManager_InteractionSourceLost(InteractionSourceLostEventArgs obj)
        {
            Debug.LogFormat("{0} {1} Lost", obj.state.source.handedness, obj.state.source.kind);

            controllers.Remove(obj.state.source.id);
        }

        private void InteractionManager_InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
        {
            ControllerState controllerState;
            if (controllers.TryGetValue(obj.state.source.id, out controllerState))
            {
                obj.state.sourcePose.TryGetPosition(out controllerState.PointerPosition, InteractionSourceNode.Pointer);
                obj.state.sourcePose.TryGetRotation(out controllerState.PointerRotation, InteractionSourceNode.Pointer);
                obj.state.sourcePose.TryGetPosition(out controllerState.GripPosition, InteractionSourceNode.Grip);
                obj.state.sourcePose.TryGetRotation(out controllerState.GripRotation, InteractionSourceNode.Grip);

                controllerState.Grasped = obj.state.grasped;
                controllerState.MenuPressed = obj.state.menuPressed;
                controllerState.SelectPressed = obj.state.selectPressed;
                controllerState.SelectPressedAmount = obj.state.selectPressedAmount;
                controllerState.ThumbstickPressed = obj.state.thumbstickPressed;
                controllerState.ThumbstickPosition = obj.state.thumbstickPosition;
                controllerState.TouchpadPressed = obj.state.touchpadPressed;
                controllerState.TouchpadTouched = obj.state.touchpadTouched;
                controllerState.TouchpadPosition = obj.state.touchpadPosition;
            }
        }
#endif

        private string GetControllerInfo()
        {
            string toReturn = string.Empty;
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
            foreach (ControllerState controllerState in controllers.Values)
            {
                // Debug message
                toReturn += string.Format("Hand: {0}\nPointer: Position: {1} Rotation: {2}\n" +
                                          "Grip: Position: {3} Rotation: {4}\nGrasped: {5} " +
                                          "MenuPressed: {6}\nSelect: Pressed: {7} PressedAmount: {8}\n" +
                                          "Thumbstick: Pressed: {9} Position: {10}\nTouchpad: Pressed: {11} " +
                                          "Touched: {12} Position: {13}\n\n",
                                          controllerState.Handedness, controllerState.PointerPosition, controllerState.PointerRotation.eulerAngles,
                                          controllerState.GripPosition, controllerState.GripRotation.eulerAngles, controllerState.Grasped,
                                          controllerState.MenuPressed, controllerState.SelectPressed, controllerState.SelectPressedAmount,
                                          controllerState.ThumbstickPressed, controllerState.ThumbstickPosition, controllerState.TouchpadPressed,
                                          controllerState.TouchpadTouched, controllerState.TouchpadPosition);

                // Text label display
                if ((controllerState.Handedness.Equals(InteractionSourceHandedness.Left) && controllerState.TouchpadPressed == true) || ((controllerState.Handedness.Equals(InteractionSourceHandedness.Right) && controllerState.TouchpadPressed == true)))
                {

                }
            }
#endif
            return toReturn.Substring(0, Math.Max(0, toReturn.Length - 2));
        }

        #endregion

        [Header("음악이미지 위치")]
        public Image mMusicImagePos;

        [Header("음악 이미지")]
        public Sprite mMusicImage1, mMusicImage2, mMusicImage3;

        [Header("랭크 이미지")]
        public Sprite[] mGameRank;

        [Header("Rank")]
        public Image mRankPos;

        [Header("일시정지창 콤보 스코어 Text")]
        public Text mTopScore, mBestCombo;

        [Header("일시정지UI")]
        public GameObject PauseUI;

        IEnumerator Enable()
        {
            Rank(MusicListModule.mScore);

            switch (MusicListModule._mChlike)
            {
                case 0:
                case 1:
                case 2:
                    mMusicImagePos.sprite = mMusicImage1;
                    break;
                case 3:
                case 4:
                case 5:
                    mMusicImagePos.sprite = mMusicImage2;
                    break;
                case 6:
                case 7:
                case 8:
                    mMusicImagePos.sprite = mMusicImage3;
                    break;

            }

            TextEnable();
            yield return null;
        }


        #region Pause

        void PauseEnable()
        {
            PauseUI.SetActive(true);
            StartCoroutine(Enable());
            StopCoroutine(Enable());    
        }

        void PauseDisable()
        {
            PauseUI.SetActive(false);
        }

        #endregion

        #region Text
        void TextEnable()
        {
            mTopScore.text = "TopScore" + "\n" + MusicListModule.mScore;
            mBestCombo.text = MusicListModule.mCombo + "Combo";
        }
        #endregion

        #region Rank
        public void Rank(int a)
        {

            if ((61 <= a) && (a <= 70))
            {
                mRankPos.sprite = mGameRank[4];
            }
            else if ((71 <= a) && (a <= 80))
            {
                mRankPos.sprite = mGameRank[3];
            }
            else if ((81 <= a) && (a <= 90))
            {
                mRankPos.sprite = mGameRank[2];
            }
            else if ((91 <= a) && (a <= 100))
            {
                mRankPos.sprite = mGameRank[1];
            }
            else if (101 <= a)
            {
                mRankPos.sprite = mGameRank[0];

            }
            else
            {
                mRankPos.sprite = mGameRank[5];
            }
        }
        #endregion
    }
}


