using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaveLoadSystem;
using UnityEngine;   
public class SaveGameTester : MonoBehaviour
{
    public void SaveGame()
    {
        SaveGameManager.CurrentSaveData.Cards.Add(new Card(CardType.Question, "Isso é um teste?"));
        SaveGameManager.CurrentSaveData.Cards.Add(new Card(CardType.Answer, "Isso com certeza é um teste"));
        SaveGameManager.Save();
    }

    public void LoadGame()
    {
        SaveGameManager.Load();
        foreach (Card card in SaveGameManager.CurrentSaveData.Cards)
        {
            Debug.Log($"Card of type {card.CardType} and text of {card.CardText}");
        }
    }
}
