using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Model.Settings{
  public class SaveData{
    private const int DefaultLevels = 3;
    private const int DefaultEnemy = 5;
    private const int DefaultEnemyship = 2;
    private static readonly string DefaultDirectory = Application.persistentDataPath;

    public int EnemyCount() {
      return DefaultEnemy;
    }

    public int EnemyShipCount() {
      return DefaultEnemyship;
    }
    // We initialize all of the stats to be default values.
    private List<LevelSettings> levelsSettings;

    private readonly string filename = Path.Combine(DefaultDirectory, "Settings");

    public SaveData() { }

    public void SaveGameState() {
      Dictionary<string, object>
        gamestate = new Dictionary<string, object>(); //Словарь, который будет подвергнут сериализации.
      //записали
      gamestate.Add("LevelsSettings", levelsSettings);
      FileStream stream = File.Create(filename); // Создаем файл по указанному адресу.
      BinaryFormatter formatter = new BinaryFormatter();
      //сериализовали
      formatter.Serialize(stream, gamestate);
      stream.Close();
    }

    public void LoadGameState() {
      if (!File.Exists(filename)) { // Переход к загрузке только при наличии файла.
        //создаем новый
        levelsSettings = new List<LevelSettings>();
        for (int i = 0; i < DefaultLevels; i++) {
          LevelComplete complete = LevelComplete.opened;
          if (i > 0) {
            complete = LevelComplete.closed;
          }
          levelsSettings.Add(new LevelSettings(i, Random.Range(1, 4)*10,
            Random.Range(1, DefaultEnemy + 1), Random.Range(1, DefaultEnemyship + 1), complete));
        }
        SaveGameState();
        return;
      }
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = File.Open(filename, FileMode.Open);
      //вытянули
      var gamestate = formatter.Deserialize(stream) as Dictionary<string, object>;
      stream.Close();
      levelsSettings = (List<LevelSettings>) gamestate["LevelsSettings"];
    }

    public LevelSettings LevelSettings(int level) {
      if (levelsSettings.Count > level) {
        return levelsSettings[level];
      }
      return null;
    }

    public void UpdateNextLevel(int level) {
      if (levelsSettings.Count > level) {
        levelsSettings[level].UpdateStateLevel();
      }
      SaveGameState();
    }
  }
}