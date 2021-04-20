using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCounter : MonoBehaviour
{
    internal int ballCount = 0;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = ballCount.ToString();
    }
}
