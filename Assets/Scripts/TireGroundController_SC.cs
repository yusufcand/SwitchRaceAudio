using System.Collections;
using UnityEngine;

public class TireGroundController_SC : MonoBehaviour
{
    public TireMovement_SC tiresc;
    private Coroutine groundCheckCoroutine;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            tiresc.isGrounded = true;
            //Debug.Log("Tire is grounded: " + tiresc.isGrounded);

            // Daha �nce �al��an bir coroutine varsa onu iptal ediyoruz
            if (groundCheckCoroutine != null)
            {
                StopCoroutine(groundCheckCoroutine);
                groundCheckCoroutine = null;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Coroutine ba�lat�yoruz ve 0.5 saniye bekliyoruz
            if (groundCheckCoroutine == null)
            {
                groundCheckCoroutine = StartCoroutine(CheckGroundedAfterDelay());
            }
        }
    }

    private IEnumerator CheckGroundedAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);

        // 0.5 saniye sonra hala zeminde de�ilse, grounded durumunu false yap
        if (!Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground")))
        {
            tiresc.isGrounded = false;
            //Debug.Log("Tire is grounded: " + tiresc.isGrounded);
        }

        groundCheckCoroutine = null;
    }
}