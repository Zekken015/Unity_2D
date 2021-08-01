using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     * OnTriggerEnter2D checks inside unity if collision is happening, this method
     * compares the tags and if its a tag of "breakable" then it will run Shatter method.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("breakable"))
        {
            collision.GetComponent<Pot>().Shatter();
        }
    }

}
