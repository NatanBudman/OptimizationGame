using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManagerUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateManager.Instance.add(this);
    }

    public void UpdateUI()
    {
    }
}
