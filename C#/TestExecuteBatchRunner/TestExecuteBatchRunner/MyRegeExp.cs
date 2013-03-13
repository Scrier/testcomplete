using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestExecuteBatchRunner
{
    public static class MyRegeExp
    {

        /// <summary>
        /// A recursive function to generate a regular expression that matches
        /// any number in the range between min and max inclusive.
        /// </summary>
        /// <example>
        /// >>> Debug.WriteLine(GenerateRegExpForNumericRange(13,57));
        /// '4[0-9]|3[0-9]|2[0-9]|1[3-9]|5[0-7]'
        /// >>> Debug.WriteLine(GenerateRegExpForNumericRange(1983,2011));
        /// '200[0-9]|199[0-9]|198[3-9]|201[0-1]'
        /// >>> Debug.WriteLine(GenerateRegExpForNumericRange(99,112));
        /// '99|10[0-9]|11[0-2]'
        /// </example>
        /// <param name="min">int</param>
        /// <param name="max">int</param>
        /// <remarks>
        /// doctests are order sensitive, while regular expression engines don't care.  So you may need to rewrite these
        /// doctests if making changes.
        /// </remarks>
        /// <returns>string</returns>
        public static string GenerateRegExpForNumericRange(int min, int max)
        {
            string _min = min.ToString();
            string _max = max.ToString();
            if (min == max)
            {
                return max.ToString();
            }
            else if (_min.Length < _max.Length)
            {
                // more digits in max than min, so we pair it down into sub ranges
                // that are the same number of digits.  If applicable we also create a pattern to
                // cover the cases of values with number of digits in between that of
                // max and min.
                string re_middle_range = "";
                if (_max.Length > (_min.Length + 2))
                {
                    // digits more than 2 off, create mid range
                    re_middle_range = "[0-9]{" + (_min.Length + 1);
                    re_middle_range += "," + (_max.Length - 1) + "}";
                }
                else if (_max.Length > _min.Length + 1)
                { 
                    // digits more than 1 off, create mid range
                    // assert len(_min)+1==len(_max)-1 #temp: remove
                    re_middle_range="[0-9]{" + ( _min.Length + 1 ) + "}";
                }
                // pair off into sub ranges
                int max_big = max; // 5671
                int min_big = int.Parse("1" + ("0".Multiply(_max.Length - 1))); // 5671 => 1000
                string re_big = GenerateRegExpForNumericRange(min_big,max_big);
                int max_small = int.Parse("9".Multiply(_min.Length));
                int min_small = min;
                string re_small = GenerateRegExpForNumericRange(min_small, max_small);
                if (re_middle_range != "")
                {
                    return "|".Join(new string[3]{re_small,re_middle_range,re_big});
                }
                else
                {
                    return "|".Join(new string[2] { re_small,re_big });
                }
            }
            else if (_max.Length == _min.Length)
            {
                List<string> patterns = new List<string>();
                if (_max.Length == 1)
                {
                    patterns.Add(naive_range(min, max));
                }
                else
                {
                    // this is probably the trickiest part so we'll follow the example of
                    // 1336 to 1821 through this section
                    string distance = ( max - min ).ToString(); //e.g., distance = 1821-1336 = 485
                    int increment = int.Parse("1" + "0".Multiply(distance.Length - 1)); // e.g., 100 when distance is 485
                    if (1 == increment)
                    {
                        // it's safe to do a naive_range see, see def since 10's place is the same for min and max
                        patterns.Add(naive_range(min,max));
                    }
                    else
                    {
                        // capture a safe middle range
                        // e.g., create regex patterns to cover range between 1400 to 1800 inclusive
                        // so in example we should get: 14[0-9]{2}|15[0-9]{2}|16[0-9]{2}|17[0-9]{2}
                        for (int i = floor_digit_n(max, increment) - increment; i > floor_digit_n(min, increment); i -= increment)
                        {
                            int len_end_to_replace = (increment.ToString().Length - 1);
                            string pattern = i.ToString().Substring(0, i.ToString().Length - len_end_to_replace);
                            pattern += "[0-9]";
                            if ( 1 != len_end_to_replace )
                            {
                                pattern += "{" + len_end_to_replace + "}";
                            }
                            patterns.Add(pattern);
                        }
                        // split off ranges outside of increment digits, i.e., what isn't covered in last step.
                        // low side: e.g., 1336 -> min=1336, max=1300+(100-1) = 1399
                        patterns.Add(GenerateRegExpForNumericRange(min, floor_digit_n(min,increment) + (increment - 1)));
                        // high side: e.g., 1821 -> min=1800 max=1821
                        patterns.Add(GenerateRegExpForNumericRange(floor_digit_n(max,increment),max));
                    }
                }
                return "|".Join(patterns.ToArray());
            }
            else
                throw new IndexOutOfRangeException("GenerateRegExpForNumericRange: Expected min(" + min + ") to be < max(" + max + ").");
        }

        /// <summary>
        /// Simply matches min, to max digits by position.  Should create a
        /// valid regex when min and max have same num digits and has same 10s
        /// place digit.
        /// </summary>
        /// <param name="min">int</param>
        /// <param name="max">int</param>
        /// <returns>string</returns>
        private static string naive_range(int min, int max)
        {
            string _min = min.ToString();
            string _max = max.ToString();
            string pattern = "";
            for (int i = 0; i < _min.Length; i++)
            {
                if (_min[i] == _max[i])
                {
                    pattern+=_min[i];
                }
                else
                {
                    pattern += "[" + _min[i] + "-" + _max[i] + "]";
                }
            }
            return pattern;
        }

        /// <summary>
        /// create a function to return a floor to the correct digit position
        /// e.g., floor_digit_n(1336) => 1300 when increment is 100
        /// floor_digit_n=lambda x:int(round(x/increment,0)*increment)
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="increment">int</param>
        /// <returns>int</returns>
        private static int floor_digit_n(int x, int increment)
        {
            int retvalue = (int)Math.Floor((double)(x / increment)); // 1336 / 100 => 13.36
            retvalue *= increment; // 13 * 100 => 1300
            return retvalue;
        }

        /// <summary>
        /// Method to multiply stringvalues.
        /// </summary>
        /// <param name="source">string</param>
        /// <param name="multiplier">int</param>
        /// <returns>string multiplied multiplier times.</returns>
        public static string Multiply(this string source, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * source.Length);
            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(source);
            }
            return sb.ToString();
        }

        public static string Join(this string source, Array list)
        {
            StringBuilder builder = new StringBuilder();
            string delimiter = "";
            foreach (string item in list)
            {
                builder.Append(delimiter);
                builder.Append(item);
                delimiter = source;
            }
            return builder.ToString();
        }

    }
}
