using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject bullet;
    List<GameObject> pool;

    [SerializeField] private Rigidbody2D rb;

    public int score = 0;

    [SerializeField] private TextMeshProUGUI scoreTxt;
    
    void Start()
    {
        CreatePool();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (Input.GetKeyDown(KeyCode.K))
        {
            SavePlayer();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayer();
        }
    }

    private void FixedUpdate()
    {
        Move(); 
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

    public void SavePlayer()
    {
        BinaryScoreSave.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = BinaryScoreSave.LoadPlayer();

        score = data.score;
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

    private void Move()
    {
        float _inputX = Input.GetAxis("Horizontal") / 2;
        float _inputY = Input.GetAxis("Vertical") / 2;
        rb.MovePosition(new Vector2(rb.position.x + _inputX, rb.position.y + _inputY));
    }

    public void ReturnToPool(GameObject _bullet)
    {
        _bullet.SetActive(false);
    }

    public void Callback_IncreaseScore(int points)
    {
        score += points;
        scoreTxt.text = score.ToString();
    }
}
