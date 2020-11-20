using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    
 public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void PlayLevel1(){
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2(){
        SceneManager.LoadScene(2);
    }
  public void Credits(){
    SceneManager.LoadScene(3);
  }

  public void QuitGame(){
     Application.Quit();
  }

}
