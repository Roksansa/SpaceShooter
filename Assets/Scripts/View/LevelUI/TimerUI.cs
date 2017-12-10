using UnityEngine;
using UnityEngine.UI;

namespace View.LevelUI{
  public class TimerUI:MonoBehaviour{
    private Text timerText;

    private void Awake() {
      timerText = GetComponent<Text>();
    }

    public void UpdateTimer(float time) {
      timerText.text = time.ToString("N2");
    }
  }
}