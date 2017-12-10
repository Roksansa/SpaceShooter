using Interface;
using UnityEngine;

namespace Model.Moving{
  public class ShipAIMoving : MonoBehaviour, IMovable{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float tilt = 45f;

    private Rigidbody rigidbodyCache;

    private int fixedFrameInterval = 0;
    private int curFrame = 0;

    [SerializeField] private SpaceArea spaceArea;

    // Use this for initialization
    private void Awake() {
      rigidbodyCache = GetComponent<Rigidbody>();
      fixedFrameInterval = (int) (1/Time.fixedDeltaTime);
      curFrame = fixedFrameInterval;
    }

    public void Move(Vector2 input) {
      //чтобы направление не менялось каждый кадр, сделаем задержку перед сменой
      //во фреймах (updateFixed)
      if (curFrame >= fixedFrameInterval) {
        curFrame = 0;
        fixedFrameInterval = Random.Range((int) (1/Time.fixedDeltaTime), (int) (2/Time.fixedDeltaTime));
        Vector3 movement = new Vector3(input.x*moveSpeed, 0.0f, input.y*moveSpeed);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        rigidbodyCache.velocity = movement;
        rigidbodyCache.rotation = Quaternion.Euler(0.0f, 180f, -(movement.x/moveSpeed)*tilt);
      }
      curFrame++;
      rigidbodyCache.position = new Vector3
      (
        Mathf.Clamp(rigidbodyCache.position.x, spaceArea.MinX, spaceArea.MaxX),
        0.0f,
        rigidbodyCache.position.z);
    }
  }
}