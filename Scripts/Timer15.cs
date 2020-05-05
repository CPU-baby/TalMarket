using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer15 : MonoBehaviour
{
    public static float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                SceneManager.LoadScene("FalseScene");
            }
        }

        int t = Mathf.FloorToInt(time);
        Text uiText = GetComponent<Text>();
        uiText.text = (t + 1).ToString();
    }
}
