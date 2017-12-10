using UniRx;

namespace Interface{
  /// <summary>
  /// Интерфейс IHittable
  ///Сущности, которые могут получать урон должны имплементирвать
  ///этот интерфейс
  /// </summary>
  public interface IHittable{
    //Свойства здоровья, смерти
    ReactiveProperty<int> Hp { get; }

    ReactiveProperty<bool> IsDead { get; }

    /// <summary>
    /// Получить урон
    /// </summary>
    /// <param name="damage"> Количество получаемого урона</param>
    void ImpactDamage(int damage);
  }
}