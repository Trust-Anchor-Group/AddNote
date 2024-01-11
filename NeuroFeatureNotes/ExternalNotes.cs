using System.Xml;
using Waher.Content;
using Waher.Content.Xml;

namespace NeuroFeatureNotes
{
	/// <summary>
	/// Static class with which you can add external notes to Neuro-Feature tokens.
	/// </summary>
	public static class ExternalNotes
	{
		/// <summary>
		/// Adds a note (either text or XML) to a Neuro-Feature token.
		/// </summary>
		/// <param name="DomainName">Domain-name of Neuron hosting the token.</param>
		/// <param name="UserName">User name to use when logging in.</param>
		/// <param name="Password">Password to use with <paramref name="UserName"/>.</param>
		/// <param name="TokenId">ID token Neuro-Feature token.</param>
		/// <param name="Note">Note to add (either text or XML).</param>
		public static async Task<object> AddNote(string DomainName, string UserName, string Password, string TokenId, string Note)
		{
			if (!Uri.TryCreate("https://" + DomainName + "/AddNote/" + TokenId, UriKind.Absolute, out Uri? ParsedUri))
				throw new Exception("Invalid domain name or Token ID.");
			
			KeyValuePair<string, string>[] Headers =
			[
				new KeyValuePair<string, string>("WWW-Authenticate", "Basic " + Convert.ToBase64String(
					InternetContent.ISO_8859_1.GetBytes(UserName + ":" + Password)))
			];

			if (XML.IsValidXml(Note))
			{
				XmlDocument Doc = new();
				Doc.LoadXml(Note);
			
				return await InternetContent.PostAsync(ParsedUri, Doc, Headers);
			}
			else
				return await InternetContent.PostAsync(ParsedUri, Note, Headers);
		}
	}
}
