using UnityEngine;

public class ScoreText : MonoBehaviour
{

 

    void Start()
    {
        GameManager.Instance.ScoreText = GetComponent<TMPro.TextMeshProUGUI>();

    }
}
