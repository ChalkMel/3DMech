using UnityEngine;

public class Coin : GetPlayerLayer
{
  [SerializeField] private int coinValue;
  [SerializeField] private CoinCounter coinCounter;
  [SerializeField] private float height = 0.3f;
  [SerializeField] private float speed = 1f;
  [SerializeField] private float spinSpeed = 50f;

  private void Update()
  {
    transform.position += Vector3.up * (Mathf.Sin(Time.time * speed) * height * Time.deltaTime);
    transform.Rotate(Vector3.up * (spinSpeed * Time.deltaTime));
  }
  private void OnTriggerEnter(Collider other)
  {
    if (LayerMaskUtil.ContainsPlayer(other.gameObject))
    {
      coinCounter.AddCoins(coinValue);
      Destroy(gameObject);
    }
  }
}
