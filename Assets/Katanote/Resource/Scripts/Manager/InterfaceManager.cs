using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour {

    
    static internal bool a;

    [Header("Screen-MainMenu")]
    public GameObject ScreenMainMenu;
    [Header("Screen-SelectMusic")]
    public GameObject ScreenSelectMusic;
    [Header("Screen-Option")]
    public GameObject ScreenOption;
    [Header("Screen-Puase")]
    public GameObject ScreenPause;
    [Header("Screen-IngameMenu")]
    public GameObject ScreenInGameMenu;
    [Header("Screen-Result")]
    public GameObject ScreenResult;

    #region ScreenMainMenu

    #region Screen Enable/Disable

    internal void ScreenMenuEnable()
    {
        ScreenMainMenu.SetActive(true);
    }

    internal void ScreenMenuDisable()
    {
        ScreenMainMenu.SetActive(false);
    }

    #endregion

    #region Element Control

    #endregion

    #region Interface Event

    public void ScreenMenuEnableEvent()
    {
        ScreenMenuEnable();
    }

    public void ScreenMenuDisableEvent()
    {
        ScreenMenuDisable();
    }

    #endregion

    #endregion

    #region ScreenSelectMusic

    #region Screen Enable/Disable

    internal void ScreenSelectMusicEnable()
    {
        ScreenSelectMusic.SetActive(true);
    }

    internal void ScreenSelectMusicDisable()
    {
        ScreenSelectMusic.SetActive(false);
    }
    #endregion

    #region Element Control

    #endregion

    #region Interface Event

    public void ScreenSelectMusicEnableEvent()
    {
        ScreenSelectMusicEnable();
    }

    public void ScreenSelectMusicDisableEvent()
    {
        ScreenSelectMusicDisable();
    }

    #endregion

    #endregion

    #region ScreenOption

    #region Screen Enable/Disable

    internal void ScreenOptionEnable()
    {
        ScreenOption.SetActive(true);
    }

    internal void ScreenOptionDisable()
    {
        ScreenOption.SetActive(false);
    }
    #endregion

    #region Element Control

    #endregion

    #region Interface Event

    public void ScreenOptionEnableEvent()
    {
        ScreenOptionEnable();
    }

    public void ScreenOptionDisableEvent()
    {
        ScreenOptionDisable();
    }
    #endregion

    #endregion

    #region ScreenPause

    #region Screen Enable/Disable

    internal void ScreenPauseEnable()
    {
        ScreenPause.SetActive(true);
    }

    internal void ScreenPauseDisable()
    {
        ScreenPause.SetActive(false);
    }
    #endregion

    #region Element Control

    #endregion

    #region Interface Event

    public void ScreenPauseEnableEvent()
    {
        ScreenPauseEnable();
    }

    public void ScreenPauseDisableEvent()
    {
        ScreenPauseDisable();
    }
    #endregion
    #endregion

    #region ScreenInGameMenu

    #region Screen Enable/Disable

    internal void ScreenInGameMenuEnable()
    {
        ScreenInGameMenu.SetActive(true);
    }

    internal void ScreenInGameMenuDisable()
    {
        ScreenInGameMenu.SetActive(false);
    }
    #endregion

    #region Element Control

    #endregion

    #region Interface Event

    public void ScreenInGameEnableEvent()
    {
        ScreenInGameMenuEnable();
    }

    public void ScreenInGameDisableEvent()
    {
        ScreenInGameMenuDisable();
    }

    #endregion

    #endregion

    #region ScreenResult

    #region Screen Enable/Disable

    internal void ScreenResultEnable()
    {
        ScreenResult.SetActive(true);
    }

    internal void ScreenResultDisable()
    {
        ScreenResult.SetActive(false);
    }

    #endregion

    #region Element Control

    #endregion

    #region Interface Event

    public void ScreenResultEnableEvent()
    {
        ScreenResultEnable();
    }

    public void ScreenResultDisableEvent()
    {
        ScreenResultDisable();
    }

    #endregion

    #endregion

}
