using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Click : MonoBehaviour
{
    [SerializeField]
    Button b;

    public void SimulateClick()
    {
        b.onClick.Invoke();
    }
}
