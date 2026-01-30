using UnityEngine;

public class ToggleInstructions : MonoBehaviour
{
    [SerializeField]
    private GameObject instructions;

   public void showInstructions()
   {
        if (instructions != null)
        {
            instructions.SetActive(!instructions.activeSelf);
        }
   }
}
