using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLink : MonoBehaviour
{
    // Start is called before the first frame update
    public void openLinkURL()
    {
        Application.OpenURL("http://unity3d.com/");
    }
}
