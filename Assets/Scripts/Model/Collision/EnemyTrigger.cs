using Controller;
using Helper;
using Interface;
using Model.Entity;
using UnityEngine;

namespace Model.Collision{
  public class EnemyTrigger : MonoBehaviour, ITrigger{
//если не null. то значит это вражеский корабль который 
//тоже имеет опр кол-во жизней.
    private IHittable ship;

    private void Awake() {
      ship = GetComponent<IHittable>();
    }

    public void OnTriggerEnter(Collider other) {
      //обработка столкновения с игроком реализована у игрока
      if (other.CompareTag(TagsHelper.BlasterTag)) {
        var blasters = other.GetComponent<Blasters>();
        if (blasters.Type == Pooling.Blaster.Enemies) return;
        if (ship == null) {
          GameController.StaticObject.BlasterPool.ReturnObject(other.gameObject, blasters.Type);
          GameController.StaticObject.EnemyPool.ReturnObject(gameObject);
          GameController.StaticObject.UpdateScore();
          return;
        }
        GameController.StaticObject.BlasterPool.ReturnObject(other.gameObject, blasters.Type);
        ship.ImpactDamage(blasters.ImpactDamage);
        if (ship.IsDead.Value) {
          GameController.StaticObject.EnemyPool.ReturnObject(gameObject);
          GameController.StaticObject.UpdateScore();
        }
      }
      if (other.CompareTag(TagsHelper.BlockTriggerTag)) {
        GameController.StaticObject.EnemyPool.ReturnObject(gameObject);
      }
    }
  }
}