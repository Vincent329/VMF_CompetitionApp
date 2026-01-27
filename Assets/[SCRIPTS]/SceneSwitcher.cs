using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchtoVR()
    {
        SceneManager.LoadScene("TMU");
    }
    public void SwitchtoQR()
    {
        SceneManager.LoadScene("QRScene");
    }
}
