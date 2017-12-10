using UnityEngine;

namespace Interface{
  public interface IInputController{
    /// <summary>
    /// Возвращаем вектор (значения от 0 до 1)
    /// </summary>
    /// <returns></returns>
    Vector2 inputHorizontalVertical();

    bool GetKeyDown();
  }
}