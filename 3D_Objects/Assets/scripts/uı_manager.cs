using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uı_manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ball_manager;
    [SerializeField] UnityEngine.UI.Text health, time, status;
    [SerializeField] UnityEngine.UI.Button button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = ball_manager.GetComponent<ball_manager>().timer;
        time.text = (int)temp + "";
        ball_manager.GetComponent<ball_manager>().is_game_over();
    }
}
