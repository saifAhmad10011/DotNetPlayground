using System;
using DotNetPlayground.Services;

namespace TokenDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			// Generate a JWT token for user 'testuser' with 'Admin' role
			string token = JwtTokenGenerator.GenerateToken("testuser", "Admin");
			Console.WriteLine("JWT Token:\n" + token);
		}
	}
}
// See https://aka.ms/new-console-template for more information
