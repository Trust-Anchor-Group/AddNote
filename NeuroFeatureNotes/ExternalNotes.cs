using System.Security.Cryptography.X509Certificates;
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
		/// <param name="CertificateFileName">File name of certificate to use for mTLS authentication.</param>
		/// <param name="CertificatePassword">Password to use with <paramref name="CertificateFileName"/>.</param>
		/// <param name="TokenId">ID token Neuro-Feature token.</param>
		/// <param name="Note">Note to add (either text or XML).</param>
		public static Task<object> AddNote(string DomainName, string CertificateFileName, string CertificatePassword, 
			string TokenId, string Note)
		{
			X509Certificate2 Certificate = new(CertificateFileName, CertificatePassword);
			return AddNote(DomainName, Certificate, TokenId, Note);
		}

		/// <summary>
		/// Adds a note (either text or XML) to a Neuro-Feature token.
		/// </summary>
		/// <param name="DomainName">Domain-name of Neuron hosting the token.</param>
		/// <param name="Certificate">Certificate for mTLS authentication.</param>
		/// <param name="TokenId">ID token Neuro-Feature token.</param>
		/// <param name="Note">Note to add (either text or XML).</param>
		public static async Task<object> AddNote(string DomainName, X509Certificate Certificate, string TokenId, string Note)
		{
			ArgumentNullException.ThrowIfNull(Certificate);

			if (!Uri.TryCreate("https://" + DomainName + "/AddNote/" + TokenId, UriKind.Absolute, out Uri? ParsedUri))
				throw new Exception("Invalid domain name or Token ID.");

			if (XML.IsValidXml(Note))
			{
				XmlDocument Doc = new();
				Doc.LoadXml(Note);
			
				return await InternetContent.PostAsync(ParsedUri, Doc, Certificate);
			}
			else
				return await InternetContent.PostAsync(ParsedUri, Note, Certificate);
		}
	}
}
