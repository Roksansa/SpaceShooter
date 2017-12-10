using Interface;
using UnityEngine;

namespace Model.Entity{
  public class Asteroid:MonoBehaviour, ISpawned{
    private Transform transformCache;

    private void Awake() {
      transformCache = transform;
    }

    public void Spawn() {
      gameObject.SetActive(true);
      transformCache.position = new Vector3(Random.Range(-7,8), 0, 21);
    }
  }
}