//
// RealTimeSignumTests.cs - NUnit Test Cases for Mono.Unix.Native.RealTimeSignum
//
// Authors:
//	Tim Jenks  <tim.jenks@realtimeworlds.com>
//
// (C) 2008 Realtime Worlds Ltd
//

using NUnit.Framework;
#if !MONODROID
using NUnit.Framework.SyntaxHelpers;
#endif
using System;
using System.Text;
using System.Threading;
using Mono.Unix;
using Mono.Unix.Native;

namespace MonoTests.Mono.Unix.Native {

	[TestFixture]
	[Category ("NotOnMac")]
	public class RealTimeSignumTest 
	{
		[Test]
		[ExpectedException (typeof (ArgumentOutOfRangeException))]
		public void TestRealTimeOutOfRange ()
		{
			RealTimeSignum rts = new RealTimeSignum (int.MaxValue);
		}

		[Test]
		[ExpectedException (typeof (ArgumentOutOfRangeException))]
		public void TestRealTimeSignumNegativeOffset ()
		{
			RealTimeSignum rts1 = new RealTimeSignum (-1);
		}

		[Test]
		public void TestRTSignalEquality ()
		{
			RealTimeSignum rts1 = new RealTimeSignum (0);
			RealTimeSignum rts2 = new RealTimeSignum (0);
			Assert.That (rts1 == rts2, Is.True);
			Assert.That (rts1 != rts2, Is.False);
		}

		[Test]
		public void TestRTSignalInequality ()
		{
			RealTimeSignum rts1 = new RealTimeSignum (0);
			RealTimeSignum rts2 = new RealTimeSignum (1);
			Assert.That (rts1 == rts2, Is.False);
			Assert.That (rts1 != rts2, Is.True);
		}

		[Test]
		public void TestRTSignalGetHashCodeEquality ()
		{
			RealTimeSignum rts1 = new RealTimeSignum (0);
			RealTimeSignum rts2 = new RealTimeSignum (0);
			Assert.That (rts1.GetHashCode (), Is.EqualTo(rts2.GetHashCode ()));
		}

		[Test]
		public void TestRTSignalGetHashCodeInequality ()
		{
			RealTimeSignum rts1 = new RealTimeSignum (0);
			RealTimeSignum rts2 = new RealTimeSignum (1);
			Assert.That (rts1.GetHashCode (), Is.Not.EqualTo(rts2.GetHashCode ()));
		}

		[Test]
		public void TestIsRTSignalPropertyForRTSignum ()
		{
			UnixSignal signal1 = new UnixSignal(new RealTimeSignum (0));
			Assert.That (signal1.IsRealTimeSignal, Is.True);
		}

		[Test]
		public void TestIsRTSignalPropertyForSignum ()
		{
			UnixSignal signal1 = new UnixSignal (Signum.SIGSEGV);
			Assert.That (signal1.IsRealTimeSignal, Is.False);
		}

	}
}
