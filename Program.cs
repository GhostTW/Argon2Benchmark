namespace Argon2Benchmark
{
	using System;
	using System.Text;
	using System.Diagnostics;
	using Konscious.Security.Cryptography;
	
	public class Program
    {
        public static void Main(string[] args)
        {
			ShowArgsInDebugMode(args);

			if (args.Length != 8)
			{
				Console.WriteLine("args not enough.");
				return;
			}
			var sw = new Stopwatch();
			sw.Start();
			var result = HashPasswordArgon2(Encoding.ASCII.GetBytes(args[0]), Encoding.ASCII.GetBytes(args[1]), Encoding.ASCII.GetBytes(args[2]), (Argon2Algorithm)Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToInt32(args[5]), Convert.ToInt32(args[6]), Convert.ToInt32(args[7]));
			sw.Stop();
			Console.WriteLine($"Elapsed: {sw.Elapsed}");
			Console.WriteLine($"result: {result}");
			Console.WriteLine($"result length: {result.Length}");
			var base64 = Convert.ToBase64String(result);
			Console.WriteLine($"result base64: {base64}");
			Console.WriteLine($"result base64: {base64.Length}");
		}

		[Conditional("DEBUG")]
		public static void ShowArgsInDebugMode(string[] args)
		{
			Console.Write("args:");
			foreach (var arg in args)
			{
				Console.Write($" {arg}");
			}
			Console.WriteLine();
		}

		public static byte[] HashPasswordArgon2(byte[] password, byte[] salt, byte[] userUuidBytes, Argon2Algorithm algorithm = Argon2Algorithm.i, int degreeOfParallelism = 2, int memorySize = 5120, int iterations = 10, int resultLength = 256)
		{
			Argon2 argon2;
			switch (algorithm)
			{
				case Argon2Algorithm.i:
					argon2 = new Argon2i(password);
					break;
				case Argon2Algorithm.d:
					argon2 = new Argon2d(password);
					break;
				case Argon2Algorithm.id:
				default:
					throw new NotSupportedException();
			}

			argon2.DegreeOfParallelism = degreeOfParallelism;
			argon2.MemorySize = memorySize;
			argon2.Iterations = iterations;
			argon2.Salt = salt;
			argon2.AssociatedData = userUuidBytes;
			var hash = argon2.GetBytes(resultLength);
			argon2.Dispose();
			return hash;
		}

		public enum Argon2Algorithm
		{
			i,
			d,
			id,
		}
	}
}
