using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMesh : MonoBehaviour
{

    private GameObject[] poi; // Array of GameObjects to be the destinations for navMeshAgent
    private NavMeshAgent navMeshAgent;
    private int nextTarget;

    // Start is called before the first frame update
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        poi = GameObject.FindGameObjectsWithTag("MuseumPiece");

        nextTarget = Random.Range(0, poi.Length-1);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            navMeshAgent.destination = poi[nextTarget].transform.position;
        }
    }
}
