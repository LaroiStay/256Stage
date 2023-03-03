using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    void Start()
    {

    }
    public void GotoPlayerSelect()
    {
        SceneManager.LoadScene(0);
    }
    public void Finish()
    {
        print("종료");
    }
}
