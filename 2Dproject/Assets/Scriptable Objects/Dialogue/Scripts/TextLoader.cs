using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue.Scripts;
using TMPro;
using UnityEngine;

public class TextLoader : MonoBehaviour
{
    public Dialog dialogue;
    private Response[] responses;
    
    private string name;
    private string npcText;
    private string[] responseText;
    private int importantInt;
    
    public TMP_Text tmp_npcName;
    public TMP_Text tmp_npcText;
    public TMP_Text tmp_response1;
    public TMP_Text tmp_response2;
    public TMP_Text tmp_Player;
    public TMP_Text stats;

    public void Update()
    {
        responses = dialogue.message.responseOptions;

        tmp_response1.text = responses[0].responseText;
        tmp_response2.text = responses[1].responseText;

        name = dialogue.npcName;
        npcText = dialogue.message.message;
        
        tmp_npcName.text = name;
        tmp_npcText.text = npcText;
        
        stats.text = "Strength " + dialogue.number1 + " Health " + dialogue.number2 + " Stanima " + dialogue.number3;

        if (dialogue != dialogue)
        { 
            tmp_npcName.gameObject.SetActive(false);
            tmp_npcText.gameObject.SetActive(false);
            tmp_response1.gameObject.SetActive(false);
            tmp_response2.gameObject.SetActive(false);
            tmp_Player.gameObject.SetActive(false);
            stats.gameObject.SetActive(false);
        }
    }

    public void Click(int buttonNumber)
    {
        int importantInt = buttonNumber;
        // dialogue = responses[importantInt].response;
        
        dialogue = responses[importantInt].response;
        
        LoadText(dialogue);
        tmp_Player.text = responses[buttonNumber].responseText;

    }

    public void LoadText(Dialog dialog)
    {
        name = dialogue.npcName;
        npcText = dialogue.message.message;
        
        tmp_npcName.text = name;
        tmp_npcText.text = npcText;
        
    }

    public void ShowText()
    {
        
    }
    
}
