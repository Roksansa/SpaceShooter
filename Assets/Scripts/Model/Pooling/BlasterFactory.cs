using UnityEngine;

namespace Model.Pooling{
  public enum Blaster{
    Players = 0,
    Enemies = 1
  }

  public class BlasterFactory{
    //имена в папке resources/prefabs
    public const string name0 = "Prefabs/BlastersPlayer";
    public const string name1 = "Prefabs/BlastersEnemy";

    public BlasterFactory() {
      prefabsBlasters = new[]
        {Resources.Load(name0) as GameObject, Resources.Load(name1) as GameObject};
    }

    private GameObject[] prefabsBlasters;

    public GameObject CreateBlaster(Blaster blaster) {
      return prefabsBlasters[(int) blaster];
    }
  }
}