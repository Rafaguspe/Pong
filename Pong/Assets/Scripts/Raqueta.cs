using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour {
//Velocidad


public float velocidad = 30.0f;
//Eje vertical
public string eje,ejeH;
// Es llamado una vez cada fixed frame
void FixedUpdate () {
//Capto el valor del eje vertical de la raqueta
float v = Input.GetAxisRaw(eje);
float h = Input.GetAxisRaw(ejeH);




//Modifico la velocidad de la raqueta



if (ejeH=="Horizontal 2")
{
  Vector3 posi= GetComponent<Transform>().position;
    if (posi.x < -5f)
    {
         GetComponent<Rigidbody2D>().velocity = new Vector2(h, v )*velocidad;
    }
    else
    {
        Debug.Log("h> "+h.ToString());
        Debug.Log("v> "+v.ToString());
         GetComponent<Rigidbody2D>().velocity = new Vector2(h-3f, v-3f )*velocidad;
    }

}


if (eje=="Vertical")
{
  Vector3 posid= GetComponent<Transform>().position;
    if (posid.x > 5f)
    {
         GetComponent<Rigidbody2D>().velocity = new Vector2(h, v )*velocidad;
    }
    else
    {
        Debug.Log("h> "+h.ToString());
        Debug.Log("v> "+v.ToString());
         GetComponent<Rigidbody2D>().velocity = new Vector2(h+3f, v+3f )*velocidad;
    }
   
}





}
}

