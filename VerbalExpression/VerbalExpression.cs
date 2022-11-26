using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace Mikkytrionze
{
    namespace org
    {
        public class VerbalExpression
        {
            public VerbalExpression()
            {
                regularExpression = "";
            }

            public VerbalExpression StartOfLine()
            {
                regularExpression = "^";
                return this;
            }

            public VerbalExpression Then(string parameter)
            {
                regularExpression += String.Format("{0}", parameter);
                return this;
            }

            public VerbalExpression Maybe(string parameter)
            {
                regularExpression += String.Format("({0})?", parameter);
                return this;
            }

            public VerbalExpression AnythingBut(string parameter)
            {
                regularExpression += String.Format("[^{0}]*", parameter);
                return this;
            }

            public VerbalExpression EndOfLine()
            {
                regularExpression += "$";
                return this;
            }

            private bool EscapeRegexCharacters(ref string chars)
            {
                try
                {
                    Dictionary<string, string> patterns = new()
                    {
                        {@".", @"\."},
                        {@"/", @"\/"}
                    };

                    foreach (var it in patterns)
                    {
                        chars.Replace(it.Key, it.Value);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }

            private string regularExpression;
            public string RegularExpression
            {
                get
                {
                    EscapeRegexCharacters(ref regularExpression);
                    return String.Format(@"/{0}/", regularExpression);
                }
            }

        }
    }
}

