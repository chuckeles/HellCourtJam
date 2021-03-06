﻿using UnityEngine;

/// <summary>
///   Hurts human on fall.
/// </summary>
[RequireComponent(typeof (Sinner))]
public class FallDamage : MonoBehaviour {

  public void Awake() {
    // set things
    _sinner = GetComponent<Sinner>();
    _manager = FindObjectOfType<LevelManager>();
  }

  public void OnCollisionEnter2D(Collision2D collision) {
    if (!_firstIgnored) {
      // spawn fall
      _firstIgnored = true;
      return;
    }

    // calculate pain
    var pain = collision.relativeVelocity.magnitude;
    pain -= 200f;
    pain /= 150f;
    pain = Mathf.Clamp(pain, 0, float.MaxValue);

    // apply pain
    _sinner.PhysicalPain += pain * _manager.PainMultiplier;
  }

  /// <summary>
  ///   Ignore first fall (spawn).
  /// </summary>
  private bool _firstIgnored;

  /// <summary>
  ///   The level manager.
  /// </summary>
  private LevelManager _manager;

  /// <summary>
  ///   Sinner component.
  /// </summary>
  private Sinner _sinner;

}
