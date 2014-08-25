using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour
{

    public bool willDestroy;

    // Use this for initialization
    void Start ()
    {
	
    }
	
    // Update is called once per frame
    void Update ()
    {
	
    }

    public void MoveBlock (KeyCode type)
    {
        Vector3 v = Vector3.zero;
        switch (type) {
        case KeyCode.LeftArrow:
            v = Vector3.left;
            break;
        case KeyCode.RightArrow:
            v = Vector3.right;
            break;
        case KeyCode.DownArrow:
            v = Vector3.down;
            break;
        }

        transform.Translate (v);

        if (transform.position.x < 1 || transform.position.x > 10) {
            transform.Translate (-v);
        }

        // TODO hit check
        var blocks = GameObject.FindGameObjectsWithTag ("Block");
        foreach (var block in blocks) {
            if (block.GetInstanceID () != gameObject.GetInstanceID () && block.transform.position.Equals (transform.position)) {
                transform.Translate (-v);
                if (type == KeyCode.DownArrow)
                    gameObject.transform.parent.GetComponent<GameController> ().OnGround ();
            } else if (gameObject.transform.position.y == 0) {
                transform.Translate (-v);
                if (type == KeyCode.DownArrow)
                    gameObject.transform.parent.GetComponent<GameController> ().OnGround ();
            }
        }

    }


    public void RotateBlock ()
    {
        // TODO Rotate
    }

}
