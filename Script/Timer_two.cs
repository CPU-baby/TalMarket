using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_two : MonoBehaviour
{

    public static float time2;
    public Text timeText;
    public GameObject receipt_btn;

    // Start is called before the first frame update
    void Start()
    {
        time2 = 3f;
        receipt_btn = GameObject.Find("receipt_btn");

    }

    // Update is called once per frame
    void Update()
    {
        if (time2 != 0)
        {
            time2 -= Time.deltaTime;
            
            if (receipt_btn)
            {
                
            }
            
            if (time2 <= 0)
            {
                time2 = 0;

                SceneManager.LoadScene("Game");

            }
        }

        int t = Mathf.FloorToInt(time2);
        Text uiText = GetComponent<Text>();
        uiText.text = "Time : " + t.ToString();
    }
}
