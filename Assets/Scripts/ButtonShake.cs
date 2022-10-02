using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonShake : MonoBehaviour
{
    public float ShakeRange = 1.0f;
    private bool shaking = false;
    private Image image;
    private TextMeshProUGUI TMProText;
    private Vector2 imgOrigPos;
    private Vector2 txtOrigPos;

    private void Start()
    {
        image = GetComponentInParent<Image>();
        TMProText = GetComponent<TextMeshProUGUI>();

        imgOrigPos = image.transform.position;
        txtOrigPos = TMProText.transform.position;
    }

    public void SetShake(bool value)
    {
        shaking = value;

        if (value == false)
        {
            image.transform.position = imgOrigPos;
            TMProText.transform.position = txtOrigPos;
        }
    }

    private void FixedUpdate()
    {
        float randFloat()
        {
            return Random.Range(-ShakeRange, ShakeRange);
        };

        if (shaking)
        {
            image.transform.position = imgOrigPos + new Vector2(randFloat(), randFloat());
            TMProText.transform.position = txtOrigPos + new Vector2(randFloat(), randFloat());
        }
    }
}
