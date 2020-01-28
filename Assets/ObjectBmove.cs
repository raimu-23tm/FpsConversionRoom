using UnityEngine;

public class ObjectBmove : MonoBehaviour {

    //移動速度
    private float speed = 0.5f;

    //円の半径
    private float radius = 8.0f;

    private Vector3 centerPosition;

    private float moveX;
    private float moveZ;

    // Use this for initialization
    void Start () {
        
        //中心座標を保持
        centerPosition
            = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                       
    }
	
	// Update is called once per frame
	void Update () {

        //公転運動
        moveX = radius * Mathf.Sin(Time.time * speed);
        moveZ = radius * Mathf.Cos(Time.time * speed);

        this.transform.position 
            = new Vector3(centerPosition.x + moveX, centerPosition.y, centerPosition.z + moveZ);

        //中心方向を見る
        this.transform.LookAt(centerPosition);

    }
}
