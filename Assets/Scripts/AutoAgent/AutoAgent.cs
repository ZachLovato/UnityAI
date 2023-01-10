using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;

public class AutoAgent : Agent
{

    // Update is called once per frame
    void Update()
    {
        var gameObjects = perception.GetGameObjects();
        foreach (var gameObject in gameObjects) 
        {
            Debug.DrawLine(transform.position, gameObject.transform.position);

            //if (< game objects array contains at least one game object) 
            if (gameObjects.Length > 0) 
            {
                Vector3 direction = (gameObjects[0].transform.position - transform.position).normalized;

                movement.ApplyForce(direction * 2);
            }
        }

        transform.position = Utils.Wrap(transform.position, new Vector3(-10, -10, -10), new Vector3(10, 10, 10));
    }
}
