using NeuroFeatureNotes;
using Waher.Runtime.Inventory.Loader;
using Waher.Script;

internal class Program
{
	private static async Task<int> Main(string[] args)
	{
		try
		{
			string? DomainName = null;
			string? UserName = null;
			string? Password = null;
			string? TokenId = null;
			string? NoteFileName = null;
			string? Note = null;
			int i = 0;
			int c = args.Length;
			bool Help = c == 0;

			while (i < c)
			{
				switch (args[i++].ToLower())
				{
					case "-d":
					case "-domain":
						if (i >= c)
							throw new Exception("Expected domain name.");

						DomainName = args[i++];
						break;

					case "-u":
					case "-user":
					case "-username":
						if (i >= c)
							throw new Exception("Expected user name.");

						UserName = args[i++];
						break;

					case "-p":
					case "-pwd":
					case "-password":
						if (i >= c)
							throw new Exception("Expected password.");

						Password = args[i++];
						break;

					case "-t":
					case "-tid":
					case "-token":
					case "-tokenid":
						if (i >= c)
							throw new Exception("Expected token ID.");

						TokenId = args[i++];
						break;

					case "-n":
					case "-note":
						if (i >= c)
							throw new Exception("Expected note.");

						if (!string.IsNullOrEmpty(NoteFileName))
							throw new Exception("Cannot have both a note and a file name.");

						Note = args[i++];
						break;

					case "-f":
					case "-fn":
					case "-file":
					case "-filename":
						if (i >= c)
							throw new Exception("Expected file name.");

						if (!string.IsNullOrEmpty(Note))
							throw new Exception("Cannot have both a note and a file name.");

						NoteFileName = args[i++];
						break;

					case "-?":
					case "-h":
					case "-help":
						Help = true;
						break;

					default:
						throw new Exception("Unrecognized command-line argument: " + args[i - 1]);
				}
			}

			if (Help)
			{
				Console.Out.WriteLine("AddNote is a command-line tool for adding external notes to Neuro-Feature tokens.");
				Console.Out.WriteLine();
				Console.Out.WriteLine("Command-line arguments:");
				Console.Out.WriteLine("==========================");
				Console.Out.WriteLine("-d DOMAIN           Specifies the domain name of the Neuron hosting the token.");
				Console.Out.WriteLine("-domain DOMAIN      Same as -d DOMAIN.");
				Console.Out.WriteLine();
				Console.Out.WriteLine("-u USERNAME         Specifies the user name to use when adding the note.");
				Console.Out.WriteLine("-user USERNAME      Same as -u USERNAME.");
				Console.Out.WriteLine("-username USERNAME  Same as -u USERNAME.");
				Console.Out.WriteLine();
				Console.Out.WriteLine("-p PASSWORD         Specifies the password to use when authenticating the user name.");
				Console.Out.WriteLine("-pwd PASSWORD       Same as -p PASSWORD.");
				Console.Out.WriteLine("-password PASSWORD  Same as -p PASSWORD.");
				Console.Out.WriteLine();
				Console.Out.WriteLine("-t TOKEN_ID         Specifies the ID of the token to add a note to.");
				Console.Out.WriteLine("-tid TOKEN_ID       Same as -t TOKEN_ID.");
				Console.Out.WriteLine("-token TOKEN_ID     Same as -t TOKEN_ID.");
				Console.Out.WriteLine("-tokenid TOKEN_ID   Same as -t TOKEN_ID.");
				Console.Out.WriteLine();
				Console.Out.WriteLine("-n NOTE             Specifies the contents of the note, in-line. Can be text or XML.");
				Console.Out.WriteLine("-note NOTE          Same as -n NOTE.");
				Console.Out.WriteLine();
				Console.Out.WriteLine("-f FILENAME         Specifies the file-name of the contents of the note. Can be a text or XML file.");
				Console.Out.WriteLine("-fn FILENAME        Same as -f FILENAME.");
				Console.Out.WriteLine("-file FILENAME      Same as -f FILENAME.");
				Console.Out.WriteLine("-filename FILENAME  Same as -f FILENAME.");

				if (c == 1)
					return 0;
			}

			while (string.IsNullOrEmpty(DomainName))
			{
				Console.Out.Write("Domain name: ");
				DomainName = Console.In.ReadLine();
			}

			while (string.IsNullOrEmpty(UserName))
			{
				Console.Out.Write("User name: ");
				UserName = Console.In.ReadLine();
			}

			while (string.IsNullOrEmpty(Password))
			{
				Console.Out.Write("Password: ");
				Password = Console.In.ReadLine();
			}

			while (string.IsNullOrEmpty(TokenId))
			{
				Console.Out.Write("Token ID: ");
				TokenId = Console.In.ReadLine();
			}

			if (!string.IsNullOrEmpty(NoteFileName))
				Note = File.ReadAllText(NoteFileName);
			else if (string.IsNullOrEmpty(Note))
			{
				while (string.IsNullOrEmpty(Note))
				{
					Console.Out.Write("Note: ");
					Note = Console.In.ReadLine();
				}
			}

			Console.Out.WriteLine("Adding note...");

			TypesLoader.Initialize();

			object Result = await ExternalNotes.AddNote(DomainName, UserName, Password, TokenId, Note);

			Console.Out.WriteLine("Note added...");
			Console.Out.WriteLine("Response: " + Expression.ToString(Result));

			return 0;
		}
		catch (Exception ex)
		{
			Console.Out.WriteLine(ex.Message);
			return -1;
		}
	}
}