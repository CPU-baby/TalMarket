using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class changeScene : MonoBehaviour
{

    public GameObject receipt_btn;

    private void Start()
    {
        receipt_btn = GameObject.Find("receipt_btn");
    }
    public void change()
    {
        
        SceneManager.LoadScene("Game");
        receipt_btn.SetActive(false);
    }





}
