using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaGenerator : MonoBehaviour
{
    //配置するキャラのPrefab情報（設計図）
    [SerializeField]
    private CharaController charaPrefab;

    //

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mousePotisionで指定した座標に向かってカメラからRayを発射する
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Rayの可視化(発射元、角度*距離、色、可視時間)
            Debug.DrawRay(ray.origin, ray.direction*50, Color.blue, 1.0f);

            //Rayが感知した座標の情報を得ることが出来るか（画面外などをクリックしたら感知しない）
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) == true)
            {
                //Rayの当たったマスのx座標値を丸めて整数にしてxに代入（マス中央座標用）
                float x = Mathf.RoundToInt(hit.point.x);

                //Rayの当たったマスのz座標値を丸めて整数にしてzに代入（マス中央座標用）
                float z = Mathf.RoundToInt(hit.point.z);

                //GameObject型変数にCharaPrefabを実体化
                CharaController chara = Instantiate(charaPrefab);

                Debug.Log("キャラを配置");

                //取得したx,z座標に実体化させたキャラPrefabを配置する
                chara.transform.position = new Vector3(x, hit.point.y, z);

                //生成したキャラにステータスを設定
                chara.SetCharaStates(100, 10);
            }

        }

    }
}
