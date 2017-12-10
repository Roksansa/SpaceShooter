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
//      IsDead.ObserveEveryValueChanged(x => x.Value).Subscribe(xs => {
//        GameController.GameOver = xs;
//      }).AddTo(this);
//      HP // ReactiveProperty count
//        .ObserveEveryValueChanged(x => x.Value) // отслеживаем изменения в нем
//        .Subscribe(xs => { // подписываемся
//          ImpactDamage(xs); // вызываем метод отображения данных
//        }).AddTo(this);
//      IDisposable a = Observable.IntervalFrame(30).Subscribe(x => Debug.Log(x)).AddTo(this);
//      Observable.IntervalFrame(30).TakeUntilDisable(this)
//        .Subscribe(x => Debug.Log(x), () => Debug.Log("completed!"));
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