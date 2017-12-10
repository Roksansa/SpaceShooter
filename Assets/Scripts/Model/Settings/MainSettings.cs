using UnityEngine;

namespace Model.Settings{
  public class MainSettings : MonoBehaviour{
    private static MainSettings _instance = null;

    public SaveData SaveData;
    public int CurLevel = 1;
    
    public static MainSettings Instance {
      get {
        if (_instance == null) {
          _instance = FindObjectOfType<MainSettings>();
          if (_instance == null) {
            GameObject go = new GameObject(typeof(MainSettings).ToString());
            _instance = go.AddComponent<MainSettings>();
          }
        }
        return _instance;
      }
    }

    private void Awake() {
      if (Instance != this) {
        Destroy(this);
      }
      else {
        SaveData = new SaveData();
        SaveData.LoadGameState();
        DontDestroyOnLoad(gameObject);
      }
    }

    public LevelSettings LevelSettings() {
      return SaveData.LevelSettings(CurLevel-1);
    }

    public void UpdateNextLevel() {
      SaveData.UpdateNextLevel(CurLevel);
    }

    public SaveData GetData() {
      return SaveData;
    }
  }
}