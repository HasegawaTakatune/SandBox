using System.Collections;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{

    [SerializeField] private GameObject human;

    void Start()
    {
        StartCoroutine(Spwn());
    }

    private IEnumerator Spwn()
    {
        Vector3 pos = transform.position;

        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(human, pos, Quaternion.identity);
        }
    }
}
