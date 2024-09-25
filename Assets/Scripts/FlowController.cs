using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowController : MonoBehaviour
{
    public void SceneMover(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

    }
}
