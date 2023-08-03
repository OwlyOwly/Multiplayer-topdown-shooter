using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public void OnCollect()
    {
        gameObject.SetActive(false);
    }
}
