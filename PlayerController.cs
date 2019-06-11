using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
		public float speed;
		private Rigidbody rb;
		private int count;
        public GameObject ramper;
		public GameObject triangle;
		public GameObject playyer;
		public virtualjoystick joystick;

		//public GameObject square;

		public Door door;

        void Start ()
		{
		rb = GetComponent<Rigidbody>();
		count = 0;
		
		}

	void FixedUpdate ()
	{
		// float moveHorizontal = Input.GetAxis ("Horizontal");
		// float moveVertical = Input.GetAxis ("Vertical");
		 float moveHorizontal = joystick.Horizontal();
		 float moveVertical = joystick.Vertical();

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	 public void iclvl() 
	{
		
			int i = Application.loadedLevel;
            Application.LoadLevel(i + 1);
            if(i==7)
            	PlayerPrefs.SetInt("round", 1);
            if(i==8)
                PlayerPrefs.SetInt("round", 2);
            if (i == 9)
                PlayerPrefs.SetInt("round", 3);
            if (i == 10){
					PlayerPrefs.SetInt("round", 4);
					SceneManager.LoadScene ("HSS");
			}
		}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{

			other.gameObject.SetActive (false);
			int i = Application.loadedLevel;
            Application.LoadLevel(i + 1);
            if(i==7)
            	PlayerPrefs.SetInt("round", 1);
            if(i==8)
                PlayerPrefs.SetInt("round", 2);
            if (i == 9)
                PlayerPrefs.SetInt("round", 3);
            if (i == 10){
					PlayerPrefs.SetInt("round", 4);
					SceneManager.LoadScene ("HSS");
			}
		}
		else if(other.gameObject.CompareTag ("triangle")){
			Debug.Log("triangle");
			//other.gameObject.SetActive (false);
            ramper.SetActive(false);
            door.Open();


        }
		
		else if(other.gameObject.CompareTag ("square")){
			
			Debug.Log("square");
		}
	
	}
	public void dieplayer(){
		playyer.SetActive(false);
		SceneManager.LoadScene ("HSS");
	}

}