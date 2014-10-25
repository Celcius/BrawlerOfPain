using UnityEngine;
using System.Collections;

public class BaseKeyboard {

    public KeyCode JUMP = KeyCode.None;
    public KeyCode UP = KeyCode.None;
    public KeyCode LEFT = KeyCode.None;
    public KeyCode RIGHT = KeyCode.None;
    public KeyCode DOWN = KeyCode.None;
	public KeyCode ACTION_1 = KeyCode.None;

    public static BaseKeyboard createDefaultKeyboard1()
    {
        BaseKeyboard kb = new BaseKeyboard();

        kb.JUMP = KeyCode.RightShift;
		kb.UP = KeyCode.UpArrow;
        kb.LEFT = KeyCode.LeftArrow;
        kb.RIGHT = KeyCode.RightArrow;
        kb.DOWN = KeyCode.DownArrow;
		kb.ACTION_1 = KeyCode.RightControl;

        return kb;
    }

    public static BaseKeyboard createDefaultKeyboard2()
    {
        BaseKeyboard kb = new BaseKeyboard();
        kb.JUMP = KeyCode.Z;
		kb.UP = KeyCode.W;
        kb.LEFT = KeyCode.A;
        kb.RIGHT = KeyCode.D;
        kb.DOWN = KeyCode.S;
		kb.ACTION_1 = KeyCode.X;
        return kb;
    }
}
