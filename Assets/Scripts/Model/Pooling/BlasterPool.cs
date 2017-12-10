using System.Collections.Generic;
using Controller;
using Interface;
using UnityEngine;

namespace Model.Pooling{
  public class BlasterPool{
    public static Transform ParentBlasterPool;

    private Stack<ISpawnedBlasters> blastersPlayer;
    private Stack<ISpawnedBlasters> blastersEnemy;

    public BlasterPool() {
      Init();
    }

    public void Create(global::Blaster blaster) {
      if (blaster.Type == Blaster.Players) {
        CreateBlastersPlayer(blaster);
        return;
      }
      CreateBlastersEnemy(blaster);
    }

    public void ReturnObject(GameObject returnBlaster, Blaster type) {
      ISpawnedBlasters returnBlasters = returnBlaster.GetComponent<ISpawnedBlasters>();
      if (type == Blaster.Players) {
        blastersPlayer.Push(returnBlasters);
      }
      if (type == Blaster.Enemies) {
        blastersEnemy.Push(returnBlasters);
      }
      returnBlaster.SetActive(false);
    }

    private void CreateBlastersPlayer(global::Blaster blasterParent) {
      if (blastersPlayer.Count != 0) {
        ISpawnedBlasters blaster = blastersPlayer.Pop();
        blaster.Spawn(blasterParent);
        return;
      }
      GameObject gameObjectNew =
        MonoBehaviour.Instantiate(GameController.StaticObject.BlasterFactory.CreateBlaster(Blaster.Players));
      gameObjectNew.transform.SetParent(ParentBlasterPool);
      gameObjectNew.GetComponent<ISpawnedBlasters>().Spawn(blasterParent);
    }

    private void CreateBlastersEnemy(global::Blaster blasterParent) {
      if (blastersEnemy.Count != 0) {
        ISpawnedBlasters blaster = blastersEnemy.Pop();
        blaster.Spawn(blasterParent);
        return;
      }
      GameObject gameObjectNew =
        MonoBehaviour.Instantiate(GameController.StaticObject.BlasterFactory.CreateBlaster(Blaster.Enemies));
      gameObjectNew.transform.SetParent(ParentBlasterPool);
      gameObjectNew.GetComponent<ISpawnedBlasters>().Spawn(blasterParent);
    }


    public void Init() {
      blastersPlayer = new Stack<ISpawnedBlasters>();
      blastersEnemy = new Stack<ISpawnedBlasters>();
    }
  }
}