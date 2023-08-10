using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public Suit suit;
    public Rank rank;
    public GameObject cardPrefab; 

    public Card(Suit s, Rank r, GameObject prefab)
    {
        suit = s;
        rank = r;
        cardPrefab = prefab;
    }
}

public class CardImage : MonoBehaviour
{
    public GameObject cardPrefab; // Assign the card prefab in the Inspector
    private List<Card> deck;
    private List<Card> playerHand;
    private List<Card> opponentHand;
    private List<Card> tableCards;

    private Dictionary<(Card.Suit, Card.Rank), Sprite> cardImageMap;

    public void Start()
    {
        InitializeCardImageMap(); 
        InitializeDeck();
        Shuffle(deck);

        playerHand = DealCards(2);
        opponentHand = DealCards(2);
        tableCards = DealCards(2);
    }

    private void InitializeCardImageMap()
{
    cardImageMap = new Dictionary<(Card.Suit, Card.Rank), Sprite>();

    foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit)))
    {
        foreach (Card.Rank rank in System.Enum.GetValues(typeof(Card.Rank)))
        {
            string imagePath = "Cards/solitaire/individuals/" + suit.ToString().ToLower() + "/" + ((int)rank).ToString() + "_" + suit.ToString().ToLower();
            Sprite image = Resources.Load<Sprite>(imagePath);
            cardImageMap[(suit, rank)] = image;
        }
    }
}


private void InitializeDeck()
    {
        deck = new List<Card>();

        foreach (Card.Suit suit in System.Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in System.Enum.GetValues(typeof(Card.Rank)))
            {
                GameObject prefab = cardPrefab; // Use the single card prefab
                Card card = new Card(suit, rank, prefab);

                // Ensure the cardPrefab has a SpriteRenderer component
                SpriteRenderer spriteRenderer = prefab.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    // Load and assign the card image
                    Sprite cardImage = cardImageMap[(suit, rank)];
                    if (cardImage != null)
                    {
                        spriteRenderer.sprite = cardImage;
                    }
                    else
                    {
                        Debug.LogWarning("Missing card image for " + suit + " " + rank);
                    }

                    deck.Add(card);
                }
                else
                {
                    Debug.LogWarning("Missing SpriteRenderer component for card prefab: " + prefab.name);
                }
            }
        }
    }



    private void Shuffle(List<Card> cardList)
    {
        int n = cardList.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Card temp = cardList[i];
            cardList[i] = cardList[j];
            cardList[j] = temp;
        }
    }

    private List<Card> DealCards(int count)
    {
        List<Card> dealtCards = new List<Card>();

        for (int i = 0; i < count; i++)
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            dealtCards.Add(card);
        }

        return dealtCards;
    }
}
