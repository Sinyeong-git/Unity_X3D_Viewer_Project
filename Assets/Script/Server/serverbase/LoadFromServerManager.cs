using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadFromServerManager : loadserver
{
    #region 맴버 변수 선언

    #endregion

    #region 이니셜라이저
    public void Initialize()
    {

    }
    #endregion

    private void Start()
    {
        Initialize();
        //Draw();
    }

    public void OnClickStartBtn(int _input)
    {
        if (_input == 1)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
