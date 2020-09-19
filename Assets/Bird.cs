using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    bool first=true;
    void Start()
    {
        Destroy(this.gameObject, 5.20f);
       // GameObject.Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pig")
        {
            collision.transform.GetComponent<Animator>().SetTrigger("Die");

            String.instance.AddScore();
            String.instance.DieAudio(0);
            GameObject.Destroy(collision.transform.GetComponent<Rigidbody2D>());
            GameObject.Destroy(collision.gameObject,1f);
        }
        else if (collision.transform.tag == "Wood")
        {
            if (first)
            {
                first = false;
                //  String.instance.DieAudio(1);
                //GameObject.Destroy(this.transform.GetComponent<Collider2D>());
                collision.gameObject.GetComponent<Wood>().OnCollision();
            }
            
        }
    }
}
