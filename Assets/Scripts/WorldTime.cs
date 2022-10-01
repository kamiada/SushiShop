using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        showTimeOnScreen.text = fullTime.ToString();
        if (fullTime <= 0.0f) {
            LoadScrene("GameOver")
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
