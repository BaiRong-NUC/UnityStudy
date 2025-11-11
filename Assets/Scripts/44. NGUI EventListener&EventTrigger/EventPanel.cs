using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : MonoBehaviour
{
    public UISprite uISprite;

    void Start()
    {
        UIEventListener listener = UIEventListener.Get(uISprite.gameObject);
        listener.onPress += (GameObject go, bool state) =>
        {
            if (state)
            {
                Debug.Log("Press Down on " + go.name);
            }
            else
            {
                Debug.Log("Press Up on " + go.name);
            }
        };
    }
}
