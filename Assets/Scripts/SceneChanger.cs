using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    float light0;
    float light1;
    float light2;
    float light3;
    float start;
    bool changeNow = false;
    bool change_cur = false;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();  
        light0 = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().intensity;
        light1 = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Light>().intensity;
        light2 = this.gameObject.transform.GetChild(2).gameObject.GetComponent<Light>().intensity;
        light3 = this.gameObject.transform.GetChild(3).gameObject.GetComponent<Light>().intensity;     
    }

    // Update is called once per frame
    void Update()
    {
        if(changeNow)
        {
            start = Time.time;
            change_cur = true;
            changeNow = false;
        }
        if(change_cur){
            light0 *= 0.8f;
            light1 *= 0.8f;
            light2 *= 0.8f;
            light3 *= 0.8f;
            if(Time.time - start > 3){
                int sceneNum = SceneManager.sceneCountInBuildSettings;
                int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
                //buildIndex：index in build setting
                SceneManager.LoadSceneAsync((currentSceneIdx + 1) % sceneNum);
            }
        }
    }
    void OnTriggerEnter(Collider collider){
        Debug.Log("trigger");
        changeNow = true;
    }
    
}

