using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public static class Helper_Methods{

    #region Populate Dropdown With Enum
    //This function can be used as follows:
    //Helper_Methods.Populate_Dropdown_With_Enum(ant_behaviour_drop_down, typeof(Ant_Behaviours))
    //Where (Ant_Behaviours) is the name of your enum
    public static void Populate_Dropdown_With_Enum(Dropdown dropdown, System.Type t)
    {        
        dropdown.ClearOptions();
        List<string> values = new List<string>();
        string[] temp = System.Enum.GetNames(t);
        for (int i = 0; i < temp.GetLength(0); i++)
        {
            values.Add(temp[i]);
        }
        dropdown.AddOptions(values);
    }
    #endregion
}
