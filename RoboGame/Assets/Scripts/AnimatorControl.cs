using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    private void OnEnable()
    {
        EventHolder.Instance.OnPlayerMove += PlayerMoveAnim;
        EventHolder.Instance.OnPlayerJump += PlayerJumAnim;
        EventHolder.Instance.OnPlayerRunToIdle += PlayerRunToIdle;
        EventHolder.Instance.OnPlayerIdle += PlayerIdleAnim;
        EventHolder.Instance.OnPlayerHoldIdle += PlayerHoldIdleAnim;
        EventHolder.Instance.OnPlayerHoldToIdle += PlayerHoldToIdleAnim;
        EventHolder.Instance.OnPlayerHoldMove += PlayerHolMoveAnim;
        EventHolder.Instance.OnPlayerHoldMoveToHoldIdle += PlayerHolMoveToHoldIdleAnim;
    }

    private void PlayerHolMoveToHoldIdleAnim(GameObject obj)
    {
        PlayerMovement.Instance.anim.SetBool("holdMove", false);
    }

    private void PlayerHolMoveAnim(GameObject obj)
    {
        PlayerMovement.Instance.anim.SetBool("holdMove", true);
    }

    private void PlayerHoldToIdleAnim(GameObject obj)
    {
        PlayerMovement.Instance.anim.SetBool("hold", false);
    }

    private void PlayerIdleAnim(GameObject obj)
    {
        throw new NotImplementedException();
    }






    #region Run-Animation
    private void PlayerMoveAnim(GameObject obj)
        {
            PlayerMovement.Instance.anim.SetFloat("run",PlayerMovement.Instance.customMagnitude);
        }
    #endregion

    #region Jump-Animation
        private void PlayerJumAnim(GameObject obj)
        {
            PlayerMovement.Instance.anim.SetTrigger("jump");
        }
    #endregion

    #region RunToIdle
        private void PlayerRunToIdle(GameObject obj)
        {
        PlayerMovement.Instance.anim.SetFloat("run", PlayerMovement.Instance.customMagnitude);
        

    }
    #endregion

    #region HoldIdle-Animation
    private void PlayerHoldIdleAnim(GameObject obj)
    {
        PlayerMovement.Instance.anim.SetBool("hold",true);
    }
    #endregion

}
