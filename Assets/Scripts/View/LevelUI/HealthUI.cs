using UnityEngine;
using UnityEngine.UI;

namespace View.LevelUI{
  public sealed class HealthUI : MonoBehaviour{
    private Sprite[] healthTexture2D;
    private Image healthImage;

    private void Awake() {
      healthTexture2D = Resources.LoadAll<Sprite>("Sprites/HeartSprite");
      healthImage = GetComponent<Image>();
    }

    public void UpdateHealth(int i) {
      healthImage.sprite = healthTexture2D[i];
    }
  }
}