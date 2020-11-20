using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour{

    public static int scoreValue = 0;
    public static int targetScore;
    [SerializeField]Text score;

   

    // Start is called before the first frame update
    void Start(){
        score = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update(){
        score.text = "Score: " + scoreValue;
    }

}
