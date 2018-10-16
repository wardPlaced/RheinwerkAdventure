using System;
namespace ProjectNew.Model
{
	internal interface ICollidable
	{
		float Mass { get; }
		bool Fixed { get; }
    }
}
