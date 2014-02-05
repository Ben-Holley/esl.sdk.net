using System;

namespace Silanis.ESL.SDK.Internal
{
	/// <summary>
	/// A helper class to convert from string to byte array and vice verse.
	/// </summary>
	public class Converter
	{
		/// <summary>
		/// Convert string to byte array.
		/// </summary>
		/// <returns>The byte array.</returns>
		/// <param name="str">String.</param>
		public static byte[] ToBytes (string str)
		{
			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding ();
			return encoding.GetBytes (str);
		}

		/// <summary>
		/// Convert byte array to string.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="bytes">Byte array.</param>
		public static string ToString (byte[] bytes)
		{
			Support.LogDebug("Converting " + bytes.Length + " bytes to string.");
			if (bytes != null && bytes.Length > 0)
			{
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				string result = enc.GetString(bytes);
				Support.LogDebug("Converted '" + result + "'");
				return result;
			}
			else
				return "";
		}
	}
}

