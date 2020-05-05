using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public static float time;
    public GameObject Obj = null;

    // Start is called before the first frame update
    void Start()
    {
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Obj = GameObject.Find("blackBackground");
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                //blackBackground.SetActive(false);
                Obj.SetActive(false);
                Debug.Log("비활성화 되었습니다.");
            }
        }

        int t = Mathf.FloorToInt(time);
        Text uiText = GetComponent<Text>();
        uiText.text =  (t+1).ToString();
    }
}
