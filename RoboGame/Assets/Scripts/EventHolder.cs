using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHolder : MonoBehaviour
{
    private static EventHolder _instance;
    public static EventHolder Instance
    {
        get
        {
            _instance = FindObjectOfType<EventHolder>();
            return _instance;
        }
        set { _instance = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }




    public Action<GameObject> OnPlayerMove;
    public Action<GameObject> OnPlayerJump;
    public Action<GameObject> OnPlayerRunToIdle;
    public Action<GameObject> OnPlayerHoldToIdle;
    public Action<GameObject> OnPlayerIdle;
    public Action<GameObject> OnPlayerHoldIdle;
    public Action<GameObject> OnPlayerHoldMove;
    public Action<GameObject> OnPlayerHoldMoveToHoldIdle;
    public Action<GameObject> OnPlayerRopeIdle;
    //public Action<GameObject> OnEraserPizza;
    //public Action<GameObject> OnSellPizza;
    //public Action<GameObject> OnFinishEvent;
    //public Action<GameObject> OnPlayerCustomerSaled;
    //public Action<GameObject> OnFinishLineEvent;
    //public Action<GameObject> OnCameraFollowChange;
    //public Action<GameObject> OnPizzaFallSpace;



    public void PlayerMoveStart(GameObject obj)
    {
        OnPlayerMove?.Invoke(obj);
    }

    public void PlayerJumpStart(GameObject obj)
    {
        OnPlayerJump?.Invoke(obj);
    }

    public void PlayerRunToIdle(GameObject obj)
    {
        OnPlayerRunToIdle?.Invoke(obj);
    }
    public void PlayerHoldToIdle(GameObject obj)
    {
        OnPlayerHoldToIdle?.Invoke(obj);
    }
    public void PlayerHoldIdleStart(GameObject obj)
    {
        OnPlayerHoldIdle?.Invoke(obj);
    }

    public void PlayerHoldMoveStart(GameObject obj)
    {
        OnPlayerHoldMove?.Invoke(obj);
    }
    public void PlayerHoldMoveToHoldIdle(GameObject obj)
    {
        OnPlayerHoldMoveToHoldIdle?.Invoke(obj);
    }
}
