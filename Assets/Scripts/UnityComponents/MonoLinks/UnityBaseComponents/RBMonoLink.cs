using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RBMonoLink : MonoLink<RigidbodyLink>
{
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (Value.Value == null)
        {
            Value = new RigidbodyLink
            {
                Value = GetComponent<Rigidbody2D>()
            };
        }
    }
#endif
}
