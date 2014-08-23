using System.Collections;
using UnityEngine;

public class GameUtils: MonoBehaviour
{

    /// <summary>
    /// Converts the index to world point.
    /// </summary>
    /// <returns>The index to world point.</returns>
    /// <param name="xIndex">X index. 1 - 10</param>
    /// <param name="yIndex">Y index. 1 - 20</param>
    public static Vector3 ConvertIndexToWorldPoint (int xIndex, int yIndex)
    {
        var x = xIndex;
        var y = yIndex;
        return new Vector3 (x, y, 0);
    }

    /// <summary>
    /// Gets the name of the block.
    /// </summary>
    /// <returns>The block name.</returns>
    /// <param name="xIndex">X index.</param>
    /// <param name="yIndex">Y index.</param>
    public static string GetBlockName (int xIndex, int yIndex)
    {
        return "Block:" + xIndex + "," + yIndex;
    }

}
