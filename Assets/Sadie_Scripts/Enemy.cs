using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    #region Variables 

    public string Ship { get; set; }
    public int Points { get; set; }
    public int Speed { get; set; }
    public float Scale { get; set; } = 1f;
    public Color Color { get; set; } = Color.white;

    #endregion


    public void ShowTest()
    {
        Debug.Log("Ship: {Ship}, Points: {Points}, Size: {Size}, Speed: {Speed} ");
    }
}
