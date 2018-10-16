using UnityEngine.UI;
using UnityEngine;

public class CustomInputField : InputField
{

    protected override void Start()
    {
        keyboardType = (UnityEngine.TouchScreenKeyboardType)(-1);
        base.Start();
    }
}
