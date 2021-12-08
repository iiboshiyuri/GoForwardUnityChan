using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unitychan移動のコンポーネント入れる
    Rigidbody2D rigid2D;

    //地面の１
    private float groundLevel = -3.0f;

    //ジャンプ速度減衰
    private float dump = 0.8f;

    //ジャンプ速度
    float jumpVelocity = 20;

    //ゲムオバなる１
    private float deadLine = -9;
    // Start is called before the first frame update
    void Start()
    {
        //アニメータにコンポーネントを取得
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dコンポーネント取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //走るアニメーションを再生するために、Animatorのパラメーターを調節する
        this.animator.SetFloat("Horizontal", 1);
        //着地してるかどうか
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプのときボリューム0
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされたら
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向の力
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        // クリックやめたら上方向へ速度減速
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        // デッドライン超えたらゲムオバ
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数呼び出して画面上GameOver表示
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃん破棄
            Destroy(gameObject);
        }
    }
}
