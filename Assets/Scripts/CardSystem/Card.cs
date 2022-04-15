using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card                           
{
    [SerializeField] private CardType _cardType;
    [SerializeField] private string _cardText;
    
    
    public CardType CardType => _cardType;
    public string CardText => _cardText;

    public Card(CardType cardType, string cardText)
    {
        _cardType = cardType;
        _cardText = cardText;
    }

}

public enum CardType
{
    Question,
    Answer
}
