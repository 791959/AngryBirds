using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeginScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject layout;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()//play button
    {
        layout.SetActive(true);
    }
    public void LoadSceenButtonClick(int i) //star button
    {
        SceneManager.LoadScene(i);
    }
    public void ReturnButtonClick() //返回按钮
    {
        SceneManager.LoadScene(0);
    }
}
