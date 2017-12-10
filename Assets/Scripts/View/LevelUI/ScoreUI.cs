using UnityEngine;
using UnityEngine.UI;

namespace View.LevelUI{
  public class ScoreUI : MonoBehaviour{
    private string score = "Score: ";
    private Text uiText;

    private void Awake() {
      uiText = GetComponent<Text>();
    }
    public void UpdateScore(int scoreKilled) {
      uiText.text = string.Concat(score, scoreKilled.ToString());
    }
  }
}