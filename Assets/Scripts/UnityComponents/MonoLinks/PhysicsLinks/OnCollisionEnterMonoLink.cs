using Leopotam.Ecs;
using UnityEngine;

public class OnCollisionEnterMonoLink : PhysicsLinkBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {		
		_entity.Get<OnCollisionEnterEvent>() = new OnCollisionEnterEvent
		{
			collision = collision,
			sender = gameObject
		};		
	}
}
