using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour{

//--Ponele--//
class AlertViewCallback : AndroidJavaProxy
    {
        private System.Action<int> alertHandler;

        public AlertViewCallback(System.Action<int> alertHandlerIn) : base(pluginName + "$AlertViewCallback")
        {
            alertHandler = alertHandlerIn;
        }
        public void OnButtonTapped(int index)
        {
            Debug.Log("Button Tapped: " + index);
            if(alertHandler != null)
            {
                alertHandler(index);
            }
        }
    }
//--EndPonele?--/

    const string pluginName = "com.imagecampus.unity.MyPlugin";

    static AndroidJavaClass _pluginClass;
    static AndroidJavaObject _pluginInstance;

    public static AndroidJavaClass PluginClass{
        get{
            if(_pluginClass==null){
                _pluginClass = new AndroidJavaClass(pluginName);
                 AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                _pluginClass.SetStatic<AndroidJavaObject>("mainActivity", activity);
            }
            return _pluginClass;
        }
    }

    public static AndroidJavaObject PluginInstance{
        get{
            if(_pluginInstance==null){
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("GetInstance");
            }
            return _pluginInstance;
        }
    }

    void Start()
    {
        Debug.Log("Elapsed time: " + getElapsedTime());
    }

    float elapsedTime = 0;
 
    void Update()
    {
        elapsedTime +=Time.deltaTime;
        if(elapsedTime>=5){
            elapsedTime=0;
            Debug.Log("Tick: "+ getElapsedTime());

        }
    }

    double getElapsedTime(){
        if(Application.platform==RuntimePlatform.Android){
            return PluginInstance.Call<double>("getElapsedTime");
        }
        Debug.LogWarning("Wrong Platform");
        return 0;

    }

    public void ShowAlertDialog(string[] strings, System.Action<int> handler = null){
        if(strings.Length < 3) {
            Debug.LogError("AlertView requires at least 3 strings");
            return;
        }

        if(Application.platform == RuntimePlatform.Android){
            PluginInstance.Call("ShowAlertView", new object[] { strings, new AlertViewCallback(handler) });
        }
        else{
            Debug.LogWarning("AlertView not supported on this platform");
        }
    }

    public void ClearLogs(Text text){
        
    }

    public void SendLog(string log){
        //ScoreScript.scoreValue
        PluginInstance.Call("SendLog",log);
    }
    public string GetLog(){
        return PluginInstance.Call<string>("GetAllLogs");
    }

}
