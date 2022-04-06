using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFixObjects : MonoBehaviour
{

    public Text pressButtonText;
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
        if (other.gameObject.GetComponent<MuseumPieceBehaviour>().getIsTouched())
            pressButtonText.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (pressButtonText.enabled == true)
            pressButtonText.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<MuseumPieceBehaviour>().getIsTouched() && Input.GetKey("e"))
        {
            other.gameObject.SendMessage("FixObject");
            pressButtonText.enabled = false;
        }
    }
}
