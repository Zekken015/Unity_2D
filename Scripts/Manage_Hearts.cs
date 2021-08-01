using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*this is the script to look after the hearths of both monsters and players
 * it keeps track of how much everyone has
 * this works in conjunction to scriptable objects.
 */
public class Manage_Hearts : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite noHeart;
    public Float_Values heartBox;
    public Float_Values heartsUpdate;

    // Start is called before the first frame update
    void Start()
    {
        TriggerHearts();
    }


    public void TriggerHearts()
    {
        for (int i = 0; i < heartBox.firstValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    //updates how many hearts everyone has making sure to keep track of it
    //uses images to track it.
    public void HeartsUpdate()
    {
        float testHealth = heartsUpdate.DurationValue / 2;
        for(int i = 0; i < heartBox.firstValue; i++)
        {
            if(i <= testHealth - 1)
            {
                //full heart
                hearts[i].sprite = fullHeart;
            }
            else if(i >= testHealth)
            {
                //no heart
                hearts[i].sprite = noHeart;
            }
            else
            {
                //half heart
                hearts[i].sprite = halfHeart;
            }
        }
    }
}
