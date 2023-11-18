using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad { 
    public class KeypadInteractionFPV : MonoBehaviour
    {
        private Transform player;
        private Transform keypad;
        public float playerDistance;

        private Keypad keypadObject;
        private KeypadButton btn0;
        private KeypadButton btn1;
        private KeypadButton btn2;
        private KeypadButton btn3;
        private KeypadButton btn4;
        private KeypadButton btn5;
        private KeypadButton btn6;
        private KeypadButton btn7;
        private KeypadButton btn8;
        private KeypadButton btn9;
        private KeypadButton btnEnter;

        private void Start()
        {
            player = GameObject.Find("Player").transform;
            keypad = GameObject.Find("KeypadStandard").transform;
            keypadObject = GameObject.Find("KeypadStandard").GetComponent<Keypad>();
            btn0 = GameObject.Find("bttn0").GetComponent<KeypadButton>();
            btn1 = GameObject.Find("bttn1").GetComponent<KeypadButton>();
            btn2 = GameObject.Find("bttn2").GetComponent<KeypadButton>();
            btn3 = GameObject.Find("bttn3").GetComponent<KeypadButton>();
            btn4 = GameObject.Find("bttn4").GetComponent<KeypadButton>();
            btn5 = GameObject.Find("bttn5").GetComponent<KeypadButton>();
            btn6 = GameObject.Find("bttn6").GetComponent<KeypadButton>();
            btn7 = GameObject.Find("bttn7").GetComponent<KeypadButton>();
            btn8 = GameObject.Find("bttn8").GetComponent<KeypadButton>();
            btn9 = GameObject.Find("bttn9").GetComponent<KeypadButton>();
            btnEnter = GameObject.Find("bttnEnter").GetComponent<KeypadButton>();
        }

        void Update()
        {
            playerDistance = Vector3.Distance(player.position, keypad.position);
            if (playerDistance <= 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    btn0.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    btn1.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    btn2.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    btn3.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    btn4.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    btn5.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    btn6.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    btn7.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    btn8.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    btn9.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Return))
                {
                    btnEnter.PressButton();
                }
                else if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    keypadObject.ClearInput();
                }
            }
        }
    }
}