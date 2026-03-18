using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI coinText;
  private int _coins;

  public void AddCoins(int amount)
  {
    _coins += amount;
    coinText.text = ($"You have: {_coins}");
  }
}
