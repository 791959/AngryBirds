using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    // Start is called before the first frame update
    int life = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollision()
    {
        life--;
        if (life == 0)
        {
            Destroy(this.gameObject);
            String.instance.PlayWoodAudio();
        }
    }
}
