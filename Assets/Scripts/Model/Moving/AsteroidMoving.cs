using Interface;
using UnityEngine;

namespace Model.Moving{
  /// <summary>
  /// Класс AsteroidMoving 
  /// получает событие обновления,
  /// отвечает за движение астероида
  /// </summary>
  public sealed class AsteroidMoving : MonoBehaviour, IMovable{
    [SerializeField] private float speedMove = 5f;
    private Rigidbody rigidbodyCache;
    private Vector3 torque;

    /// <summary>
    /// Так как управлять им не надо, достаточно просто задать направление
    /// </summary>
    private void Awake() {
      rigidbodyCache = GetComponent<Rigidbody>();
      torque = new Vector3(Random.Range(1, 4), Random.Range(1, 4), Random.Range(1, 4));
      Vector3 movement = new Vector3(0, 0, -1*speedMove);
      rigidbodyCache.velocity = movement;
      rigidbodyCache.angularVelocity = torque;
    }

    public void Move(Vector2 input) { }
  }
}