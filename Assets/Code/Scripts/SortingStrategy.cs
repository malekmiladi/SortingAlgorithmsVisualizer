using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISortingStrategy
{
    // Start is called before the first frame update
    IEnumerator Sort(GameVariables gv);
}
