using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // スポーン座標
    [SerializeField]
    Transform[] spawn_position = new Transform[3];
    private enum DIRECTION { RIGHT, CENTER, LEFT, LENGTH };

    // スポーンオブジェクト
    [SerializeField]
    GameObject[] building_nomal = null;
    [SerializeField]
    GameObject[] building_special = null;
    private enum TYPE { NORMAL, SPECIAL, LENGTH };

    // 生成間隔
    private const float spawnTime = 10.0f;

    void Start()
    {
        StartCoroutine("Spawn");
    }
    
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            if (GameManager.State == GameManager.Play)
            {
                switch (Random.Range(0, (int)TYPE.LENGTH))
                {
                    case (int)TYPE.NORMAL:
                        Instantiate(building_nomal[Random.Range(0, building_nomal.Length)], spawn_position[Random.Range(0, (int)DIRECTION.LENGTH)].position, Quaternion.identity);
                        break;

                    case (int)TYPE.SPECIAL:
                        Instantiate(building_special[Random.Range(0, building_special.Length)], spawn_position[(int)DIRECTION.CENTER].position, Quaternion.identity);
                        break;
                }
            }

        }
    }
}
