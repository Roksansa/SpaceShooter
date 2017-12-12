using Controller;
using Interface;
using UniRx;
using UnityEngine;

namespace Model.Entity{
  /// <summary>
  ///  Класс Ship
  ///  сущность корабля. имплементирует интерфейс IHittable,
  ///  так как корабль может получать урон
  /// </summary>
  public sealed class Ship : MonoBehaviour, IHittable{
    [SerializeField] private int defaultHp = 3;

    public void Init() {
      Hp.Value = defaultHp;
    }

    private void Awake() {
      Hp = new ReactiveProperty<int>(defaultHp);
      IsDead = Hp.Select(x => Hp.Value <= 0).ToReactiveProperty();
    }

    public ReactiveProperty<int> Hp { get; private set; }
    public ReactiveProperty<bool> IsDead { get; private set; }

    public void ImpactDamage(int damage) {
      if (Hp.Value <= 0) {
        Hp.Value = 0;
        return;
      }
      Hp.Value = Hp.Value - damage;
    }
  }
}