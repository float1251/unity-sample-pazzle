﻿using UnityEngine;
using System.Collections;

public class DebugScript : MonoBehaviour
{

    public GameObject block;

    public void FillBlock ()
    {
        for (int x=1; x<=10; x++) {
            for (int y=1; y<=20; y++) {
                Debug.Log (string.Format ("x:{0}, y:{1}", x, y));
                var go = Instantiate (block) as GameObject;
                go.name = GameUtils.GetBlockName (x, y);
                go.transform.position = GameUtils.ConvertIndexToWorldPoint (x, y);
            }
        }
    }

    public void DeleteAllBlock ()
    {
        var blocks = GameObject.FindGameObjectsWithTag ("Block");
        foreach (var block in blocks) {
            GameObject.Destroy (block);
        }
    }

    void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        int layerMask = (1 << LayerMask.NameToLayer ("Default"));
        if (Physics.Raycast (ray, 10, layerMask))
            print ("Hit something");

    }
}
