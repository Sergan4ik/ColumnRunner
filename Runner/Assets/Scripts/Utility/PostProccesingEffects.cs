using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProccesingEffects : MonoBehaviour
{
   public static PostProccesingEffects instance;
   public Volume volume;
   [Header("Damage Vignet effects")] 
   public Color vigneteColor;
   public float intencity, smoothnes;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   public void DamageEffect()
   {
      Vignette vignette;
      volume.profile.TryGet(out vignette);
      ColorParameter startColor = vignette.color;
      float startInt = vignette.intensity.value, startSmooth = vignette.smoothness.value;
   }
}
