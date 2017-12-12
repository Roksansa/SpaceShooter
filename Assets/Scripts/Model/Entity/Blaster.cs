using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Interface;
using UnityEngine;
/// <summary>
/// Это само оружие, которое может стрелять
/// </summary>
public class Blaster : MonoBehaviour, IBlaster{
  public Model.Pooling.Blaster Type {
    get { return type; } set { type = value; }}
  [SerializeField] private Model.Pooling.Blaster type;
  [SerializeField] private float intervalTime;
  private float curTime;
  private Transform transformCache;
  public Transform TransformCache {
    get { return transformCache; }
  }

  private void Awake() {
    Type = type;
    transformCache = transform;
  }

  private void Update() {
    curTime += Time.deltaTime;
  }

  public void Fire() {
    //когда последний раз вызывался метод
    if (curTime >= intervalTime) {
      curTime = 0;
      GameController.StaticObject.BlasterPool.Create(this);
    }
  }
}