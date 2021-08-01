using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Pot : MonoBehaviour
{

    private Animator objectAnimation;

    // Start is called before the first frame update
    void Start()
    {
        objectAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shatter()
    {
        objectAnimation.SetBool("destroy", true);
        Delay();
    }
    public async void Delay()
    {
        // whatever you need to do before delay goes here         

        await Task.Delay(350);

        this.gameObject.SetActive(false);
    }
}
