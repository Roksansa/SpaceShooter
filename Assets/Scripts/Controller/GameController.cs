using System.Collections;
using System.Collections.Generic;
using Model.Pooling;
using Model.Settings;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller{
  public class GameController : MonoBehaviour{
    public static GameController StaticObject;
    public EnemyPool EnemyPool;
    public EnemyFactory EnemyFactory;

    public BlasterPool BlasterPool;
    public BlasterFactory BlasterFactory;

    public readonly ReactiveProperty<bool> IsGameOver = new ReactiveProperty<bool>(false);
    public readonly ReactiveProperty<bool> LevelComplete = new ReactiveProperty<bool>(false);
    public readonly IntReactiveProperty ScoreKilled = new IntReactiveProperty(0);
    public readonly ReactiveProperty<float> SpecifiedTime = new ReactiveProperty<float>(10f);
    private LevelSettings levelSettings;

    private void Awake() {
      StaticObject = GetComponent<GameController>();
      //загружаем данные лвл
      InitData();
      //Инициализируем пулы
      InitPool();
      InitHandler();
      StartCoroutine(StartEnemyCreate());
      StartCoroutine(StartLevel());
    }

    private void InitPool() {
      if (levelSettings.EnemyPrefabs == null) {
        Debug.Log("i tut222");
        EnemyFactory = new EnemyFactory(levelSettings.Enemy,
          MainSettings.Instance.GetData().EnemyCount(),
          levelSettings.EnemyShip,
          MainSettings.Instance.GetData().EnemyShipCount());
      }
      else {
        Debug.Log("i tut111");
        EnemyFactory = new EnemyFactory(new List<int>(levelSettings.EnemyPrefabs.Keys),
          new List<int>(levelSettings.EnemyShipPrefab.Keys));
      }
      EnemyPool = new EnemyPool();
      EnemyPool.ParentEnemyPool = (Transform) GetComponentsInChildren<Transform>().GetValue(2);
      BlasterFactory = new BlasterFactory();
      BlasterPool = new BlasterPool();
      BlasterPool.ParentBlasterPool = (Transform) GetComponentsInChildren<Transform>().GetValue(1);
    }

    private void InitHandler() {
      SpecifiedTime.ObserveEveryValueChanged(x => x.Value)
        .Where(x => x <= 0)
        .Subscribe(x => {
          IsGameOver.Value = true;
          LevelComplete.Value = true;
        })
        .AddTo(gameObject);
      IsGameOver.ObserveEveryValueChanged(x => x.Value)
        .Where(x => x == true)
        .Subscribe(x => ReturnMainMenu())
        .AddTo(gameObject);
      LevelComplete.ObserveEveryValueChanged(x => x.Value)
        .Where(x => x == true)
        .Subscribe(x => {
          levelSettings.CurLevelComplete = Model.Settings.LevelComplete.completed;
          MainSettings.Instance.UpdateNextLevel();
        })
        .AddTo(gameObject);
    }

    private IEnumerator StartLevel() {
      float timeInterval = 0.1f;
      while (SpecifiedTime.Value > 0f && !IsGameOver.Value) {
        yield return new WaitForSeconds(timeInterval);
        SpecifiedTime.Value -= timeInterval;
      }
      if (SpecifiedTime.Value <= 0f) {
        SpecifiedTime.Value = 0.00f;
      }
    }

    private IEnumerator StartEnemyCreate() {
      Debug.Log(IsGameOver.Value + " 1111");
      while (!IsGameOver.Value) {
        EnemyPool.Create();
        yield return new WaitForSeconds(Random.Range(0.25f, 2.0f));
      }
    }

    public void UpdateScore() {
      ScoreKilled.Value++;
    }

    private void ReturnMainMenu() {
      StartCoroutine(DelayAndLoadScene());
    }

    private IEnumerator DelayAndLoadScene() {
      //постаиваем 3секунды (самый простой способ)
      yield return new WaitForSecondsRealtime(3f);
      SceneManager.LoadScene(0);
    }


    private void InitData() {
      Debug.Log("i tut");
      levelSettings = MainSettings.Instance.LevelSettings();
      SpecifiedTime.Value = levelSettings.SpecifiedTime;
    }

    public void SaveFactory(Dictionary<int, bool> enemy, Dictionary<int, bool> enemyShip) {
      levelSettings.Init(enemy, enemyShip);
      MainSettings.Instance.SaveData.SaveGameState();
    }
  }
}