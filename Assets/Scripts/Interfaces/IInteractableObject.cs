using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableObject
{
    bool isMessedUp {get;set;}

    void DogInteract(GameObject dogObj);
    void GuardApproach(GameObject guardObj);
    void GuardInteract(GameObject guardObj);
}
