using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private int nextSceneToLoad;
    private Scene scene;
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" )
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

}

