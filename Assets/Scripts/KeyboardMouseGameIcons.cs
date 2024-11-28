using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Samples.RebindUI;
using static UnityEditor.PlayerSettings;
using NUnit.Framework.Internal.Builders;

namespace UnityEngine.InputSystem.Samples.RebindUI
{
    public class KeyboardMouseGameIcons : MonoBehaviour
    {
        public KeyboardMouseIcon icons;

        protected void OnEnable()
        {
            // Hook into all updateBindingUIEvents on all RebindActionUI components in our hierarchy.
            var rebindUIComponents = transform.GetComponentsInChildren<RebindActionUI>();
            foreach (var component in rebindUIComponents)
            {
                component.updateBindingUIEvent.AddListener(OnUpdateBindingDisplay);
                component.UpdateBindingDisplay();
            }
        }
        protected void OnUpdateBindingDisplay(RebindActionUI component, string bindingDisplayString, string deviceLayoutName, string controlPath)
        {
            if (string.IsNullOrEmpty(deviceLayoutName) || string.IsNullOrEmpty(controlPath))
                return;

            var icon = default(Sprite);
            if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Keyboard"))
                icon = icons.GetSprite(controlPath);

            var textComponent = component.bindingText;

            // Grab Image component.
            var imageGO = textComponent.transform.parent.Find("ActionBindingIcon");
            var imageComponent = imageGO.GetComponent<Image>();

            if (icon != null)
            {
                textComponent.gameObject.SetActive(false);
                imageComponent.sprite = icon;
                imageComponent.gameObject.SetActive(true);
            }
            else
            {
                textComponent.gameObject.SetActive(true);
                imageComponent.gameObject.SetActive(false);
            }
        }
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
                case "mouseLeft":
                    return mouseLeftKey;
                case "mouseMiddle":
                    return mouseMiddleKey;
                case "mouseRight":
                    return mouseRightKey;
                case "mouseScrollUp":
                    return mouseScrollUpKey;
                case "mouseScroll":
                    return mouseScrollKey;
                case "mouseScrollDown":
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
}

