using System;
using UnityEngine;

namespace Test1
{
    [Serializable]
    public class CardData
    {
        [field: SerializeField] public string Identifier { get; private set; }
        [field: SerializeField] public Sprite SpriteIcon { get; private set; }
        [field: SerializeField] public float SpriteRotarion { get; private set; }
    }
}
