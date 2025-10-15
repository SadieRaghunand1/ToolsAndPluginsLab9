using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject bullet;
    List<GameObject> pool;


    // Start is called before the first frame update
    void Start()
    {
        CreatePool();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void CreatePool()
    {
        pool = new List<GameObject>();  
        for(int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(bullet));
            pool[i].SetActive(false);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shoot");
            for(int i = 0; i < poolSize; i++)
            {
                if (pool[i].activeInHierarchy == false)
                {
                    pool[i].SetActive(true);
                    pool[i].transform.position = transform.position;
                    return;
                }
            }
        }
    }
}
