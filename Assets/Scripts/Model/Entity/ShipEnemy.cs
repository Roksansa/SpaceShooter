using Interface;
using UnityEngine;

namespace Model.Entity{
  public class ShipEnemy: MonoBehaviour,ISpawned{
    private Transform transformCache;
    private Ship ship;
    private void Awake() {
      ship = GetComponent<Ship>();
      transformCache = transform;
    }

    public void Spawn() {
      gameObject.SetActive(true);
      ship.Init();
      transformCache.position = new Vector3(Random.Range(-7,8), 0, 21);
    }
  }
}