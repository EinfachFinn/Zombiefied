using UnityEngine.Events;
using UnityEngine;
using cowsins;

public class EventTriggerExample : Interactable
{
	public UnityEvent triggerEvent;

	public override void Interact()
	{
		// Trigger the UnityEvent
		triggerEvent.Invoke();
	}
}