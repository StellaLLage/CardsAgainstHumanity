using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaveLoadSystem;
using UnityEngine;

public class CardDisplayManager : MonoBehaviour
{
    [SerializeField] private Transform _cardsQuestionParent;
    [SerializeField] private Transform _cardsAnswerParent;
    [SerializeField] private CardDisplay _cardPrefab;
    private List<CardDisplay> _cardDisplays = new List<CardDisplay>();
    void Start()
    {
        if (SaveGameManager.CurrentSaveData.Cards.Count <= 0)
            SaveGameManager.Load();

        foreach (Card card in SaveGameManager.CurrentSaveData.Cards)
        {
            CardDisplay cardCache = Instantiate(_cardPrefab, card.CardType == CardType.Question ? _cardsQuestionParent : _cardsAnswerParent);
            cardCache.SetCard(card);
            _cardDisplays.Add(cardCache);
        }
    }
}
