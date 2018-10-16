using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class KeyboardEnabler : MonoBehaviour {

    [SerializeField] InputField _hideableInputField;

    private void Start()
    {
        _hideableInputField = GetComponent<InputField>();
        _hideableInputField.touchScreenKeyboard.active = false;
        _hideableInputField.keyboardType = (TouchScreenKeyboardType)(-1);
    }

}
