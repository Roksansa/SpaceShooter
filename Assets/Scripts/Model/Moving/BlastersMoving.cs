using Interface;
using Model.Entity;
using UnityEngine;

namespace Model.Moving{
  public class BlastersMoving : MonoBehaviour, IMovable{
    [SerializeField] private float speedMove = 5f;
    private Rigidbody rigidbodyCache;

    private void Awake() {
      rigidbodyCache = GetComponent<Rigidbody>();
      rigidbodyCache.velocity = transform.forward*speedMove;
    }

    private void Start() {
      if (GetComponent<Blasters>().Type == Pooling.Blaster.Enemies) {
        rigidbodyCache.velocity = -rigidbodyCache.velocity;
      }
    }

    public void Move(Vector2 input) { }
  }
}