using System.Collections.Generic;
using UnityEngine;

public class ShotPool : MonoBehaviour
{
    public static ShotPool Instance;

    public GameObject shotPrefab;
    public int poolSize = 10;

    private Queue<Shot> pool = new Queue<Shot>();

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            var go = Instantiate(shotPrefab);
            go.SetActive(false);
            pool.Enqueue(go.GetComponent<Shot>());
        }
    }

    public Shot GetShot()
    {
        if (pool.Count > 0)
        {
            Shot shot = pool.Dequeue();
            shot.gameObject.SetActive(true);
            return shot;
        }
        else
        {
            var go = Instantiate(shotPrefab);
            return go.GetComponent<Shot>();
        }
    }

    public void ReturnShot(Shot shot)
    {
        shot.gameObject.SetActive(false);
        pool.Enqueue(shot);
    }
}
