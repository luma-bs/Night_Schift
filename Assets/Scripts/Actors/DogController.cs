using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    private Animator animator;
    private GameObject inventory; //prefab do item que o cachorro esteja levando
    private GameObject inventoryItemInstance; //instancia do item do invent�rio

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
        //timerScript = GameObject.Find("Timer").GetComponent<Timer>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange(GameObject.FindGameObjectsWithTag("MuseumPiece"));

        navMeshAgent.speed = speed;
        navMeshAgent.acceleration = 5f;

        nextTarget = NewRandomTarget();
        navMeshAgent.destination = nextTarget.transform.position;
    }

    private GameObject NewRandomTarget()
    {
        if (nextTargetSet != null)
        {
            GameObject temp = nextTargetSet;
            nextTargetSet = null;
            return temp;
        }
        else
        {
            if (pointsOfInterest.Count >= 1)
            {
                return pointsOfInterest[Random.Range(0, pointsOfInterest.Count - 1)];
            }
            else
            {
                GameObject originalPositionObj = new GameObject("DogOriginalPosition");
                originalPositionObj.transform.position = originalPosition;
                return originalPositionObj;
            }
        }
    }

    public void SetNextTarget(GameObject newNextTarget)
    {
        nextTargetSet = newNextTarget;
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject == nextTarget)
        {
            pointsOfInterest.Remove(nextTarget);
            nextTarget.SendMessage("MessUp");
            StartCoroutine("DogInteraction");
        }
    }

    public IEnumerator DogInteraction(){
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("isMessing");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.ResetTrigger("isMessing");
        GoToRandomTarget();
    }

    public void StopMovement()
    {
        navMeshAgent.enabled = false;
    }

    public void GoToRandomTarget()
    {
        navMeshAgent.enabled = true;
        nextTarget = NewRandomTarget();
        navMeshAgent.SetDestination(nextTarget.transform.position);
    }

    public void GoToTarget(GameObject newDestination)
    {
        SetNextTarget(newDestination);
        GoToRandomTarget(); //gambiarra, mas funciona
    }

    /*ublic void AddToInventory(GameObject newItem)
    {
        inventory = newItem;
        RenderInventory();
    }

    public void CleanInventory()
    {
        inventory = null;
        DestroyInventoryRender();
    }

    public GameObject GetInventory()
    {
        return inventory;
    }

    private void RenderInventory()
    {
        inventoryItemInstance = Instantiate(inventory, this.gameObject.transform);
    }

    private void DestroyInventoryRender()
    {
        Destroy(inventoryItemInstance);
        inventoryItemInstance = null;
    }*/

}