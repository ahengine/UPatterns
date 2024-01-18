using UnityEngine;

namespace UPatterns.Test
{
    public class UStateRuntime : MonoBehaviour
    {
        private void Update() {

            if (Input.GetKeyDown(KeyCode.Alpha1))
                ProfileController.Instance.SetData();

            if (Input.GetKeyDown(KeyCode.Alpha2))
                ProfileController.Instance.GetData();
        }
    }
}