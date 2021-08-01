using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public string message;
    public bool messageActive;
    public GameObject messageBox;
    public Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //checks if the user is close to the object
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && messageActive)
        {
            if (messageBox.activeInHierarchy)
            {
                messageBox.SetActive(false);
            }
            else
            {
                messageBox.SetActive(true);
                messageText.text = message;
            }
        }
    }

    //checks if the player is within range 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            messageActive = false;
            messageBox.SetActive(false);
        }
    }

    //activates a message box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            messageActive = true;
        }
    }

}
