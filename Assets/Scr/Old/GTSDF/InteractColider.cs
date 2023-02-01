using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AD1762_GTSDF
{

	public class InteractColider : MonoBehaviour
	{
		public CombatantController RefCombatantController;
		private void OnTriggerEnter(Collider Colided)
		{
			if (Colided.gameObject.GetComponent<Interface>() != null)
			{
				RefCombatantController.InteractSet(Colided.gameObject.GetComponent<Interface>());
			}
		}
		private void OnTriggerExit(Collider Colided)
		{
			if (Colided.gameObject.GetComponent<Interface>() != null)
			{
				RefCombatantController.InteractRemove(Colided.gameObject.GetComponent<Interface>());
			}
		}
	}

}