using UnityEngine;

namespace Model{
  public sealed class BackgroundScroll : MonoBehaviour{
    [SerializeField] private float scrollSpeed = -5f;
    [SerializeField] private float tileSizeZ = 20;

    private Vector3 startPosition;
    private readonly Vector3 curForward = Vector3.forward;

    private void Start() {
      startPosition = transform.localPosition;
    }


    private void Update() {
      Scroll();
    }

    private void Scroll() {
      float newPosition = Mathf.Repeat(Time.time*scrollSpeed, tileSizeZ);
      transform.localPosition = startPosition + curForward*newPosition;
    }
  }
}