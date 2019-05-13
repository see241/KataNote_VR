using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraPosition : MonoBehaviour
{
    //public GameObject MainPos;
    //public static int Pick = 0;

    //private void Awake()
    //{
        
    //}

    //// Use this for initialization
    //void Start()
    //{
    //    if (Pick == 1)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    if (Pick == 0)
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //        Pick = 1;
    //    }

       
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.collider.gameObject.tag == "XPosRight")
    //            {
    //                XPosRIght();

    //            }
    //            if(hit.collider.gameObject.tag == "XPosLeft")
    //            {
    //                XPosLeft();
    //            }

    //            if(hit.collider.gameObject.tag == "YPosRight")
    //            {
    //                YPosRIght();
    //            }

    //            if(hit.collider.gameObject.tag == "YPosLeft")
    //            {
    //                YPosLeft();
    //            }

    //            if(hit.collider.gameObject.tag == "ZPosRight")
    //            {
    //                ZPosRight();
    //            }
    //            if(hit.collider.gameObject.tag == "ZPosLeft")
    //            {
    //                ZPosLeft();
    //            }

    //            if(hit.collider.gameObject.tag == "RotationRight")
    //            {
    //                RotationRight();
    //            }
    //            if(hit.collider.gameObject.tag == "RotationLeft")
    //            {
    //                RotationLeft();
    //            }
    //        }
    //    }
    //}

    

    //void XPosRIght()
    //{
    //    MainPos.transform.localPosition += new Vector3(1f, 0f, 0f);
    //}

    //void XPosLeft()
    //{
    //    MainPos.transform.localPosition -= new Vector3(1f, 0f, 0f);
    //}

    //void YPosRIght()
    //{
    //    MainPos.transform.localPosition += new Vector3(0f, 1f, 0f);
    //}

    //void YPosLeft()
    //{
    //    MainPos.transform.localPosition -= new Vector3(0f, 1f, 0f);
    //}

    //void ZPosRight()
    //{
    //    MainPos.transform.localPosition += new Vector3(0f, 0f, 1f);
    //}

    //void ZPosLeft()
    //{
    //    MainPos.transform.localPosition -= new Vector3(0f, 0f, 1f);
    //}

    //void RotationRight()
    //{
    //    MainPos.transform.Rotate(0, 3, 0);
    //}

    //void RotationLeft()
    //{
    //    MainPos.transform.Rotate(0, -3, 0);
    //}
}
