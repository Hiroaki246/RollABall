using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを追従するカメラの設定
public class CameraController : MonoBehaviour
{
    public GameObject player; // Playerを参照

    private Vector3 offset; // CameraとPlayerの距離

    // ゲーム最初のフレームでoffset値を算出
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate()は設定が全て終わった状態の情報を取得する
    // LateUpdate()はUpdate()の実行後に実行される
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
