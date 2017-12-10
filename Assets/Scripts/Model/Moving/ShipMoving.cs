using Interface;
using UnityEngine;

namespace Model.Moving{
  /// <summary>
  ///  Класс ShipMoving
  ///  подписывается на события обновления физики
  ///  вызывает свой метод move
  /// </summary>
  public sealed class ShipMoving : MonoBehaviour, IMovable{
    //скорость движения
    [SerializeField] private float moveSpeed = 5f;

    //наклон при движении вправо/влево (угол в градусах)
    [SerializeField] private float tilt = 20f;

    [SerializeField] private SpaceArea spaceArea;
    private Rigidbody rigidbodyCache;

    // Use this for initialization
    private void Awake() {
      rigidbodyCache = GetComponent<Rigidbody>();
      
    }

    public void Move(Vector2 input) {
      Vector3 movement = new Vector3(input.x*moveSpeed, 0.0f, input.y*moveSpeed);
//      Debug.Log(movement);
      movement = Vector3.ClampMagnitude(movement, moveSpeed);
      rigidbodyCache.velocity = movement;
      rigidbodyCache.position = new Vector3
      (
        Mathf.Clamp(rigidbodyCache.position.x, spaceArea.MinX, spaceArea.MaxX),
        0.0f,
        Mathf.Clamp(rigidbodyCache.position.z, spaceArea.MinZ, spaceArea.MaxZ)
      );
      rigidbodyCache.rotation = Quaternion.Euler(0.0f, 0.0f, -(movement.x/moveSpeed)*tilt);
//      Debug.Log(rigidbodyCache.rotation + "  " + movement);
    }
  }
}