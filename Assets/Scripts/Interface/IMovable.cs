using UnityEngine;

namespace Interface{
/** Интерефейс IMovable, который должны имплементировать все MonoBehaviour,
  *которые могут передвигаться
  */
  public interface IMovable{
    void Move(Vector2 input);
  }
}