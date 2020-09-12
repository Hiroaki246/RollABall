using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText; // スコア表示用の文字列
    public Text winText; // クリア用の文字列

    private Rigidbody rb; // 物理演算 Rigidbody:剛体
    private int count;

    void Start() // ゲーム最初のフレーム
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyのコンポーネントを取得
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        // プレイヤーのキーボード入力を取得 GetAxis:軸の取得
        float moveHorizontal = Input.GetAxis("Horizontal"); // 水平軸
        float moveVertical = Input.GetAxis("Vertical"); // 垂直軸

        // ↓平面で動くゲームのため、Vector3のY軸は0 Vector3クラスのmovementインスタンスを
        //  取得した水平、垂直軸の情報を引数に生成
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed); // AddForceにて剛体rbに力(入力)を加える speedは速度補正量

    }

    // 当たり判定
    // OnTriggerEnter()は、プレイヤーがトリガーとなっているColliderに衝突した際にコールされる
    void OnTriggerEnter(Collider other) // オブジェクトの全てがColliderを持っており、衝突を通知してくれる
    {
        // 下記条件式は、プレイヤーが衝突したオブジェクトのタグが"Pick Up"だった場合、
        // "Pick Up"タグ付きのオブジェクトを非アクティブ化する
        if (other.gameObject.CompareTag("Pick Up")) // CompareTag()によってtagの値を文字列を比較
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}