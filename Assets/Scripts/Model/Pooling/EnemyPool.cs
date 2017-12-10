using System.Collections.Generic;
using Controller;
using Interface;
using UnityEngine;

namespace Model.Pooling{
  public class EnemyPool{
    public static Transform ParentEnemyPool;
    private List<ISpawned> enemies;

    public EnemyPool() {
      Init();
    }

    public void Create() {
      if (enemies.Count != 0) {
        int rand = Random.Range(0, enemies.Count);
        ISpawned spawned = enemies[rand];
        enemies.RemoveAt(rand);
        spawned.Spawn();
        return;
      }
      GameObject gameObjectNew = MonoBehaviour.Instantiate(GameController.StaticObject.EnemyFactory.CreateEnemy());
      gameObjectNew.transform.SetParent(ParentEnemyPool);
      gameObjectNew.GetComponent<ISpawned>().Spawn();
    }

    /// <summary>
    /// Вернуть в пул использованный объект
    /// </summary>
    /// <param name="gameObject"></param>
    public void ReturnObject(GameObject returnGameObject) {
      ISpawned returnEnemy = returnGameObject.GetComponent<ISpawned>();
      enemies.Add(returnEnemy);
      returnGameObject.SetActive(false);
    }


    public void Init() {
      enemies = new List<ISpawned>();
    }
  }
}