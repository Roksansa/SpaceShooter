using Controller;
using Helper;
using Interface;
using Model.Entity;
using UnityEngine;

namespace Model.Collision{
	public class BlasterTrigger : MonoBehaviour, ITrigger {
		public void OnTriggerEnter(Collider other) {
			if (other.CompareTag(TagsHelper.BlockTriggerTag)) {
				GameController.StaticObject.BlasterPool.ReturnObject(gameObject, gameObject.GetComponent<Blasters>().Type);
			}
		}
	}
}
