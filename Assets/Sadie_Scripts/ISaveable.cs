using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public interface ISaveable
{
    public void SaveGame();
    public void LoadGame();
}