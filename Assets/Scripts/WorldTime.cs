using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldTime : MonoBehaviour
{
    float fullTime = 30.0f;
    public Text showTimeOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fullTime -= Time.deltaTime;
        showTimeOnScreen.text = fullTime.ToString();
        if (fullTime <= 0.0f) {
            LoadScene("GameOver");
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
