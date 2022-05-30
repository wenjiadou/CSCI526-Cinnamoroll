using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScene : MonoBehaviour
{
    public void returnToStart()
    {
        SceneManager.LoadScene(0);
    }
}
