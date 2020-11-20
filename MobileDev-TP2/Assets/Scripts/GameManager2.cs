using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour{
[SerializeField] GameObject asteroidpre;

    void Awake(){
        ScoreScript.scoreValue = 0;
        for(int i = 0;i<4;i++)
            Instantiate(asteroidpre,transform.position= new Vector3(Random.Range(-7.85f,7.95f),Random.Range(6f,12f),0) , transform.rotation);
        Time.timeScale = 1;
        ScoreScript.targetScore = 1000;
    }

    bool stage1 = false;
    bool stage2 = false;
    bool stage3 = false;
    bool win = false;

    void Update(){
        if(ScoreScript.scoreValue>160&&!stage1){
            stage1 = true;
            Instantiate(asteroidpre,transform.position= new Vector3(Random.Range(-7.85f,7.95f),Random.Range(6f,12f),0) , transform.rotation);
        }
        if(ScoreScript.scoreValue>320&&!stage2){
            stage2 = true;
            Instantiate(asteroidpre,transform.position= new Vector3(Random.Range(-7.85f,7.95f),Random.Range(6f,12f),0) , transform.rotation);
        }
        if(ScoreScript.scoreValue>480&&!stage3){
            stage3 = true;
            Instantiate(asteroidpre,transform.position= new Vector3(Random.Range(-7.85f,7.95f),Random.Range(6f,12f),0) , transform.rotation);
        }
        if (ScoreScript.scoreValue>=ScoreScript.targetScore){
            SceneManager.LoadScene(0);
        }
       
    }

   public void zawarudo(){
        Time.timeScale = 0;
    }

    public void zawarudont(){
        Time.timeScale = 1;
    }

    public void returnToMenu(){
        SceneManager.LoadScene(0);
    }
}
