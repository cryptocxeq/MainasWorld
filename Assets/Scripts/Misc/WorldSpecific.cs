using UnityEngine;

public class WorldSpecific : MonoBehaviour
{
    [SerializeField] private World world = World.Real;
    // Start is called before the first frame update
    private void Start()
    {
        EventManager.Instance.OnWorldChange += (World w) => { GetComponent<Collider2D>().enabled = world == w; };
    }
}
