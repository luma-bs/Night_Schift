using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFixObjects : MonoBehaviour
{

    public Text pressButtonText;
    public GameObject inventory;
    public GameObject inventoryItemInstance;

    private Animator animator;

    private string fixableObjectsTag = "MuseumPiece";
    private string takeableObjectsTag = "TakeableObj"; 
    private string dogDistractionTag = "DogDistractionTag";
    
    private string fixText = "Pressione E para arrumar";
    private string takeText = "Pressione E para pegar";
    private string missingText = "Alguma coisa está faltando...";

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
        other.gameObject.SendMessage("GuardApproach", this.gameObject);
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey("e")){
            other.gameObject.SendMessage("GuardInteract", this.gameObject);
            animator.SetBool("Fix", true);
        }
    }

    public void ShowFixText(){
        ShowText(fixText);
        
    }

    public void ShowTakeText(){
        ShowText(takeText);
    }

    public void ShowMissingText(){
        ShowText(missingText);
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
