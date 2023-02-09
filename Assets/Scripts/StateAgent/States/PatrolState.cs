using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class PatrolState : State
{
	//private float timer;
    public PatrolState(StateAgent owner) : base(owner)
    {

    }

    public override void OnEnter()
    {
        owner.movement.Resume();
        owner.navigation.targetNode = owner.navigation.GetNearestNode();
		owner.timer.value = Random.Range(5, 10); 
    }

    public override void OnExit()
    {
        //Debug.Log("Enter");
    }

    public override void OnUpdate()
    {

	}
}
