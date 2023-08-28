using UnityEngine;

namespace AHGenericPatterns.Test
{
    public class PoolRuntimeTest : MonoBehaviour
    {
        [SerializeField] private Pool<Transform> pool;

        private void Start() =>
            Time.timeScale = 1;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Spawn();
        }

        private void Spawn()
        {
            var item = pool.GetActive;
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            StartCoroutine(Killer(item.gameObject));
        }

        private System.Collections.IEnumerator Killer(GameObject obj,float time = 2)
        {
            yield return new WaitForSeconds(time);
            obj.SetActive(false);
        }
    } 
}
