using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room2Event : MonoBehaviour
{

    //メッセージ表示持続時間
    private float messageEndTime = 4.5f;

    private float messageStartTime = 0f;

    private GameObject objectB;

    private GameObject player;

    private GameObject message;

    private GameManager gameManager;

    private bool isInRoom2;

    // Use this for initialization
    void Start()
    {

        this.objectB = GameObject.Find("ObjectB");

        this.player = GameObject.Find("FPSController");

        this.message = GameObject.Find("PleasePushKeyInfo");

        this.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        isInRoom2 = false;

    }

    // Update is called once per frame
    void Update()
    {

        //部屋に入った状態の場合
        if (isInRoom2 == true)
        {            
            //キーボードのSpaceを押す
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //サブカメラ切り替え
                gameManager.ChangeCameraB(true);
            }
        }

        //キーボードのSpaceを離す
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //プレイヤーカメラ切り替え
            gameManager.ChangeCameraB(false);
        }

        //メッセージ表示を持続
        if (message.GetComponent<Text>().text != "" && gameManager.doneRoom2MessageFlg == true)
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
    void OnTriggerEnter(Collider colinder)
    {
        if (colinder.tag == "player")
        {
            isInRoom2 = true;

            //メッセージ表示
            if (gameManager.doneRoom2MessageFlg == false)
            {
                message.GetComponent<Text>().text = "Please push \"Space Key\".";
                gameManager.doneRoom2MessageFlg = true;
            }

        }

    }

    //当たり判定を抜ける。
    void OnTriggerExit(Collider colinder)
    {
        isInRoom2 = false;
    }

}
