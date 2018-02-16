using System;
using System.Text;

namespace InterviewQuestions
{
	public static class Week1Questions
	{
		private static int Reverse(int original)
		{
			int reverse = 0;
			while (original != 0)
			{
				int digit = original % 10;
				reverse = reverse*10 + digit;
				original = original / 10;
			}
			return reverse;
		}

		private static bool IsPalindrome(int original, int reverse)
		{
			return original == reverse;
		}


		public static bool IsOrCanBePalindrome(int number)
		{
			const int MaxPalindrome = 1000000;

			while (number < MaxPalindrome)
			{
				int reverse = Reverse(number);
				bool isPal = IsPalindrome(number, reverse);
				if (isPal)
				{
					return true;
				}

				number = number + reverse;
			}

			return false;
		}


		public static string CaesarCipher(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				throw new ArgumentException();
			}

			int colonPosition = input.IndexOf(":");
			if (colonPosition <= 0)
			{
				throw new ArgumentException();
			}

			int shift;
			if (!Int32.TryParse(input.Substring(0, colonPosition), out shift))
			{
				throw new ArgumentException();
			}

			int originalInputLength = input.Length;
			if (colonPosition + 1 == originalInputLength)
			{
				throw new ArgumentException();
			}

			string textToShift = input.Substring(colonPosition + 1);

			StringBuilder encryptedText = new StringBuilder(textToShift.Length);

			for (int i = 0; i < textToShift.Length; i++)
			{
				if (textToShift[i] >= 'A' && textToShift[i] <= 'Z')
				{
					encryptedText.Append(EncryptCharacter(textToShift[i], shift, 'A', 'Z'));
				}
				else if (textToShift[i] >= 'a' && textToShift[i] <= 'z')
				{
					encryptedText.Append(EncryptCharacter(textToShift[i], shift, 'a', 'z'));
				}
				else if (textToShift[i] >= '0' && textToShift[i] <= '9')
				{
					encryptedText.Append(EncryptCharacter(textToShift[i], shift, '0', '9'));
				}
			}

			return encryptedText.ToString();
		}

		private static char EncryptCharacter(char c, int shift, char lowerBound, char upperBound)
		{
			int range = upperBound - lowerBound + 1;
			int relativePosition = c - lowerBound;

			// bring the shift back into the character range
			shift = shift % range;

			int newPosition = (relativePosition + shift + range) % range;

			return (char) (lowerBound + newPosition);
		}
	}
}
