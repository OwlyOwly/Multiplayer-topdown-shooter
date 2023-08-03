using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform movementIndication;
    
    private Vector2 input;
    private Joystick joystick;

    private const float movementIndicationPositionY = 0f;

    private void Start()
    {
        joystick = CanvasSingleton.Instance.GetJoystick();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        transform.position = Vector2.MoveTowards(transform.position, movementIndication.position, Time.deltaTime * speed);

        var currentPlayerPosition = transform.position;
        
        movementIndication.position = new Vector3(joystick.Horizontal + currentPlayerPosition.x, joystick.Vertical + currentPlayerPosition.y , movementIndicationPositionY);

        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            transform.right = movementIndication.position - transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.OnCollect();
        }
    }
}
