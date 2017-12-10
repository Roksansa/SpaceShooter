namespace Interface{
  /** Интерефейс IUpdatable, который должны имплементировать все MonoBehaviour,
  *которые вносят изменения каждый кадр
  */
  public interface IUpdatable{
    void UpdateNow(float time);
  }
}