using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Text;

public class TransformerSave : MonoBehaviour, ISaveable
{
    Data enemyData = new Data();
    private static string locationsPath;
    [SerializeField] private EnemySpawner spawner;

    private void Start()
    {
        locationsPath = Application.persistentDataPath + "\\LocationData.txt";
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        //Find all enemies, pass to get positions
        EnemyBehavior[] enemies = GameObject.FindObjectsOfType<EnemyBehavior>();
        enemyData.GetAllEnemiesPos(enemies);


        string json = JsonUtility.ToJson(enemyData, true);
        File.WriteAllText(locationsPath, json);
    }

    public void LoadGame() 
    {
        string json = File.ReadAllText(locationsPath);
        enemyData = JsonUtility.FromJson<Data>(json);

        //Delete any enemies in the scene already
        EnemyBehavior[] _currentEnemies = FindObjectsByType<EnemyBehavior>(FindObjectsSortMode.None);
        for(int i = 0; i < _currentEnemies.Length; i++)
        {
            Destroy(_currentEnemies[i].gameObject);
        }
        
        //Load in enemies from the file
        for(int i = 0; i < enemyData.enemyPositions.Count; i++)
        {
            //Create an enemy with saved data
            GameObject _e = spawner.SpawnEnemy();
            //Move enemy to saved position
            _e.transform.position = enemyData.enemyPositions[i];
            Debug.Log(_e.transform.position);
        }
        
    }

}

[System.Serializable]
public class Data
{
    public List<Enemy> enemyData = new List<Enemy>();
    /*public int speed;
    public float scale;
    public Color sColor;*/
    public List<Vector2> enemyPositions = new List<Vector2>();

    public void GetAllEnemiesPos(EnemyBehavior[] _enemyPos)
    {
        for(int i = 0; i < _enemyPos.Length; i++)
        {
            enemyPositions.Add(_enemyPos[i].transform.position);
/*            enemyData.Add(_enemyPos[i].GetData());
            speed = enemyData[i].Speed;
            scale = enemyData[i].Scale;
            sColor = enemyData[i].Color;*/
        }
    }
}





