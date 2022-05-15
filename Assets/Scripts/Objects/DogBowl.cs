using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBowl : MonoBehaviour
{

    public bool isEmpty = true;

    private DogController dogController;
    public GameObject dogBowlFull, dogBowlEmpty;

    void Start(){
        dogBowlEmpty.SetActive(true);
        dogBowlFull.SetActive(false);
        dogController = GameObject.Find("Dog").GetComponent<DogController>(); //gambiarra pra poder chamar o cachorro quando o prato estiver cheio
    }

    public void MessUp(){
        if(!isEmpty){
            dogBowlFull.SetActive(false);
            dogBowlEmpty.SetActive(true);
            isEmpty = true;
        }
    }

    public void FillUp(){
        if(isEmpty){
            dogBowlFull.SetActive(true);
            dogBowlEmpty.SetActive(false);
            isEmpty = false;
            dogController.SetNextTarget(this.gameObject);
        }
    }

}

