using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    private GameObject block;
    public GameObject[] blocks;
    public Text text;
    public ScoreManager score;

    public int destroyBlockNum = 3;

    private float interval = 15;

    private int blockMoveFrame = 4;

    private bool checkNext = false;

    // Use this for initialization
    void Start ()
    {
        Time.captureFramerate = 30;
    }
	
    // Update is called once per frame
    void Update ()
    {

        if (checkNext) {
            checkNext = false;
            OnGround ();
        }

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
        // TODO CheckDismissBlock
        var blocks = GameObject.FindGameObjectsWithTag ("Block");
        ArrayList list = new ArrayList ();
        foreach (var b in blocks) {
            RaycastHit info;
            for (int x=-1; x<=1; x++) {
                for (int y=-1; y<=1; y++) {
                    int count = 1;
                    if (x == 0 && y == 0) // blockと同じポジションは比較しない
                        continue;
                    list.Add (b);
                    var pos = b.transform.position;
                    var next = true;
                    while (next) {
                        next = false;
                        pos.x += x;
                        pos.y += y;
                        var ray = Camera.main.ScreenPointToRay (Camera.main.WorldToScreenPoint (pos));
                        int layerMask = (1 << LayerMask.NameToLayer ("Default"));
                        if (Physics.Raycast (ray, out info, 10, layerMask)) { // blockがあった際
                            if (info.collider.gameObject.name == b.name) { // 同じ色かどうか
                                list.Add (info.collider.gameObject);
                                count++;
                                next = true;
                                Debug.Log ("Count: " + count);
                            } 
                        }
                    }

                    if (count >= destroyBlockNum) {
                        foreach (GameObject g in list) {
                            g.GetComponent<BlockController> ().willDestroy = true;
                            Debug.Log (g.name);
                        }
                        score.Score += count;
                    }
                    list.Clear ();
                }
            }
        }
        block = null;


        // Destroy Block
        foreach (var b in blocks) {
            if (b.GetComponent<BlockController> ().willDestroy) {
                checkNext = true;
                GameObject.Destroy (b);
                // TOOD donw block
                var pos = b.transform.position;
                var next = true;
                while (next) {
                    next = false;
                    pos.y += 1;
                    var ray = Camera.main.ScreenPointToRay (Camera.main.WorldToScreenPoint (pos));
                    int layerMask = (1 << LayerMask.NameToLayer ("Default"));
                    RaycastHit info;
                    if (Physics.Raycast (ray, out info, 10, layerMask)) { // blockがあった際
                        info.collider.transform.Translate (Vector3.down);
                        next = true;
                    }
                }
            }
        }
    }
}
