using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cardDisplayText;
    [SerializeField] private Image _cardDisplay;
    private Card _card;
    
    public void SetCard(Card card)
    {
        _card = card;
        SetBackgroundColor();
        SetDisplayText();
    }

    void SetBackgroundColor()
    {
        if (_card.CardType == CardType.Question)
        {
            _cardDisplay.color = Color.black;
            _cardDisplayText.color = Color.white;
        }
        else
        {
            _cardDisplay.color = Color.white;  
            _cardDisplayText.color = Color.black;
        }
    }

    void SetDisplayText()
    {
        _cardDisplayText.text = _card.CardText;
    }

}
