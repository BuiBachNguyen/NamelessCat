using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : MonoBehaviour
{
    [SerializeField] _AudioManager _audio;

    [SerializeField]  Vector3 fallOffset = new Vector3(0, -2f, 0); // Khoảng cách bẫy sập xuống
    [SerializeField]  float fallDuration = 0.5f; // Thời gian sập xuống
    [SerializeField]  float pauseDuration = 2f; // Thời gian dừng lại ở vị trí sập
    [SerializeField]  float liftDuration = 1f; // Thời gian nâng lên
    [SerializeField]  float cycleDelay = 1.5f; // Thời gian nghỉ trước khi lặp lại chu kỳ
    [SerializeField]  float waitFirst = 0; // thời gian chờ trước khi bắt đầu trap cir để tọa partern 

    private Vector3 initialPosition;
    private Vector3 fallPosition;

    void Start()
    {
        _audio = _AudioManager.Instance;
        initialPosition = transform.position;
        fallPosition = initialPosition + fallOffset;
        StartCoroutine(TrapCycle());
    }

    IEnumerator TrapCycle()
    {
        yield return new WaitForSeconds(waitFirst);
        while (true)
        {
            // Sập xuống trong fallDuration (0.5 giây)
            yield return MoveTrap(initialPosition, fallPosition, fallDuration);
            _audio.PlaySFX(_audio.TrapFall);

            // Dừng lại 2 giây
            yield return new WaitForSeconds(pauseDuration);

            // Rút lên trong liftDuration (1 giây)
            yield return MoveTrap(fallPosition, initialPosition, liftDuration);

            // Nghỉ 1.5 giây trước khi bắt đầu lại chu kỳ
            yield return new WaitForSeconds(cycleDelay);
        }
    }

    IEnumerator MoveTrap(Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = end; // Đảm bảo vị trí chính xác khi kết thúc
    }
}
