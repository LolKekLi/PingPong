using System;
using UnityEngine;

public class Triger : MonoBehaviour
{
    public static Action<string> trigger = delegate { };
    public static Action goal = delegate { };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger(name);
        goal();
        collision.gameObject.transform.position = new Vector3 (-0.01f,0.01f, -0.2f);
    }
}
