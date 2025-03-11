namespace MageSurvivor.Code.Test
{
    using UnityEngine;

    public class TestInput : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key was pressed.");
            }
        }
    }
}