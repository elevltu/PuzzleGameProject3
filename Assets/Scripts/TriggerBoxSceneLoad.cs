using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBoxSceneLoad : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
