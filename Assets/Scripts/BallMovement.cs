using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rbody;

    public Image WinLossWindow;

    public Text WinLossText;

    public float score = 0;
    
    public Text scoreText;

    public bool Lose;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody> ();
        Lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis ("Horizontal");
        float inputV = Input.GetAxis ("Vertical");

        Vector3 move = new Vector3 (inputH, 0f, inputV);
        rbody.AddForce (move);

        scoreText.text = "Score: "+score.ToString ();

        if(score >= 8 || Lose == true){
        	WinLossWindow.gameObject.SetActive (true);
        	WinLossText.text = "YOU WON";
        	if(Lose == true){
        		WinLossText.text = "GAME OVER";
        	}
        }
        else{
        	WinLossWindow.gameObject.SetActive (false);
        }
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.tag == "Pickup"){
    		Destroy (other.gameObject);

    		score += 1;
    	}

    	if(other.gameObject.tag == "Enemy"){
    		Lose = true;
    	}

    }
}
