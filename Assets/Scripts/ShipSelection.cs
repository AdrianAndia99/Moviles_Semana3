using UnityEngine;
public class ShipSelection : MonoBehaviour
{
    public ShipData[] availableShips;
    public static ShipData SelectedShip;

    public void SelectShip(int index)
    {
        if (index >= 0 && index < availableShips.Length)
        {
            SelectedShip = availableShips[index];
        }
    }
}