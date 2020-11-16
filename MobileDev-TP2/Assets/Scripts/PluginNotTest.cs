using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginNotTest : MonoBehaviour
{
    PluginTest pt; //Si.
    void Start(){
        pt = GetComponent<PluginTest>();
    }

       //bool ptxd = false;
    void Update(){
       // if(!ptxd){
       //     pt.ShowAlertDialog(new string[] { "Warning", "You are about to clear all logs. Are you sure?", "Confirm", "Cancel" }, (int obj) =>{});
       //     ptxd= true;
       // }
    }

    public void sendScoreToLog(){
        pt.SendLog(ScoreScript.scoreValue.ToString());
    }

    public void receiveScoreFromLog(Text text){
       text.text =  pt.GetLog();
    }
}


