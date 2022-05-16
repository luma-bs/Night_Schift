using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFixObjects : MonoBehaviour
{

    public Text pressButtonText;
    //public GameObject inventory;
    //public GameObject inventoryItemInstance;

    private Animator animator;

    private string fixableObjectsTag = "MuseumPiece";
    private string takeableObjectsTag = "TakeableObj"; 
    private string dogDistractionTag = "DogDistraction";
    
    private string fixText = "Pressione E para arrumar";
    private string dogfoodText = "Pressione E para encher de ração";
    private string fullBowlText = "Encheu!";

    // Start is called before the first frame update
    void Start()
    {
        pressButtonText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == fixableObjectsTag){
            if(other.gameObject.GetComponent<ObjectAnimationController>().isMessed){
                ShowFixText();
            } 
        } else if(other.gameObject.tag == dogDistractionTag){
            if(other.gameObject.GetComponent<DogBowl>().isEmpty){
                ShowDogFoodText();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == fixableObjectsTag){
            if (other.gameObject.GetComponent<ObjectAnimationController>().isMessed && Input.GetKey("e")){
                other.gameObject.SendMessage("Fix");
            }
        } else if(other.gameObject.tag == dogDistractionTag){
            if(other.gameObject.GetComponent<DogBowl>().isEmpty && Input.GetKey("e")){
                other.gameObject.SendMessage("FillUp");
                ShowFullBowlText();
            }
        }
    }

    public void ShowFixText(){
        ShowText(fixText);
        
    }

    public void ShowDogFoodText(){
        ShowText(dogfoodText);
    }

    public void ShowFullBowlText(){
        ShowText(fullBowlText);
    }

    public void ShowCustomText(string txt){
        ShowText(txt);
    }

    private void ShowText(string newText){
        pressButtonText.enabled = true;
        pressButtonText.text = newText;
        StopAllCoroutines();
        StartCoroutine("TextCooldown");
    }

    IEnumerator TextCooldown(){
        yield return new WaitForSeconds(2);
        pressButtonText.enabled = false;
    }

    /*public void AddToInventory(GameObject newItem){
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
    }*/

}
