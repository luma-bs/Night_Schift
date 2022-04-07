using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPartObject : MonoBehaviour, IInteractableObject
{

    public GameObject missingPiecePrefab; //prefab da peça que vai ser roubada pelo cachorro
    public GameObject missingPiecePositionObj; //objeto na posição onde vai ficar a peça roubada pelo cachorro
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
        dogControl.AddToInventory(missingPiecePrefab);
        dogControl.GoToTarget(missingPiecePositionObj);
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
            PlayerFixObjects guardControl = guardObj.GetComponent<PlayerFixObjects>();
            if(guardControl.GetInventory() == missingPiecePrefab){
                isMessedUp = false;
                guardControl.CleanInventory();
                gameObject.GetComponent<Animator>().SetBool("isMessedUp", false);
            } else {   
                guardControl.ShowMissingText();
            }
        }
    }
}
