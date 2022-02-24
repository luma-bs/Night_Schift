using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMesh : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;

    private GameObject[] poi; // Array of GameObjects to be the destinations for navMeshAgent
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        poi = GameObject.FindGameObjectsWithTag("MuseumPiece");
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            navMeshAgent.destination = movePositionTransform.position;
        }
    }
}
