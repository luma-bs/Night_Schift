using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPartPositionObject : MonoBehaviour, IInteractableObject
{

    GameObject missingPiecePrefab;
    GameObject missingPieceInstance;
    public bool isMessedUp {get;set;}

    public void DogInteract(GameObject dogObj){
        DogController dogControl = dogObj.GetComponent<DogController>();
        missingPiecePrefab = dogControl.GetInventory();
        dogControl.CleanInventory();
        dogControl.GoToRandomTarget();
        RenderMissingPiece();
        isMessedUp = true;
    }

    public void GuardApproach(GameObject guardObj){
        if(isMessedUp){
            guardObj.GetComponent<PlayerFixObjects>().ShowTakeText();
        }
    }

    public void GuardInteract(GameObject guardObj){
        if(isMessedUp){
            PlayerFixObjects guardControl = guardObj.GetComponent<PlayerFixObjects>();
            if(guardControl.GetInventory() == null){
                isMessedUp = false;
                guardControl.AddToInventory(missingPiecePrefab);
                DestroyMissingPiece();
            }
        }
    }

    void RenderMissingPiece(){
        missingPieceInstance = Instantiate(missingPiecePrefab, this.gameObject.transform);
    }

    void DestroyMissingPiece(){
        Destroy(missingPieceInstance);
        missingPieceInstance = null;
        missingPiecePrefab = null;
    }
}
