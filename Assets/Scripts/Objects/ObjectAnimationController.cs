using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimationController : MonoBehaviour
{

    ParticleSystem pSystem;
    public GameObject normalVersion;
    public GameObject messedVersion;
    public bool isMessed;

    // Start is called before the first frame update
    void Start()
    {
        isMessed = false;
        pSystem = GetComponentInChildren<ParticleSystem>();
        normalVersion.SetActive(true);
        messedVersion.SetActive(false);

    }

    public void MessUp(){
        if(!isMessed){
            pSystem.Play(false);
            normalVersion.SetActive(false);
            messedVersion.SetActive(true);
            isMessed = true;
        }
    }

    public void Fix(){
        if(isMessed){
            pSystem.Play(false);
            messedVersion.SetActive(false);
            normalVersion.SetActive(true);
            isMessed = false;
        }
    }


}
