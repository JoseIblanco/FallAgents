using System.Collections;
using UnityEngine;

public class Swiper : MonoBehaviour
{
    public enum SwipeDirection
    {
        Clockwise = 1, CounterClockwise = -1, Random = 0
    }

    public SwipeDirection Direction = SwipeDirection.Random;
    public float MinSpeed = 50f;
    public float MaxSpeed = 100f;
    private float m_SwipeSpeed = 0f;

    private void Start()
    {
        float speed = Random.Range(MinSpeed, MaxSpeed);
        float startingRotation = Random.Range(0f, 360f);
        transform.Rotate(0f, startingRotation, 0f, Space.Self);
        m_SwipeSpeed = (Direction != SwipeDirection.Random) ? speed * (int)Direction : speed * (Random.Range(0, 2) == 0 ? -1 : 1);
        StartCoroutine(Swipe());
    }

    private IEnumerator Swipe()
    {
        while (true)
        {
            transform.Rotate(Vector3.up * m_SwipeSpeed * Time.deltaTime, Space.Self);
            yield return null;
        }
    }
}
