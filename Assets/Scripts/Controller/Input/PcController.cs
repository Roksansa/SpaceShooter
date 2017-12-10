using Interface;
using UnityEngine;

namespace Controller.Input{
  public sealed class PcController : MonoBehaviour, IInputController{
    public Vector2 inputHorizontalVertical() {
      float inputX = UnityEngine.Input.GetAxis("Horizontal");
      float inputZ = UnityEngine.Input.GetAxis("Vertical");
      return new Vector2(inputX,inputZ);
    }

    public bool GetKeyDown() {
      return UnityEngine.Input.GetKey(KeyCode.Mouse0);
    }
  }
}