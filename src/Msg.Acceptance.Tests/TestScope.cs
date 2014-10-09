using NUnit.Framework;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Msg.Acceptance.Tests
{

	class TestScope : IDisposable
	{
		readonly Process process;

		public TestScope()
		{
			process = Process.Start (new ProcessStartInfo {
				FileName = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Msg.ConsoleApp.exe",
				UseShellExecute = false,
				RedirectStandardInput = true,
				RedirectStandardError = true
			});

			Thread.Sleep (1000);
		}

		public void Dispose ()
		{
			if (!process.HasExited) {
				process.Kill ();
			}
		}
	}
}
