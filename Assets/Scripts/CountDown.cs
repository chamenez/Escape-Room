using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float CountDownTime;
    public TextMeshProUGUI CountDownText;

    // Update is called once per frame
    void Update()
    {
        CountDownText.text = CountDownTime.ToString("00");
        CountDownTime += 1 * Time.deltaTime;
    }
}
