using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNavMesh : MonoBehaviour
{

    public List<GameObject> pointsOfInterest; // Array of GameObjects to be the destinations for navMeshAgent

    private NavMeshAgent navMeshAgent;
    private GameObject nextTarget;

    private Timer timerScript;

    //private GameObject targetBuffer;
    //private MuseumPieceBehaviour targetBufferScript;
    private GameObject targetChild;

    public void UpdateTarget()
    {
        int randomSelected = Random.Range(0,pointsOfInterest.Count-1);
        nextTarget = pointsOfInterest[randomSelected];

        //targetBuffer = nextTarget;
        //targetBufferScript = targetBuffer.GetComponent<MuseumPieceBehaviour>();

        // O cachorro se dirige a uma posi��o fixa perto da pe�a do museu
        targetChild = nextTarget.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        timerScript = GameObject.Find("Timer").GetComponent<Timer>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange( GameObject.FindGameObjectsWithTag("MuseumPiece") );

        navMeshAgent.speed = 7.5f;
        navMeshAgent.acceleration = 5f;

        UpdateTarget();
    }

    // Update is called once per frame
    private void Update()
    {

        if(pointsOfInterest.Count >= 1){
            if ( !timerScript.timesUp ) navMeshAgent.destination = targetChild.transform.position;

            if ( transform.position.x == navMeshAgent.destination.x &&
                transform.position.z == navMeshAgent.destination.z    )
            {
                nextTarget.SendMessage("MessObject");
                pointsOfInterest.Remove(nextTarget);

                UpdateTarget();
            }
        }
    }
}
