using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameExit()
    {
        Debug.Log("������");
        Application.Quit();
    }
    public void GameStart()
    {
        Debug.Log("ó������");
    }
    public void GameContinue()
    {
        Debug.Log("�̾��ϱ�");
    }
}
