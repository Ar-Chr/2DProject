using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntConstants
{
    #region Layers
    public static int PlatformLayer = LayerMask.NameToLayer(StringConstants.PlatformLayerName);
    public static int PlayerLayer = LayerMask.NameToLayer(StringConstants.PlayerLayerName);
    #endregion
}
