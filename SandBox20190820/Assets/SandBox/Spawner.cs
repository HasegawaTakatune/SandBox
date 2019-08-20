using UnityEngine;

public class Spawner : MonoBehaviour
{

    /// <summary>
    /// 生成キャラクタ
    /// </summary>
    [Header("生成キャラクタ")]
    [SerializeField] private GameObject SpawnCharacter;

    /// <summary>
    /// 生成位置
    /// </summary>
    [Header("生成位置")]
    [SerializeField] private Transform SpawnTrans;

    /// <summary>
    /// 生成間隔（座標）
    /// </summary>
    [Header("生成間隔(座標)")]
    [SerializeField] private Vector3 Interval = new Vector3(0,0,1);   

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        // キャラクタ・位置が設定されていなければ終了
        if (SpawnCharacter == null || SpawnTrans == null) return;       
        
        // キャラクタ生成
        for (int i = 0; i < 10; i++)
        {            
            for (int j = 0; j < 10; j++)
            {
                Instantiate(SpawnCharacter, SpawnTrans.position + new Vector3(i*0.5f,0,j*0.5f), Quaternion.identity);
            }
        }
    }

    void Update()
    {

    }
}
