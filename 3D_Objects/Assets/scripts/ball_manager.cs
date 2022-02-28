using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ball_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ball_manager Instance;
    private Rigidbody rg;
    public UnityEngine.UI.Text health, time,status;
    public UnityEngine.UI.Button button;
    float speed = 3f;
    int healtcount=3;
    public float timer = 15;
    bool game_on=true;
    bool game_finish=false;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        is_game_over();
        if (game_on == true && game_finish == false)
        {
            timer -= Time.deltaTime;
        }
        else if (game_finish == false)
        {
            status.text = "Game Over"; 
            button.gameObject.SetActive(true);
        }
        
            
    }

    private void FixedUpdate()
    {
        if (game_on == true && game_finish == false )
        {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 force= new Vector3(yatay,0,dikey);
        rg.AddForce(force*speed);
        }
        else 
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string clname = collision.gameObject.name;
        if (clname.Equals("finish"))
        {
            game_finish = true;
            status.text = "Congratulations!";
            button.gameObject.SetActive(true);
             
        }
        else if (!clname.Equals("labyrinth_floor") && !clname.Equals("floor") && !clname.Equals("finish")) 
        {
            healtcount -= 1;
            health.text = healtcount + "";
            is_game_over();

        }
    }
    public void is_game_over()
    {
        if(timer<0 || healtcount <= 0)
        {
            game_finish = true;
            game_on = false;
        }
    }
}
