using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    [SerializeField] private bool _isLeader;
    [SerializeField] private int _currentScore;
    [SerializeField] private List<Card> _holdingCards = new List<Card>();

    public bool IsLeader => _isLeader;
    public int CurrentScore => _currentScore;
    public List<Card> HoldingCards => _holdingCards;

    public void SetIsLeader(bool isLeader)
    {
        _isLeader = isLeader;
    }

    public void AddScore(int addedScore)
    {
        _currentScore += addedScore;
    }

    public void AddCard(Card newCard)
    {
        if (_holdingCards.Contains(newCard))
            return;
        
        _holdingCards.Add(newCard);
    }
}
