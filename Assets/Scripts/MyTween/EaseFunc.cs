using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTween
{
	public enum EaseType
	{
		Linear,
		InSine,
		OutSine,
		InOutSine,
		InBack,
		OutBack,
		InOutBack,
	}

	public class EaseFunc
	{
		public static float func(EaseType type, float t)
		{
			switch (type)
			{
				case EaseType.Linear:
					return FuncLinear(t);
				case EaseType.InSine:
					return FuncInSine(t);
				case EaseType.OutSine:
					return FuncOutSine(t);
				case EaseType.InOutSine:
					return FuncInOutSine(t);
				case EaseType.InBack:
					return FuncInBack(t);
				case EaseType.OutBack:
					return FuncOutBack(t);
				case EaseType.InOutBack:
					return FuncInOutBack(t);
				default:
					return FuncLinear(t);
			}
		}


		public static float FuncLinear(float t)
		{
			return t;
		}

		public static float FuncInSine(float t)
		{
			return 1 - Mathf.Cos((t * Mathf.PI) * 0.5f);
		}
		public static float FuncOutSine(float t)
		{
			return Mathf.Sin((t * Mathf.PI) * 0.5f);
		}
		public static float FuncInOutSine(float t)
		{
			return -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
		}
		public static float FuncInBack(float t)
		{
			float v1 = 1.70158f;
			float v2 = v1 + 1;
			return v2 * t * t * t - v1 * t * t;
		}

		public static float FuncOutBack(float t)
		{
			float v1 = 1.70158f;
			float v2 = v1 + 1;
			return 1 + v2 * Mathf.Pow(t - 1, 3) + v1 * Mathf.Pow(t - 1, 2);
		}

		public static float FuncInOutBack(float t)
		{
			float v1 = 1.70158f;
			float v2 = v1 * 1.525f;
			if (t < 0.5f)
			{
				return (Mathf.Pow(2 * t, 2) * ((v2 + 1) * 2 * t - v2)) / 2;
			}
			else
			{
				return (Mathf.Pow(2 * t - 2, 2) * ((v2 + 1) * (t * 2 - 2) + v2) + 2) / 2;
			}
		}
	}
}
