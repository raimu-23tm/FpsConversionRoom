using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMoveEvent : MonoBehaviour {

    //移動時間
    private int moveTime = 20;

    private int moveCount;

    private bool isDoneEnter;
    private bool isMoving;

    private GameObject player;
    private Vector3 moveStartPosition;

    // Use this for initialization
    void Start () {

        this.player = GameObject.Find("FPSController");

    }
	
	// Update is called once per frame
	void Update () {

        //中心部に少しずつ移動する。
        if (isMoving == true && isDoneEnter == false)
        {

            moveCount += 1;

            player.transform.position = 
                new Vector3(moveStartPosition.x + ((this.transform.position.x - moveStartPosition.x) / moveTime) * moveCount,
                            moveStartPosition.y,
                            moveStartPosition.z + ((this.transform.position.z - moveStartPosition.z) / moveTime) * moveCount );

            if (moveCount == moveTime)
            {
                player.transform.position = 
                    new Vector3(this.transform.position.x, moveStartPosition.y, this.transform.position.z);
                
                isMoving = false;
                isDoneEnter = true;
                moveCount = 0;

            }

        }

	}

    //当たり判定に入る。
    void OnTriggerEnter(Collider colinder)
    {

        if (colinder.tag == "player")
        {
            isMoving = true;
            moveCount = 0;

            moveStartPosition =
                new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        }

    }

    //当たり判定を抜ける。
    void OnTriggerExit(Collider colinder)
    {
        isDoneEnter = false;
    }

}
