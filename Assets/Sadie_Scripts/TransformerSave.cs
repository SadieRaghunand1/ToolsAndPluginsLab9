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

        //Create an enemy with saved data
        GameObject _e = 

        //Move enemy to saved position
    }

}

[System.Serializable]
public class Data
{
    public List<Enemy> enemyData = new List<Enemy>();
    public int speed;
    public float scale;
    public Color sColor;
    public List<Vector2> enemyPositions = new List<Vector2>();

    public void GetAllEnemiesPos(EnemyBehavior[] _enemyPos)
    {
        for(int i = 0; i < _enemyPos.Length; i++)
        {
            enemyPositions.Add(_enemyPos[i].transform.position);
            enemyData.Add(_enemyPos[i].GetData());
            speed = enemyData[i].Speed;
            scale = enemyData[i].Scale;
            sColor = enemyData[i].Color;
        }
    }
}





