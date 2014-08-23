using System.Collections;
using UnityEngine;

public class Utils
{

    /// <summary>
    /// Converts the index to world point.
    /// </summary>
    /// <returns>The index to world point.</returns>
    /// <param name="xIndex">X index. 1 - 10</param>
    /// <param name="yIndex">Y index. 1 - 20</param>
    public static Vector3 ConvertIndexToWorldPoint (int xIndex, int yIndex)
    {
        // when xIndex is 1, x is -4.5. xIndex is 10, 5.5
        var x = xIndex;
        var y = yIndex;
        return new Vector3 (x, y, 0);
    }

    public static string GetBlockName (int xIndex, int yIndex)
    {
        return "Block:" + xIndex + "," + yIndex;
    }

}
