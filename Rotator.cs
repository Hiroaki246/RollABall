using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キューブを回転させるスクリプト
public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // transform.Rotate()はゲームオブジェクトを回転させる
        // ※transform.Translate()はゲームオブジェクトを移動させる
        // Time.deltaTimeによってフレームレートに依存せずスムーズに回転させる
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
