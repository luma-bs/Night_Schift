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

    private DogNavMesh dogObject;

    public bool touched = false;
    private bool timerStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _gameObject = _transform.gameObject;
        Debug.Log(_gameObject);

        thisRenderer = GetComponent<MeshRenderer>();

        untouchedMaterial = Resources.Load<Material>("Materials/Object-False");
        touchedMaterial = Resources.Load<Material>("Materials/Object-True");
        
        dogObject = ( GameObject.Find("Dog") ).GetComponent<DogNavMesh>();
        
        /* Isto foi usado para Debug, como forma de saber se consegui com sucesso as variáveis
        contidas no GameObject 'Dog'
        foreach (GameObject go in dogObject.pointsOfInterest){
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
        if ( (touched == true) && (timerStarted == false)) {
            // (?) Remover objeto da lista de objetos do cachorro
            dogObject.pointsOfInterest.Remove(_gameObject);
            // Ligar timer

            // Mudar material
            thisRenderer.material = touchedMaterial;
        }
    }
}
