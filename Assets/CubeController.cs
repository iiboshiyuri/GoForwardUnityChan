using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("i");
        if (collision.gameObject)
        {
            if (collision.gameObject.tag != "UnityChanTag")
            {
                Debug.Log("a");
                GetComponent<AudioSource>().Play();
            }

        }
    }
    //キューブ移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //キューブを移動
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外出たら破棄
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    
}
