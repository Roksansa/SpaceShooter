using Model.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.MenuUI{
  public class LevelUI : MonoBehaviour{
    private Button levelButton;
    [SerializeField] private int level;

    public Button LevelButton {
      get { return levelButton; }
    }

    private void Awake() {
      levelButton = GetComponent<Button>();
      levelButton.onClick.AddListener(LevelChoiceOnClick);
      if (MainSettings.Instance.SaveData.LevelSettings(level - 1).CurLevelComplete == LevelComplete.closed) {
        levelButton.interactable = false;
        return;
      }
      if (MainSettings.Instance.SaveData.LevelSettings(level - 1).CurLevelComplete == LevelComplete.completed) {
        levelButton.image.sprite = Resources.Load<Sprite>("Sprites/Сheckmark");
      }
    }

    public void LevelChoiceOnClick() {
      MainSettings.Instance.CurLevel = level;
      SceneManager.LoadScene(1);
    }

    private void OnDestroy() {
      levelButton.onClick.RemoveListener(LevelChoiceOnClick);
    }
  }
}