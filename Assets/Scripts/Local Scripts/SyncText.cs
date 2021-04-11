using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class SyncText : NetworkBehaviour
{
    public GameObject message;
    public GameObject timer;

    [SyncVar(hook = nameof(textChanged))]
    public string stringMode = "Waiting For Players";

    [SyncVar(hook = nameof(timeChanged))]
    public int countdown = 600;

    void textChanged(string oldMes, string newMes)
    {
        message.GetComponent<TMP_Text>().text = newMes;
    }

    void timeChanged(int oldMes, int newMes)
    {
        timer.GetComponent<TMP_Text>().text = "0" + (newMes / 60).ToString() + ":" + ((newMes % 60) < 10 ? "0" : "") + (newMes % 60).ToString();
    }
}
