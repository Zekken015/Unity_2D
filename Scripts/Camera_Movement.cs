using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*this part of the program is where i set the camera settings
 * i make sure that the camera cant move and it has boarders from where it cant move out of
 */
public class Camera_Movement : MonoBehaviour
{
    public Transform target;
    public float fluidity;
    public Vector2 maxLocation;
    public Vector2 minLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // in this update it checks the position of the camera
    // i can manually set the min and max locations of where the camera can and cant move
    // https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            targetPosition.x = Mathf.Clamp(targetPosition.x, minLocation.x, maxLocation.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minLocation.y, maxLocation.y);
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, fluidity);

            
        }
    }
}
