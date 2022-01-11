using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {
     //   Debug.Log("Stay");

        if (collision.tag == "Enemy")
        {
            Debug.Log("“G‚ð”­Œ©");

            Destroy(collision.gameObject);
        }
        
    }
}
