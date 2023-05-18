using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropdownOption
{
    public string optionText;
    public UnityAction optionAction;

    public DropdownOption(string text, UnityAction action)
    {
        optionText = text;
        optionAction = action;
    }
}