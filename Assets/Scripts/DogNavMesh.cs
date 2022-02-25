using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMesh : MonoBehaviour
{

    public List<GameObject> pointsOfInterest; // Array of GameObjects to be the destinations for navMeshAgent


    private NavMeshAgent navMeshAgent;
    private int nextTarget;

    // Start is called before the first frame update
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange(GameObject.FindGameObjectsWithTag("MuseumPiece"));

        nextTarget = Random.Range(0, pointsOfInterest.Count-1);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            navMeshAgent.destination = pointsOfInterest[nextTarget].transform.position;
        }
    }
}
