using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMesh : MonoBehaviour
{

    public List<GameObject> pointsOfInterest; // Array of GameObjects to be the destinations for navMeshAgent

    private NavMeshAgent navMeshAgent;
    private GameObject nextTarget;

    //private GameObject targetBuffer;
    //private MuseumPieceBehaviour targetBufferScript;
    private GameObject targetChild;

    public void UpdateTarget()
    {
        int randomSelected = Random.Range(0,pointsOfInterest.Count-1);
        nextTarget = pointsOfInterest[randomSelected];

        //targetBuffer = nextTarget;
        //targetBufferScript = targetBuffer.GetComponent<MuseumPieceBehaviour>();

        // O cachorro se dirige a uma posição fixa perto da peça do museu
        targetChild = nextTarget.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange( GameObject.FindGameObjectsWithTag("MuseumPiece") );

        UpdateTarget();
    }

    // Update is called once per frame
    private void Update()
    {
        navMeshAgent.destination = targetChild.transform.position;

        if ( transform.position.x == navMeshAgent.destination.x &&
             transform.position.z == navMeshAgent.destination.z    )
        {
            nextTarget.SendMessage("StartTimer");
            pointsOfInterest.Remove(nextTarget);

            UpdateTarget();
        }
    }
}
