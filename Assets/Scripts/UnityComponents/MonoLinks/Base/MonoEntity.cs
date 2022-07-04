using Leopotam.Ecs;
using UnityEngine;


public class MonoEntity : MonoLinkBase
{
	private EcsEntity _entity;
        
	private MonoLinkBase[] _monoLinks;

	public MonoLink<T> Get<T>() where T: struct
	{
		foreach (MonoLinkBase link in _monoLinks)
		{
			if (link is MonoLink<T> monoLink)
			{
				return monoLink;
			}
		}

		return null;
	}
        
	public override void Make(ref EcsEntity entity)
	{
		_entity = entity;
            
		_monoLinks = GetComponents<MonoLinkBase>();
		foreach (MonoLinkBase monoLink in _monoLinks)
		{
			if (monoLink is MonoEntity)
			{
				continue;
			}
			monoLink.Make(ref entity);
		}

		entity.Get<GameObjectLink>() = new GameObjectLink {value = gameObject};
		//entity.Get<Position>() = new Position {value = transform.position};
		//entity.Get<Rotation>() = new Rotation { value = transform.rotation.eulerAngles};//А есть ли в позиции и повороте смысл?
	}
}
