using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //部屋1のメッセージを表示済みか
    public bool doneRoom1MessageFlg;

    //部屋2のメッセージを表示済みか
    public bool doneRoom2MessageFlg;

    //プレイヤーカメラ
    public Camera playerCamera;

    //オブジェクトAのカメラ
    public Camera objectACamera;

    //オブジェクトBのカメラ
    public Camera objectBCamera;

    // Use this for initialization
    void Start () {
        doneRoom1MessageFlg = false;
        doneRoom2MessageFlg = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeCameraA(bool isSubCamera)
    {
        //サブカメラをオンへ
        if (isSubCamera)
        {
            objectACamera.enabled = true;
            playerCamera.enabled = false;
            objectBCamera.enabled = false;
        }
        //プレイヤーカメラをオンへ
        else
        {
            playerCamera.enabled = true;
            objectACamera.enabled = false;
            objectBCamera.enabled = false;
        }
    }

    public void ChangeCameraB(bool isSubCamera)
    {
        //サブカメラをオンへ
        if (isSubCamera)
        {
            objectBCamera.enabled = true;
            objectACamera.enabled = false;
            playerCamera.enabled = false;
        }
        //プレイヤーカメラをオンへ
        else
        {
            playerCamera.enabled = true;
            objectBCamera.enabled = false;
            objectACamera.enabled = false;
        }
    }

}
