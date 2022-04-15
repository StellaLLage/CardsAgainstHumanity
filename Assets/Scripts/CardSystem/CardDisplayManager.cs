using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaveLoadSystem;
using UnityEngine;

public class CardDisplayManager : MonoBehaviour
{
    [SerializeField] private Transform _cardsParent;
    void Start()
    {
        if (SaveGameManager.CurrentSaveData.Cards.Count <= 0)
            SaveGameManager.Load();

        
    }
}
