using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    private GameObject block;
    public GameObject[] blocks;
    public Text text;

    private float interval = 15;

    private int blockMoveFrame = 4;

    // Use this for initialization
    void Start ()
    {
        Time.captureFramerate = 30;
    }
	
    // Update is called once per frame
    void Update ()
    {
        // not have block, make next block;
        if (block == null) {
            block = CreateBlock ();
            block.transform.parent = gameObject.transform;
        }

        if (Time.frameCount % blockMoveFrame == 0)
            CheckInput ();

        if (Time.frameCount % interval == 0) {
            if (block != null)
                block.GetComponent<BlockController> ().MoveBlock (KeyCode.DownArrow);
        }

        text.text = "Time: " + Time.realtimeSinceStartup;

    }

    void CheckInput ()
    {
        if (Input.GetKey (KeyCode.LeftArrow)) {
            block.GetComponent<BlockController> ().MoveBlock (KeyCode.LeftArrow);
        } else if (Input.GetKey (KeyCode.RightArrow)) {
            block.GetComponent<BlockController> ().MoveBlock (KeyCode.RightArrow);
        } else if (Input.GetKey (KeyCode.DownArrow)) {
            block.GetComponent<BlockController> ().MoveBlock (KeyCode.DownArrow);
        }

    }

    /// <summary>
    /// Gets the block.
    /// </summary>
    /// <returns>The block.</returns>
    public GameObject CreateBlock ()
    {
        var index = Random.Range (0, blocks.Length - 1);
        var ret = Instantiate (blocks [index]) as GameObject;
        ret.transform.position = GameUtils.ConvertIndexToWorldPoint (4, 20);
        return ret;
    }

    public void OnGround ()
    {
        block = null;
        // TODO CheckDismissBlock
        //var blocks = GameObject.FindGameObjectsWithTag ("Block");


    }
}
