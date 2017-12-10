using Interface;
using UnityEngine;

namespace Controller{
  public class FireController : MonoBehaviour{
    [SerializeField] private MonoBehaviour iBlasterObject;

    private IBlaster iBlaster;

    //для объектов не от монобехавиэр
    [SerializeField] private MonoBehaviour inputControllerObject;

    private IInputController inputController;

    private void Start() {
      iBlaster = iBlasterObject as IBlaster;
      inputController = inputControllerObject as IInputController;
    }

    // Update is called once per frame
    private void Update() {
      if (inputController.GetKeyDown()) {
        iBlaster.Fire();
      }
    }
  }
}