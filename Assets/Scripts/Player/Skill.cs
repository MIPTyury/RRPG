using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public KeyCode skillKey;

    public abstract void Activate();
}
