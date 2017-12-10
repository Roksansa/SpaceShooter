using UnityEngine;

namespace Interface{
    public interface ICollider{
        void OnCollisionEnter(Collision other);
    }
}
