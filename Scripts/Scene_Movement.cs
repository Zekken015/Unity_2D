using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*here in this script is where you use it to trigger something to move to a different scene
 * i used this to move inside buildings and move between scenes.
 */
public class Scene_Movement : MonoBehaviour
{

    public string loadScene;
    public Vector2 playerLocation;
    public Player_Positioning locationStorage;
    public GameObject fadePanelIn;
    public GameObject fadePanelOut;
    public float fadeDelay;

    //using quaternion to know where the objects are in the game
    //figuring out where everything is.
    public void Awake()
    {
        if (fadePanelIn != null)
        {
            GameObject panel = Instantiate(fadePanelIn, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    //figuring out where the player was and where to put him.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            locationStorage.firstValue = playerLocation;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(loadScene);
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadePanelOut != null) {
            Instantiate(fadePanelOut, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeDelay);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(loadScene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
