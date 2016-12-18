using UnityEngine;
using System.Collections;

public static class Extensions {

    #region Transform Extensions
    public static void SetX(this Transform tran, float x)
    {
        tran.position = new Vector3(x, tran.position.y, tran.position.z);
    }
    public static void SetY(this Transform tran, float y)
    {
        tran.position = new Vector3(tran.position.x, y, tran.position.z);
    }
    public static void SetZ(this Transform tran, float z)
    {
        tran.position = new Vector3(tran.position.x, tran.position.y, z);
    }
    #endregion
}
