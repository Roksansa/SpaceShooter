using Helper;
using Interface;
using UniRx;
using UnityEngine;
using View;
using View.LevelUI;

namespace Controller{
  public class UIController : MonoBehaviour{
    [SerializeField] private HealthUI healthUi;
    [SerializeField] private ScoreUI scoreUi;
    [SerializeField] private GameOverUI gameOverUi;
    [SerializeField] private TimerUI timerUi;
    private IHittable player;
    private GameObject playerPicture;

    private void Start() {
      playerPicture = GameObject.FindWithTag(TagsHelper.PlayerTag);
      player = playerPicture.GetComponent<IHittable>();
      
      player.Hp.ObserveEveryValueChanged(x => x.Value)
        .Subscribe(healthUi.UpdateHealth)
        .AddTo(healthUi.gameObject);
      GameController.StaticObject.ScoreKilled.ObserveEveryValueChanged(x => x.Value)
        .Subscribe(scoreUi.UpdateScore)
        .AddTo(scoreUi.gameObject);
      
      player.IsDead.ObserveEveryValueChanged(x => x.Value).Where(x => x == true)
        .Subscribe(x => GameController.StaticObject.IsGameOver.Value = true)
        .AddTo(GameController.StaticObject);
      
      GameController.StaticObject.IsGameOver.ObserveEveryValueChanged(x => x.Value)
        .Subscribe(xs => {
          if (xs) {
            gameOverUi.GameOverShow(GameController.StaticObject.LevelComplete.Value);
            playerPicture.SetActive(false);
          }
        })
        .AddTo(gameOverUi.gameObject);
      
      GameController.StaticObject.SpecifiedTime.ObserveEveryValueChanged(x => x.Value)
        .Subscribe(x => timerUi.UpdateTimer(x))
        .AddTo(timerUi.gameObject);
    }
  }
}