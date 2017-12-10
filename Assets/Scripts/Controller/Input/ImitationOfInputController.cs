using Interface;
using UnityEngine;

namespace Controller.Input{
  public sealed class ImitationOfInputController : MonoBehaviour, IInputController{
    /// <summary>
    /// Имитация движения для астероидов
    /// Направление строго вниз
    /// </summary>
    /// <returns></returns>
    public Vector2 inputHorizontalVertical() {
      //так как движение должно всегда проиходить вниз, то 
      //движение вправо или влево будет  ~в два раза короче (если будет вообще)
      return new Vector2(Random.Range(-5,6),Random.Range(-10,-4));
    }

    public bool GetKeyDown() {
      return true;
    }
  }
}