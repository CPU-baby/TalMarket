using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void onescene()
    {
        SceneManager.LoadScene("OnestageScene");
    }

    public void rankingscene()
    {
        SceneManager.LoadScene("rankingScene");
    }
}
