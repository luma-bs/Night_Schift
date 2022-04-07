using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{

    private GameObject inventory; //prefab do item que o cachorro esteja levando
    private GameObject inventoryItemInstance; //instancia do item do inventário

    public List<GameObject> pointsOfInterest; // Array of GameObjects to be the destinations for navMeshAgent

    private NavMeshAgent navMeshAgent;
    private GameObject nextTargetSet;

    private Timer timerScript;

    private Vector3 originalPosition;

    private GameObject nextTarget;

    //private GameObject targetBuffer;
    //private MuseumPieceBehaviour targetBufferScript;
    private GameObject targetChild;

    private float speed = 7.5f;

    // Start is called before the first frame update
    private void Start()
    {
        originalPosition = gameObject.transform.position;
        timerScript = GameObject.Find("Timer").GetComponent<Timer>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange( GameObject.FindGameObjectsWithTag("MuseumPiece") );

        navMeshAgent.speed = speed;
        navMeshAgent.acceleration = 5f;

        nextTarget = NewRandomTarget();
        navMeshAgent.destination = nextTarget.transform.position;
    }

    private GameObject NewRandomTarget()
    {
        if(nextTargetSet != null){
            GameObject temp = nextTargetSet;
            nextTargetSet = null;
            return temp;
        }
        else{
            if(pointsOfInterest.Count >= 1){
                return pointsOfInterest[Random.Range(0,pointsOfInterest.Count-1)];
            } else {
                GameObject originalPositionObj = new GameObject("DogOriginalPosition");
                originalPositionObj.transform.position = originalPosition;
                return originalPositionObj;
            }
        }
    }

    public void SetNextTarget(GameObject newNextTarget){
        nextTargetSet = newNextTarget;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject == nextTarget){
            Debug.Log("ENTROU, PARE");
            StopMovement();
            pointsOfInterest.Remove(nextTarget);
            nextTarget.SendMessage("DogInteract", this.gameObject);
        }
    }

    public void StopMovement(){
        navMeshAgent.enabled = false;
    }

    public void GoToRandomTarget(){
        navMeshAgent.enabled = true;
        nextTarget = NewRandomTarget();
        navMeshAgent.SetDestination(nextTarget.transform.position);
    }

    public void GoToTarget(GameObject newDestination){
        SetNextTarget(newDestination);
        GoToRandomTarget(); //gambiarra, mas funciona
    }

    public void AddToInventory(GameObject newItem){
        inventory = newItem;
        RenderInventory();
    }

    public void CleanInventory(){
        inventory = null;
        DestroyInventoryRender();
    }

    public GameObject GetInventory(){
        return inventory;
    }

    private void RenderInventory(){
        inventoryItemInstance = Instantiate(inventory, this.gameObject.transform);
    }

    private void DestroyInventoryRender(){
        Destroy(inventoryItemInstance);
        inventoryItemInstance = null;
    }

}

