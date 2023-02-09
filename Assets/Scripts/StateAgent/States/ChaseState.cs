using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Resume();
    }

    public override void OnExit()
    {
        Debug.Log("Enter");
    }

    public override void OnUpdate()
    {
		if (owner.perceived.Length == 0)
		{
			owner.stateMachine.StartState(nameof(IdleState));
		}
		else
		{
			// move towards the perceived object position 
			owner.movement.MoveTowards(owner.perceived[0].transform.position);

			// create a direction vector toward the perceieved object from the owner
			//< compute direction vector towards perceived object position – owner position>
			Vector3 direction = owner.perception.transform.position - owner.transform.position;
			// get the distance to the perceived object 
			//< get the distance using the distance magnitude >;
			float distance = direction.magnitude;
			// get the angle between the owner forward vector and the direction vector 
			float angle = Vector3.Angle(owner.transform.forward, direction);
			// if within range and angle, attack 
			if (distance < 1.5 && angle < 20)
			{
				owner.stateMachine.StartState(nameof(AttackState));
			}
		}
	}
}
