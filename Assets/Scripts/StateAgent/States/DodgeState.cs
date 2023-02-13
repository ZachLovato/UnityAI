using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DodgeState : State
{
    public DodgeState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Resume();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (owner.enemySeen)
        {
            Vector3 direcction = (owner.transform.position - owner.perceived[0].transform.position).normalized;
            owner.movement.MoveTowards(owner.transform.position + direcction * 5);
        }
    }
}
