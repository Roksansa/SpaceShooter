using Interface;
using UnityEngine;

namespace Model.Entity{
  /// <summary>
  /// Это бластеры, которыми можно стрелять
  /// </summary>
  public class Blasters : MonoBehaviour, ISpawnedBlasters{
    private Transform transformCache;
    private Pooling.Blaster type;
    [SerializeField] private int impactDamage = 1;

    public int ImpactDamage {
      get { return impactDamage; }
    }

    private void Awake() {
      transformCache = transform;
    }

    public Pooling.Blaster Type {
      get { return type; }
    }

    public void Spawn(Blaster blaster) {
      gameObject.SetActive(true);
      transformCache.position = blaster.TransformCache.position;
      type = blaster.Type;
    }
  }
}