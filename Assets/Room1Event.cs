﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room1Event : MonoBehaviour {

    //メッセージ表示持続時間
    private float messageEndTime = 4.5f;

    private float messageStartTime = 0f;

    private GameObject objectA;

    private GameObject player;

    private GameObject message;

    private GameManager gameManager;

    private bool isInRoom1;

	// Use this for initialization
	void Start () {

        this.objectA = GameObject.Find("ObjectA");

        this.player = GameObject.Find("MainPlayer");

        this.message = GameObject.Find("PleasePushKeyInfo");

        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        isInRoom1 = false;

    }

    // Update is called once per frame
    void Update () {

        //部屋に入った状態の場合
        if (isInRoom1 == true)
        {
            Vector3 target = player.transform.position;
            target.y = objectA.transform.position.y;

            objectA.transform.LookAt(target);

            //キーボードのSpaceを押す
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //サブカメラ切り替え
                gameManager.ChangeCameraA(true);
            }            
        }

        //キーボードのSpaceを離す
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //プレイヤーカメラ切り替え
            gameManager.ChangeCameraA(false);
        }

        //メッセージ表示を持続
        if (message.GetComponent<Text>().text != "" && gameManager.doneRoom1MessageFlg == true)
        {

            messageStartTime += Time.deltaTime;

            //一定時間経過したらメッセージを消す
            if (messageStartTime > messageEndTime)
            {
                message.GetComponent<Text>().text = "";
                messageStartTime = 0f;
            }

        }

    }

    //当たり判定に入る。
    void OnTriggerEnter(Collider collider){

        if (collider.tag == "Player")
        {
            isInRoom1 = true;

            //メッセージ表示
            if (gameManager.doneRoom1MessageFlg == false)
            {
                message.GetComponent<Text>().text = "Please push \"Space Key\".";
                gameManager.doneRoom1MessageFlg = true;
            }

        }

    }

    //当たり判定を抜ける。
    void OnTriggerExit(Collider collider){
        isInRoom1 = false;
    }

}
