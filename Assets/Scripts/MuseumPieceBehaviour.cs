using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumPieceBehaviour : MonoBehaviour
{

    private MeshRenderer thisRenderer;

    private Transform _transform;
    private GameObject _gameObject; // Serve para referenciar a instância do objeto que contém este script

    private Material untouchedMaterial;
    private Material touchedMaterial;
    private Material thisMaterial;

    private GameObject dogObject;
    private DogNavMesh dogScript;

    public bool touched = false;
    public bool isTouching = false;
    private bool timerStarted = false;
    public float timeRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _gameObject = _transform.gameObject;

        thisRenderer = GetComponent<MeshRenderer>();

        untouchedMaterial = Resources.Load<Material>("Materials/Object-False");
        touchedMaterial = Resources.Load<Material>("Materials/Object-True");
        
        dogObject = GameObject.Find("Dog");
        dogScript = dogObject.GetComponent<DogNavMesh>();
        
        /* Isto foi usado para Debug, como forma de saber se consegui com sucesso as variáveis
        contidas no GameObject 'Dog'
        foreach (GameObject go in dogScript.pointsOfInterest){
            Debug.Log(go);
        }
        */

        // Só pra ter certeza de que o material está correto ao inicializar o jogo
        thisRenderer.material = untouchedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // Se objeto foi tocado
        if ( touched && !timerStarted) {

            // Manda uma mensagem para mudar o ponto de interesse do cachorro
            dogScript.SendMessage("UpdateTarget");

            // Ligar timer
            timeRemaining = 2;

            timerStarted = true;

            // Mudar material
            thisRenderer.material = touchedMaterial;
        }
        else if ( (!touched || isTouching ) && timerStarted )
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerStarted = false;

                Debug.Log("Done");
                
                thisRenderer.material = untouchedMaterial;

                dogScript.pointsOfInterest.Add(_gameObject);
            }
        }
    }
        
}
