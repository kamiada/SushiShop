using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public float MaxValue;
    public float MinValue;
    public string Stat;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = MaxValue;
        slider.minValue = MinValue;
    }

    private void OnGUI()
    {
        slider.value = GameManager.Instance.GetPlayerStat(Stat);
    }
}
