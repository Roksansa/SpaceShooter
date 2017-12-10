using System.Collections.Generic;

namespace Model.Settings{
  [System.Serializable]
  public enum LevelComplete{
    closed,
    opened,
    completed
  }

  [System.Serializable]
  public class LevelSettings{
    private LevelComplete curLevelComplete;
    private int namelvl;
    private int specifiedTime;
    private int enemy;
    private int enemyShip;

    private Dictionary<int, bool> enemyPrefabs;

    public Dictionary<int, bool> EnemyPrefabs {
      get { return enemyPrefabs; }
    }

    public Dictionary<int, bool> EnemyShipPrefab {
      get { return enemyShipPrefab; }
    }

    private Dictionary<int, bool> enemyShipPrefab;

    public LevelComplete CurLevelComplete {
      get { return curLevelComplete; }
      set { curLevelComplete = value; }
    }

    public int Namelvl {
      get { return namelvl; }
      set { namelvl = value; }
    }

    public int SpecifiedTime {
      get { return specifiedTime; }
      set { specifiedTime = value; }
    }

    public int Enemy {
      get { return enemy; }
      set { enemy = value; }
    }

    public int EnemyShip {
      get { return enemyShip; }
      set { enemyShip = value; }
    }


    public LevelSettings() {
      MainSettings.Instance.SaveData.LoadGameState();
    }

    public LevelSettings(int namelvl, int specifiedTime, int enemy, int enemyShip, LevelComplete levelComplete) {
      this.namelvl = namelvl;
      this.specifiedTime = specifiedTime;
      this.enemy = enemy;
      this.enemyShip = enemyShip;
      curLevelComplete = levelComplete;
    }

    public void Init(Dictionary<int, bool> enemy, Dictionary<int, bool> enemyShip) {
      enemyPrefabs = enemy;
      enemyShipPrefab = enemyShip;
    }

    public void UpdateStateLevel() {
      if (CurLevelComplete == LevelComplete.closed) {
        CurLevelComplete = LevelComplete.opened;
      }
    }
  }
}