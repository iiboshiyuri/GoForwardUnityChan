using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    //ゲムオバテキスト
    private GameObject gameOverText;

    //走行距離テキスト
    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 5f;

    //ゲムオバの判定
    private bool isGameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトの実体検索
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            //走った距離更新
            this.len += this.speed * Time.deltaTime;

            //走った距離表示
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }
        //ゲムオバなった場合
        if (this.isGameOver == true)
        {
            //クリックされたらシーンロード
            if (Input.GetMouseButtonDown(0))
            {
                //SampleScene読み込む
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void GameOver()
    {
        //ゲムオバになったとき画面上ゲムオバを表示
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
