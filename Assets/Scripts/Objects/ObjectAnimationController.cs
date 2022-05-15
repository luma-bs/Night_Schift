using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimationController : MonoBehaviour
{

    ParticleSystem pSystem;
    public GameObject normalVersion;
    public GameObject messedVersion;

    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponentInChildren<ParticleSystem>();
        normalVersion.SetActive(true);
        messedVersion.SetActive(false);

    }

    public void MessUp(){
        pSystem.Play(false);
        normalVersion.SetActive(false);
        messedVersion.SetActive(true);
    }

    public void Fix(){
        pSystem.Play(false);
        messedVersion.SetActive(false);
        normalVersion.SetActive(true);
    }


}
