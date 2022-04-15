using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SaveData
    {
        [SerializeField]
        public List<Card> Cards = new List<Card>();
    }
}

