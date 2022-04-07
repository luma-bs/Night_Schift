using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumPieceBehaviour : MonoBehaviour
{

    public bool isTake; //define se esta peça do museu é pro cachorro tirar um pedaço e levar pra outro lugar
    public GameObject takePosition; //no caso de ser um objeto que o cachorro leva um pedaço, define a posição onde esse pedaço deve ser colocado
    public GameObject takePrefab; //o prefab do pedaço a ser retirado

    private MeshRenderer thisRenderer;

    //private int thisIndex;

    private Transform _transform;
    private GameObject _gameObject; // Serve para referenciar a instância do objeto que contém este script

    private bool isTouched;

    private Material untouchedMaterial;
    private Material touchedMaterial;
    private Material thisMaterial;

    private bool timerStarted = false;
    public float timeRemaining = 0;

    void MessObject(GameObject dogObject)
    {
        StartCoroutine("WaitForMessAnimation", dogObject);

    }

    public IEnumerator WaitForMessAnimation(GameObject dogObject){

        yield return new WaitForSeconds(3);

        thisRenderer.material = touchedMaterial;
        isTouched = true;
        if(!isTake){
            dogObject.SendMessage("ResumeMovement");
        } else {
            GameObject newObj = Instantiate(takePrefab, dogObject.transform);
            newObj.name = takePrefab.name;
            gameObject.GetComponent<Animator>().SetBool("isRuined", true);
            dogObject.SendMessage("GoTo", takePosition);
        }

    }

    void FixObject(GameObject guardObj)
    {
        /*if(!isTake){
            thisRenderer.material = untouchedMaterial;
            isTouched = false;
            guardObj.SendMessage("FixSuccessful");
        } else {
            PlayerFixObjects guardScript = guardObj.GetComponent<PlayerFixObjects>();
            //GameObject guardInventory = guardScript.GetObjectInHand();
            if(guardInventory && guardInventory.name == takePrefab.name){
                //guardScript.LeaveObject();
                Destroy(guardInventory);
                thisRenderer.material = untouchedMaterial;
                isTouched = false;
                gameObject.GetComponent<Animator>().SetBool("isRuined", false);
                guardObj.SendMessage("FixSuccessful");
            } else {
                guardObj.SendMessage("FixNotSuccessful");
            }
        }*/
    }

    public bool getIsTouched(){
        return isTouched;
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _gameObject = _transform.gameObject;

        thisRenderer = GetComponent<MeshRenderer>();

        untouchedMaterial = Resources.Load<Material>("Materials/Object-True");
        touchedMaterial = Resources.Load<Material>("Materials/Object-False");

        // Só pra ter certeza de que o material está correto ao inicializar o jogo
        thisRenderer.material = untouchedMaterial;
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( timerStarted )
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerStarted = false;
                
                thisRenderer.material = untouchedMaterial;
            }
        }
    }
        
}
