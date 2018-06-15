﻿using System.Collections.Generic;
using UnityEngine;

public interface IRewindable
{
	bool IsRewinding { get; }
	bool HadSomethingToRewindToAtFrameStart { get; }
	int LogCount { get; }

	void Init(VelocityController velocityController, SpinController spinController);
	void Reset();
	void EnqueueEvent(IRewindableEvent evt, bool recordImmediately = false);
}

public struct TransformData
{
	public TransformData(Vector3 pos, Quaternion rot, List<IRewindableEvent> evts)
	{
		position = pos;
		rotation = rot;
		events = evts.ToArray();
	}

	public readonly Vector3 position;
	public readonly Quaternion rotation;
	public readonly IRewindableEvent[] events;
}