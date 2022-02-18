using System.Collections;
using UnityEngine;

public class clickTarget : MonoBehaviour
{

    public GameObject Target;
    public Transform parent;
    void Update()
    {
         if(Input.GetButtonDown("Fire1"))
         {
             Vector3 mousePos = Input.mousePosition;
             {
                 Vector3 objectPos = Camera.current.ScreenToWorldPoint(mousePos);
                 Instantiate(Target, objectPos, Quaternion.identity, parent);
             }
         }
    }
}
