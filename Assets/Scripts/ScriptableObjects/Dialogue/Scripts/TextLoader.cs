using Dialogue.Scripts;
using TMPro;
using UnityEngine;

namespace ScriptableObjects.Dialogue.Scripts
{
    public class TextLoader : MonoBehaviour
    {
        public Dialog dialogue;
        private Response[] responses;
    
        private string name;
        private string npcText;
        private string[] responseText;
        private int importantInt;
    
        public TMP_Text tmpNpcName;
        public TMP_Text tmpNpcText;
        public TMP_Text tmpResponse1;
        public TMP_Text tmpResponse2;
        public TMP_Text tmpPlayer;
        public TMP_Text stats;

        public void Update()
        {
            responses = dialogue.message.responseOptions;

            tmpResponse1.text = responses[0].responseText;
            tmpResponse2.text = responses[1].responseText;

            name = dialogue.npcName;
            npcText = dialogue.message.message;
        
            tmpNpcName.text = name;
            tmpNpcText.text = npcText;
        
            stats.text = "Strength " + dialogue.number1 + " Health " + dialogue.number2 + " Stanima " + dialogue.number3;

            if (dialogue != dialogue)
            { 
                tmpNpcName.gameObject.SetActive(false);
                tmpNpcText.gameObject.SetActive(false);
                tmpResponse1.gameObject.SetActive(false);
                tmpResponse2.gameObject.SetActive(false);
                tmpPlayer.gameObject.SetActive(false);
                stats.gameObject.SetActive(false);
            }
        }

        public void Click(int buttonNumber)
        {
            int importantInt = buttonNumber;
            // dialogue = responses[importantInt].response;
        
            dialogue = responses[importantInt].response;
        
            LoadText(dialogue);
            tmpPlayer.text = responses[buttonNumber].responseText;

        }

        public void LoadText(Dialog dialog)
        {
            name = dialogue.npcName;
            npcText = dialogue.message.message;
        
            tmpNpcName.text = name;
            tmpNpcText.text = npcText;
        
        }

        public void ShowText()
        {
        
        }
    
    }
}
