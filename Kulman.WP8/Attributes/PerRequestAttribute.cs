using System;

namespace Kulman.WP8.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class PerRequestAttribute : Attribute
	{
	}
}