using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBowl : MonoBehaviour, IInteractableObject
{
    public bool isMessedUp{get;set;}

    private bool isEmpty = true;

    private DogController dogController;

    void Start(){
        dogController = GameObject.Find("Dog").GetComponent<DogController>(); //gambiarra pra poder chamar o cachorro quando o prato estiver cheio
    }

    public void DogInteract(GameObject dogObj){
        StartCoroutine("DogInteraction", dogObj);
    }

    IEnumerator DogInteraction(GameObject dogObj){
        Animator anim = gameObject.GetComponent<Animator>();

        DogController dogControl = dogObj.GetComponent<DogController>();

        gameObject.GetComponent<Animator>().SetBool("isEmpty", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        isEmpty = true;
        dogControl.GoToRandomTarget();
    }

    public void GuardApproach(GameObject guardObj){
        if(isEmpty){
            guardObj.GetComponent<PlayerFixObjects>().ShowCustomText("Pressione E para encher de ração");
        }
    }
    public void GuardInteract(GameObject guardObj){
        Debug.Log("AAAAA");
        if(isEmpty){
            isEmpty = false;
            gameObject.GetComponent<Animator>().SetBool("isEmpty", false);
            dogController.SetNextTarget(this.gameObject);
        }
    }
}

