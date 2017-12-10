using System;
using Controller;
using Helper;
using Interface;
using Model.Entity;
using UnityEngine;

namespace Model.Collision{
  public class ShipTrigger : MonoBehaviour, ITrigger{
    private Ship ship;

    private void Awake() {
      ship = GetComponent<Ship>();
    }

    public void OnTriggerEnter(Collider other) {
      var returnGameObject = other.gameObject;
      if (other.CompareTag(TagsHelper.EnemyTag)) {
        //магическое число 1.
        ship.ImpactDamage(1);
        GameController.StaticObject.EnemyPool.ReturnObject(returnGameObject);
        GameController.StaticObject.UpdateScore();
        return;
      }
      if (other.CompareTag(TagsHelper.BlasterTag)) {
        var blasters = other.GetComponent<Blasters>();
        if (blasters.Type == Pooling.Blaster.Players) return;
        ship.ImpactDamage(blasters.ImpactDamage);
        GameController.StaticObject.BlasterPool.ReturnObject(returnGameObject, blasters.Type);
      }
    }
  }
}