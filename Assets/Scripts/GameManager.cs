using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] backGroundLayer;
    public GameObject MoveButton;
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

    public void ControlBackGroundMove()
    {
        if(backGroundLayer[0].GetComponent<MoveBackground>().curr_speed == 0)
        {
            MoveButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Stop");
            for(int loop = 0; loop < backGroundLayer.Length; loop++)
                backGroundLayer[loop].GetComponent<MoveBackground>().move();
        }
        else
        {
            MoveButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Go");
            for (int loop = 0; loop < backGroundLayer.Length; loop++)
                backGroundLayer[loop].GetComponent<MoveBackground>().stop();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
