using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioController audioController;
    public bool isRunning = false;


    void Awake()
    {
        StartCoroutine("ControladorAudio");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("running gm : "+ isRunning);
    }

    private IEnumerator ControladorAudio()
    {
        
            if(isRunning){
           audioController.AudioSteps();
           yield return new WaitForSeconds(1);
            }
        
        
    }
}
