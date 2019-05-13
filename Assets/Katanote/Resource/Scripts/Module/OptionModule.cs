using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionModule : MonoBehaviour {

    [Header("옵션 UI오브젝트")]
    public GameObject mObjectOption;
    [Header("옵션 UI오브젝트 활성화 비활성화 확인 변수")]
    internal bool _isOption;

    [Header("카메라 위치변경 스피드 변수")]
    private float _mSpeed = 5f;
    [Header("카메라 오브젝트")]
    public GameObject CameraPos;


    public void OptionObjectEnable()
    {
        mObjectOption.SetActive(true);
    }

    public void OptionObjectDisable()
    {
        mObjectOption.SetActive(false);
    }



    public void CameraPosRotationPlus(int type)             //카메라 X좌표 +를 해줌
    {
        type = 1;
        StartCoroutine(IECameraPos(type));
    }



    public void CameraPosRotationMinus(int type)           //카메라 위치 -를 해줌
    {
        type = 2;
        StartCoroutine(IECameraPos(type));
    }

    public void CameraPosXPlus(int type)
    {
        type = 3;
        StartCoroutine(IECameraPos(type));
    }

    public void CameraPosXMinus(int type)
    {
        type = 4;
        StartCoroutine(IECameraPos(type));
    }

    public void CameraPosYPlus(int type)
    {
        type = 5;
        StartCoroutine(IECameraPos(type));
    }

    public void CameraPosYMinus(int type)
    {
        type = 6;
        StartCoroutine(IECameraPos(type));
    }

    public void CameraPosZPlus(int type)
    {
        type = 7;
        StartCoroutine(IECameraPos(type));
    }

    public void CameraPosZMinus(int type)
    {
        type = 8;
        StartCoroutine(IECameraPos(type));
    }

    IEnumerator IECameraPos(int type)
    {
        for (int i = 0; i < 10; i++)
        {
            switch (type) {
                case 1:
                    CameraPos.transform.RotateAround(mObjectOption.transform.position, Vector3.down, _mSpeed / 10);
                    break;
                case 2:
                    CameraPos.transform.RotateAround(mObjectOption.transform.position, Vector3.up, _mSpeed / 10);
                    break;
                case 3:
                    CameraPos.transform.position += new Vector3(0.1f, 0, 0);
                    break;
                case 4:
                    CameraPos.transform.position -= new Vector3(0.1f, 0, 0);
                    break;
                case 5:
                    CameraPos.transform.position += new Vector3(0, 0.1f, 0);
                    break;
                case 6:
                    CameraPos.transform.position -= new Vector3(0, 0.1f, 0);
                    break;
                case 7:
                    CameraPos.transform.position += new Vector3(0, 0, 0.1f);
                    break;
                case 8:
                    CameraPos.transform.position -= new Vector3(0, 0, 0.1f);
                    break;
            }
            yield return new WaitForSeconds(0.02f);


        }
    }


    public void Awake()
    {

    }




}
