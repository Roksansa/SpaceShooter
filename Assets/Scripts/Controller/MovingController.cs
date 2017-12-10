using Interface;
using UnityEngine;

namespace Controller{
  public class MovingController : MonoBehaviour{
    [SerializeField] private MonoBehaviour iMovingObject;
    [SerializeField] private MonoBehaviour inputControllerObject;
    private IMovable iMoving;
    private IInputController inputController;

    private void Start() {
      iMoving = iMovingObject as IMovable;
      inputController = inputControllerObject as IInputController;
    }

    // Update is called once per frame
    private void FixedUpdate() {
      iMoving.Move(inputController.inputHorizontalVertical());
    }
  }
}