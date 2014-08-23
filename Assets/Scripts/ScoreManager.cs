using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    public Text text;
    private int _score;
    public int Score {
        get {
            return _score;
        }
        set {
            this._score = value;
            text.text = "Score: " + this._score;
        }
    }

}
