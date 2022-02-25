using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMesh : MonoBehaviour
{

    public List<GameObject> pointsOfInterest; // Array of GameObjects to be the destinations for navMeshAgent

    private NavMeshAgent navMeshAgent;
    private GameObject nextTarget;
    private GameObject targetBuffer;

    private MuseumPieceBehaviour targetBufferScript;

    public void UpdateTarget()
    {
        int randomSelected = Random.Range(0,pointsOfInterest.Count-1);
        nextTarget = pointsOfInterest[randomSelected];
        //Debug.Log(randomSelected+1);
    }

    private void OnTriggerEnter(Collider piece)
    {
        if( GameObject.ReferenceEquals(piece.gameObject, nextTarget) )
        {
            targetBuffer = piece.gameObject;
            targetBufferScript = targetBuffer.GetComponent<MuseumPieceBehaviour>();
            targetBufferScript.touched = true;
        }
    }

    private void OnTriggerStay(Collider piece)
    {
        if( GameObject.ReferenceEquals(piece.gameObject, targetBuffer) )
        {
            targetBufferScript = targetBuffer.GetComponent<MuseumPieceBehaviour>();
            targetBufferScript.isTouching = true;
        }
    }

    private void OnTriggerExit(Collider piece)
    {
        if( GameObject.ReferenceEquals(piece.gameObject, targetBuffer) )
        {
            targetBufferScript = targetBuffer.GetComponent<MuseumPieceBehaviour>();
            targetBufferScript.touched = false;
            targetBufferScript.isTouching = false;

            // Remover objeto da lista de objetos do cachorro
            pointsOfInterest.Remove(targetBuffer);
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange(GameObject.FindGameObjectsWithTag("MuseumPiece"));

        UpdateTarget();
    }

    // Update is called once per frame
    private void Update()
    {
        navMeshAgent.destination = nextTarget.transform.position;
    }
}
