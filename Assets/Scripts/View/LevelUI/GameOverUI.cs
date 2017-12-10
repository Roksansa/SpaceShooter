using UnityEngine;
using UnityEngine.UI;

namespace View.LevelUI{
  public class GameOverUI : MonoBehaviour{
    private Text infoText;
    private const string levelComplete = "Level Complete";
    private const string levelFailed = "Level Failed";
    private void Awake() {
      infoText = GetComponent<Text>();
      gameObject.SetActive(false);
    }

    public void GameOverShow(bool complete) {
      if (complete) {
        infoText.text = levelComplete;
      }
      else {
        infoText.text = levelFailed;
      }
      gameObject.SetActive(true);
    }
  }
}
