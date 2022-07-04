using Leopotam.Ecs;
using UnityEngine;


public class OnTriggerEnterMonoLink : PhysicsLinkBase
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		_entity.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent()
		{
			Collider = other,
			Sender = gameObject
		};
	}
}
