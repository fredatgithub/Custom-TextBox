using System.Text;
using System;

namespace HelperLibrary
{
  public static class Helper
  {
    /// <summary>
    /// Remove the password from a string of characters containing carriage returns.
    /// </summary>
    /// <param name="message">The string of characters.</param>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="newText">The new text to replace.</param>
    /// <param name="separator">The character as separator.</param>
    /// <returns>A string with the password replace by the new text.</returns>
    public static string RemovePasswordFromPattern2(string message, string pattern, string newText, char separator = '=')
    {
      var result = new StringBuilder();
      string[] lines = message.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

      foreach (var line in lines)
      {
        if (line.Contains(pattern))
        {
          result.AppendLine($"{ReplaceLastWord(line, newText, separator)}{Environment.NewLine}");
        }
        else
        {
          result.Append(line);
        }
      }

      return result.ToString();
    }

    /// <summary>
    /// Remove the password from a string of characters containing carriage returns.
    /// </summary>
    /// <param name="message">The string of characters.</param>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="newText">The new text to replace.</param>
    /// <param name="separator">The character as separator.</param>
    /// <returns>A string with the password replace by the new text.</returns>
    public static string RemovePasswordFromPattern(string message, string pattern, string newText, char separator = '=')
    {
      var result = new StringBuilder();
      string[] lines = message.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

      foreach (var line in lines)
      {
        if (line.Contains(pattern))
        {
          result.Append($"{ReplaceLastWord(line, newText, separator)}\n");
        }
        else
        {
          result.Append($"{line}\n");
        }
      }

      // Remove the last extra '\n'
      if (result.Length > 0)
      {
        result.Length--;
      }

      return result.ToString();
    }

    /// <summary>
    /// Replace the last word after the last separator.
    /// </summary>
    /// <param name="message">The original message.</param>
    /// <param name="newText">The new text to replace the last word.</param>
    /// <param name="separator">A character to separate. The default character is the equal sign.</param>
    /// <returns>A string with the last word replaced by the new text.</returns>
    public static string ReplaceLastWord(string message, string newText, char separator = '=')
    {
      var array = message.Split(separator);
      array[array.Length - 1] = newText;
      return string.Join(separator.ToString(), array);
    }
  }
}
