using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StateMachine : MonoBehaviour, IPointerClickHandler
{
    public bool clickable;
    private BaseState state;
    public int unitType;

    public void SetState(BaseState newState)
    {
        state = newState;
        state.SetContext(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetState(new RunState());
    }

    // Update is called once per frame
    void Update()
    {
        state.Update();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        state.OnClick();
    }
}
