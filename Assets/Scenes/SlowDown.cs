using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{

    public PlayerMovement playmov;
    public float slowness = 5.0f;
    public GameObject arrow;
    public GameObject player;
    Rigidbody2D rb;

    public float dashSpeed = 10.0f;
    public float rotspeed=20.0f;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      arrow.transform.RotateAround(player.transform.position,new Vector3(0,0,1),Time.deltaTime*rotspeed);

      if(Input.GetKeyDown("x")  &&  playmov.isJumped)
      {
        Time.timeScale = 1f/slowness;
        playmov.enabled = false;

        arrow.SetActive(true);
      }

      if(Input.GetKeyUp("x") && playmov.isJumped)
      {
        playmov.isJumped=false;
        Time.timeScale = 1.0f;

        playmov.enabled = true;
        arrow.SetActive(false);

        //transform.rotation = arrow.transform.rotation;
        rb.velocity= arrow.transform.right * dashSpeed;
      }

    }
}
