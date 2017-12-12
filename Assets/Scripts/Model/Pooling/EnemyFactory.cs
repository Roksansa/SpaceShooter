using System.Collections.Generic;
using System.Runtime.Serialization;
using Controller;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Pooling{
  public class EnemyFactory{
    //имена в папке resources/prefabs
    public const string name0 = "Prefabs/Enemy";

    public const string name1 = "Prefabs/EnemyShip";
    private GameObject[] prefabsEnemy;

    //стандартная подгрузка
    public EnemyFactory() { }

    /// <summary>
    /// Конструктор рандомный
    /// </summary>
    /// <param name="i">сколько видов астероидов</param>
    /// <param name="j">сколько вражеских кораблей</param>
    public EnemyFactory(int i, int i1, int j, int j1) {
      Dictionary<int, bool> enemy = new Dictionary<int, bool>();

      Dictionary<int, bool> enemyShip = new Dictionary<int, bool>();
      prefabsEnemy = new GameObject[i + j];
      if (prefabsEnemy.Length > 0) {
        int k = 0;
        while (k < i) {
          int random = Random.Range(0, i1);
          if (!enemy.ContainsKey(random)) {
            enemy.Add(random, true);
            prefabsEnemy[k++] = Resources.Load(name0 + random) as GameObject;
          }
        }
        int l = 0;
        while (l < j) {
          int random = Random.Range(0, j1);
          if (!enemyShip.ContainsKey(random)) {
            enemyShip.Add(random, true);
            prefabsEnemy[k++] = Resources.Load(name1 + random) as GameObject;
            l++;
          }
        }
      }
      GameController.StaticObject.SaveFactory(enemy, enemyShip);
    }

    public EnemyFactory(List<int> enemy, List<int> enemyShip) {
      prefabsEnemy = new GameObject[enemy.Count + enemyShip.Count];
      for (int i = 0; i < enemy.Count; i++) {
        prefabsEnemy[i] = Resources.Load(name0 + enemy[i]) as GameObject;
      }
      int k = enemy.Count;
      for (int i = 0; i < enemyShip.Count; i++) {
        prefabsEnemy[k++] = Resources.Load(name1 + enemyShip[i]) as GameObject;
      }
    }


    public GameObject CreateEnemy() {
      int random = Random.Range(0, prefabsEnemy.Length);
      //появление более сильного противника 1/4
      return prefabsEnemy[random];
    }
  }
}