using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace AD1762
{
	public class EventCaller : MonoBehaviour
	{
		UnityEvent testEvent;
		public GameObject playerObject;
		private void Start()
		{
			if (testEvent == null)
			{
				testEvent = new UnityEvent();
			}
			testEvent.AddListener(Report);
		}
		private void Update()
		{
			if(Input.anyKeyDown)
			{
				testEvent.Invoke();
			}
		}
		void Report()
		{
			playerObject.transform.GetComponent<Rigidbody>().AddForce(new Vector3(10000, 0, 0));
			Debug.Log("Report");
		}
	}
}