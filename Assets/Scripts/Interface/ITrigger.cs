using UnityEngine;

namespace Interface{
  public interface ITrigger{
    void OnTriggerEnter(Collider other);
  }
}