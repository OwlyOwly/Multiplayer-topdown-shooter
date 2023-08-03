using UnityEngine;
using Mirror;

public class LocalPlayerSpriteChanger : NetworkBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    
    private void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (isLocalPlayer)
        {
            playerSpriteRenderer.color = Color.green;
        }
    }
}
