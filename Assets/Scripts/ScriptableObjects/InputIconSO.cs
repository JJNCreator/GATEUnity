using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InputIconSO", menuName = "Input Icons SO")]
public class InputIconSO : ScriptableObject
{
    public KeyboardMouseIcon mkIcons;
    public GamepadIcons xboxIcons;
    public GamepadIcons dsIcons;
    public GamepadIcons nSwitchIcons;
}
[Serializable]
public struct KeyboardMouseIcon
{
    public Sprite zeroKey;
    public Sprite oneKey;
    public Sprite twoKey;
    public Sprite threeKey;
    public Sprite fourKey;
    public Sprite fiveKey;
    public Sprite sixKey;
    public Sprite sevenKey;
    public Sprite eightKey;
    public Sprite nineKey;
    public Sprite aKey;
    public Sprite altKey;
    public Sprite asteriskKey;
    public Sprite bKey;
    public Sprite backspaceAltKey;
    public Sprite backspaceKey;
    public Sprite bracketsLKey;
    public Sprite bracketsRKey;
    public Sprite cKey;
    public Sprite capsLockKey;
    public Sprite ctrlKey;
    public Sprite dKey;
    public Sprite deleteKey;
    public Sprite deltaKey;
    public Sprite downKey;
    public Sprite eKey;
    public Sprite endKey;
    public Sprite enterAltKey;
    public Sprite enterKey;
    public Sprite enterTallKey;
    public Sprite escKey;
    public Sprite f1Key;
    public Sprite f2Key;
    public Sprite f3Key;
    public Sprite f4Key;
    public Sprite f5Key;
    public Sprite f6Key;
    public Sprite f7Key;
    public Sprite f8Key;
    public Sprite f9Key;
    public Sprite f10Key;
    public Sprite f11Key;
    public Sprite f12Key;
    public Sprite fKey;
    public Sprite gKey;
    public Sprite hKey;
    public Sprite homeKey;
    public Sprite iKey;
    public Sprite insKey;
    public Sprite jKey;
    public Sprite kKey;
    public Sprite carrotRightKey;
    public Sprite carrotLeftKey;
    public Sprite lKey;
    public Sprite leftArrowKey;
    public Sprite mKey;
    public Sprite minusKey;
    public Sprite mouseLeftKey;
    public Sprite mouseMiddleKey;
    public Sprite mouseRightKey;
    public Sprite mouseScrollDown;
    public Sprite mouseScrollKey;
    public Sprite mouseScrollUpKey;
    public Sprite mouseSimpleKey;
    public Sprite mouseXKey;
    public Sprite mouseXY;
    public Sprite mouseYKey;
    public Sprite nKey;
    public Sprite numLockKey;
    public Sprite oKey;
    public Sprite pKey;
    public Sprite pageDownKey;
    public Sprite pageUpKey;
    public Sprite plusKey;
    public Sprite plusTallKey;
    public Sprite prtScrnKey;
    public Sprite qKey;
    public Sprite questionMarkKey;
    public Sprite quotationKey;
    public Sprite rKey;
    public Sprite rightArrowKey;
    public Sprite sKey;
    public Sprite semicolonKey;
    public Sprite shiftKey;
    public Sprite shiftSuperwideKey;
    public Sprite slashKey;
    public Sprite spaceKey;
    public Sprite tKey;
    public Sprite tabKey;
    public Sprite tildeKey;
    public Sprite uKey;
    public Sprite upKey;
    public Sprite vKey;
    public Sprite wKey;
    public Sprite xKey;
    public Sprite yKey;
    public Sprite zKey;

    public Sprite GetSprite(string controlPath)
    {
        switch (controlPath)
        {
            case "0":
                return zeroKey;
            case "1":
                return oneKey;
            case "2":
                return twoKey;
            case "3":
                return threeKey;
            case "4":
                return fourKey;
            case "5":
                return fiveKey;
            case "6":
                return sixKey;
            case "7":
                return sevenKey;
            case "8":
                return eightKey;
            case "9":
                return nineKey;
            case "a":
                return aKey;
            case "alt":
                return altKey;
            case "asterisk":
                return asteriskKey;
            case "b":
                return bKey;
            case "backspaceAlt":
                return backspaceAltKey;
            case "backspace":
                return backspaceKey;
            case "[":
                return bracketsLKey;
            case "]":
                return bracketsRKey;
            case "c":
                return cKey;
            case "capslock":
                return capsLockKey;
            case "ctrl":
                return ctrlKey;
            case "d":
                return dKey;
            case "delete":
                return deleteKey;
            case "delta":
                return deltaKey;
            case "downArrow":
                return downKey;
            case "e":
                return eKey;
            case "end":
                return endKey;
            case "enteralt":
                return enterAltKey;
            case "enter":
                return enterKey;
            case "enterTall":
                return enterTallKey;
            case "escape":
                return escKey;
            case "f":
                return fKey;
            case "f1":
                return f1Key;
            case "f2":
                return f2Key;
            case "f3":
                return f3Key;
            case "f4":
                return f4Key;
            case "f5":
                return f5Key;
            case "f6":
                return f6Key;
            case "f7":
                return f7Key;
            case "f8":
                return f8Key;
            case "f9":
                return f9Key;
            case "f10":
                return f10Key;
            case "f11":
                return f11Key;
            case "f12":
                return f12Key;
            case "g":
                return gKey;
            case "h":
                return hKey;
            case "home":
                return homeKey;
            case "i":
                return iKey;
            case "insert":
                return insKey;
            case "j":
                return jKey;
            case "k":
                return kKey;
            case "<":
                return carrotLeftKey;
            case ">":
                return carrotRightKey;
            case "l":
                return lKey;
            case "leftArrow":
                return leftArrowKey;
            case "m":
                return mKey;
            case "-":
                return minusKey;
            case "leftButton":
                return mouseLeftKey;
            case "middleButton":
                return mouseMiddleKey;
            case "rightButton":
                return mouseRightKey;
            case "/Mouse/scroll/up":
                return mouseScrollUpKey;
            case "/Mouse/scroll/x":
                return mouseScrollKey;
            case "/Mouse/scroll/down":
                return mouseScrollDown;
            case "mouseSimple":
                return mouseSimpleKey;
            case "mouseX":
                return mouseXKey;
            case "mouseXY":
                return mouseXY;
            case "mouseY":
                return mouseYKey;
            case "n":
                return nKey;
            case "numLock":
                return numLockKey;
            case "o":
                return oKey;
            case "p":
                return pKey;
            case "pageDown":
                return pageDownKey;
            case "pageUp":
                return pageUpKey;
            case "+":
                return plusKey;
            case "+tall":
                return plusTallKey;
            case "prntScrn":
                return prtScrnKey;
            case "q":
                return qKey;
            case "?":
                return questionMarkKey;
            case "'":
                return quotationKey;
            case "r":
                return rKey;
            case "rightArrow":
                return rightArrowKey;
            case "s":
                return sKey;
            case ";":
                return semicolonKey;
            case "shift":
                return shiftKey;
            case "shiftSuperwide":
                return shiftSuperwideKey;
            case "/":
                return slashKey;
            case "space":
                return spaceKey;
            case "t":
                return tKey;
            case "tab":
                return tabKey;
            case "~":
                return tildeKey;
            case "u":
                return uKey;
            case "upArrow":
                return upKey;
            case "v":
                return vKey;
            case "w":
                return wKey;
            case "x":
                return xKey;
            case "y":
                return yKey;
            case "z":
                return zKey;
        }
        return null;
    }
}
[Serializable]
public struct GamepadIcons
{
    public Sprite buttonSouth;
    public Sprite buttonNorth;
    public Sprite buttonEast;
    public Sprite buttonWest;
    public Sprite startButton;
    public Sprite selectButton;
    public Sprite leftTrigger;
    public Sprite rightTrigger;
    public Sprite leftShoulder;
    public Sprite rightShoulder;
    public Sprite dpad;
    public Sprite dpadUp;
    public Sprite dpadDown;
    public Sprite dpadLeft;
    public Sprite dpadRight;
    public Sprite leftStick;
    public Sprite rightStick;
    public Sprite leftStickPress;
    public Sprite rightStickPress;
    public Sprite leftStickUp;
    public Sprite rightStickUp;
    public Sprite leftStickDown;
    public Sprite rightStickDown;
    public Sprite leftStickRight;
    public Sprite rightStickRight;
    public Sprite leftStickLeft;
    public Sprite rightStickLeft;

    public Sprite GetSprite(string controlPath)
    {
        switch (controlPath)
        {
            case "buttonSouth": return buttonSouth;
            case "buttonNorth": return buttonNorth;
            case "buttonEast": return buttonEast;
            case "buttonWest": return buttonWest;
            case "start": return startButton;
            case "select": return selectButton;
            case "leftTrigger": return leftTrigger;
            case "rightTrigger": return rightTrigger;
            case "leftShoulder": return leftShoulder;
            case "rightShoulder": return rightShoulder;
            case "dpad": return dpad;
            case "dpad/up": return dpadUp;
            case "dpad/down": return dpadDown;
            case "dpad/left": return dpadLeft;
            case "dpad/right": return dpadRight;
            case "leftStick": return leftStick;
            case "rightStick": return rightStick;
            case "leftStickPress": return leftStickPress;
            case "rightStickPress": return rightStickPress;
            case "leftStick/up": return leftStickUp;
            case "rightStick/up": return rightStickUp;
            case "leftStick/down": return leftStickDown;
            case "rightStick/down": return rightStickDown;
            case "leftStick/right": return leftStickRight;
            case "rightStick/right": return rightStickRight;
            case "leftStick/left": return leftStickLeft;
            case "rightStick/left": return rightStickLeft;
        }
        return null;
    }
}
