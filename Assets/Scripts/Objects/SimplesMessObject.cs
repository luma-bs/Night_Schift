using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplesMessObject : MonoBehaviour, IInteractableObject
{
    public bool isMessedUp{get;set;}


    public void DogInteract(GameObject dogObj){
        StartCoroutine("DogInteraction", dogObj);
    }

    IEnumerator DogInteraction(GameObject dogObj){
        Animator anim = gameObject.GetComponent<Animator>();

        DogController dogControl = dogObj.GetComponent<DogController>();

        gameObject.GetComponent<Animator>().SetBool("isMessedUp", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        isMessedUp = true;
        dogControl.GoToRandomTarget();
    }

    public void GuardApproach(GameObject guardObj){
        /*
        Se não foi mexido, nada
        Se foi mexido, bota "pressione E para interagir" na tela
        */
        if(isMessedUp){
            guardObj.GetComponent<PlayerFixObjects>().ShowFixText();
        }
    }
    public void GuardInteract(GameObject guardObj){
        /*
        Se o guarda não tem o pedaço faltando, bota "Algo está faltando..." na tela
        Se o guarda tem, animação e volta pro estado normal
        */
        if(isMessedUp){
            isMessedUp = false;
            gameObject.GetComponent<Animator>().SetBool("isMessedUp", false);
        }
    }
}
