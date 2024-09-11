using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using UnityEngine;

public class Deck : MonoBehaviour, ICardContainer
{
    [SerializeField] List<GameObject> cards;
    [SerializeField] private GameObject prefab;

    void Awake()
    {
        CardDatabase Data = CardDatabase.Instance;
        UnityEngine.Vector3 Position = new UnityEngine.Vector3(0, 0, 0);
        foreach (UnityCard unityCard in Data.PlayerDeck)
        {
            GameObject card = Instantiate(prefab, Position, gameObject.transform.rotation, gameObject.transform);
            card.GetComponent<RectTransform>().localScale = new UnityEngine.Vector2(0.16f, 0.16f);
            card.GetComponent<CardOutput>().SetValues(unityCard);
            string id = GetComponentInParent<Player>().Id;
            card.GetComponent<CardOutput>().PlayerId = id;
            cards.Add(card);
        }
    }
    public List<GameObject> GetCardList()
    {
        return cards;
    }
      public void RemoveCard(GameObject value)
    {
      cards.Remove(value);
      value.transform.SetParent(gameObject.transform , false);
    }
    void Update()
    {
        foreach (GameObject card in cards)
        {
            card.transform.SetParent(gameObject.transform , true);
            card.GetComponent<CardOutput>().OnHand = false;
        }
    }

}
