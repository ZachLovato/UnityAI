using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class AttackState : State
{
	private float timer;

	public AttackState(StateAgent owner) : base(owner)
	{
	}

	public override void OnEnter()
	{
		owner.navigation.targetNode = null;
		owner.movement.Stop();
		

		AnimationClip[] clips = owner.animator.runtimeAnimatorController.animationClips;

		AnimationClip clip = clips.FirstOrDefault<AnimationClip>(clip => clip.name == "Punch");
		
		timer = (clip != null) ? clip.length : 1;

		var colliders = Physics.OverlapSphere(owner.transform.position, 2);
		foreach (var collider in colliders)
		{
			if (collider.gameObject == owner || collider.gameObject.CompareTag(owner.gameObject.tag)) continue;

			if (collider.gameObject.TryGetComponent<StateAgent>(out var component))
			{
				
				if (component.health.value > 0)
				{
                    owner.animator.SetTrigger("Attack");
                    component.health.value -= Random.Range(10, 30);
                }
				else owner.stateMachine.StartState(nameof(IdleState));
			}
		}
	}

	public override void OnExit()
	{

	}

	public override void OnUpdate()
	{

	}
}
