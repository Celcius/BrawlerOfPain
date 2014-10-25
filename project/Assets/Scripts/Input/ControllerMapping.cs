using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerMapping {

    public enum CONTROLLERS
    {
        GAMEPAD_1=0,
        GAMEPAD_2=1,
		GAMEPAD_3=2,
		GAMEPAD_4=3,
        KEYBOARD_1=5,
        KEYBOARD_2=6,
    }

    public static Dictionary<CONTROLLERS, BaseKeyboard> Keyboards;

    static ControllerMapping()
    {
        Keyboards = new Dictionary<CONTROLLERS, BaseKeyboard>();
        Keyboards.Add(CONTROLLERS.KEYBOARD_1, BaseKeyboard.createDefaultKeyboard1());
        Keyboards.Add(CONTROLLERS.KEYBOARD_2, BaseKeyboard.createDefaultKeyboard2());
    }
	
}
