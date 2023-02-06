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
        //Debug.Log("Enter");
        if (owner.perceived.Length == 0)
        {
            owner.stateMachine.StartState(nameof(PatrolState));
        }
        else
        {
            owner.movement.MoveTowards(owner.perceived[0].transform.position);
        }
    }
}
