using UnityEngine;
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
                go.name = Utils.GetBlockName (x, y);
                go.transform.position = Utils.ConvertIndexToWorldPoint (x, y);
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
}
