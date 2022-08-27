/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SampleMessageListener : MonoBehaviour
{
    // Invoked when a line of data is received from the serial device.

    public CharacterInputController inputController;
    public LoadoutState loadout;

    public bool started = false;

    string last = "";

    void OnMessageArrived(string msg)
    {
        if (loadout && !started)
        {
            loadout.StartGame();
            started = true;
        }

        if (inputController)
        {
            if (!String.IsNullOrEmpty(msg))
                msg = msg.Substring(0, 1);

            inputController.ExternalController(msg);
        }
    }
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }


}
