using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{

    private Transform playerTransform;
    private NavMeshPath path;
    private GameObject cube;
    
    public bool IsPlayerAlive { get { return playerTransform != null; } }

    

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        playerTransform.GetComponent<PlayerDeath>().OnPlayerDeath += PlayerDied;
        GetComponent<Health>().OnDied += ZombieNavigation_OnDied;
        path = new NavMeshPath();
        //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.GetComponent<Collider>().enabled = false;
    }

    private void ZombieNavigation_OnDied()
    {
        this.enabled = false;
    }

    private void PlayerDied()
    {
        playerTransform = null;
    }

    private void Update()
    {
        if (playerTransform == null)
            return;
        var targetPosition = playerTransform.position;
        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        if(foundPath)
        {
            Vector3 nextDestination = path.corners[1];
          //  cube.transform.position = nextDestination;

            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirectionToTarget = new Vector3(directionToTarget.x, 0, directionToTarget.z);
             directionToTarget = Vector3.Normalize(flatDirectionToTarget);
            var desiredRotation = Quaternion.LookRotation(directionToTarget);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation,Time.deltaTime*2);
            transform.rotation = finalRotation;
        }
    }
}
