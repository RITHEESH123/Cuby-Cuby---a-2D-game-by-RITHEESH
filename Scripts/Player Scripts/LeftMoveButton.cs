using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LeftMoveButton : MonoBehaviour, IPointerDownHandler
{
    public Rigidbody2D player;

    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left" && Input.GetMouseButton(0))
        {
            player.velocity = new Vector2(-2f, player.velocity.y);
        }
    }
}
