using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OtherMenus : MonoBehaviour
{
    public int sceneIndex;
    
    public void LoadScene () {
        SceneManager.LoadScene(sceneIndex);
    }
}
