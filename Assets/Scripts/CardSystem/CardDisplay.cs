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
        if (_card.CardType == CardType.Answer)
            _cardDisplay.color = Color.black;
        else
            _cardDisplay.color = Color.white;
    }

    void SetDisplayText()
    {
        _cardDisplayText.text = _card.CardText;
    }

}
