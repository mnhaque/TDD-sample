using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersConverter
{  
    public class RomanNumeralConverter
    {
        #region Lookup
        
        private List<RomanNumeralPair> _romanNumeralList;
        
        private void InitialiseLookup()
        {
            _romanNumeralList = new List<RomanNumeralPair>();
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.M));
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.D));
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.C));
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.L));
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.X));
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.V));
            _romanNumeralList.Add(GetNumberPairInstance(RomanNumeralsType.I));
        }
        private RomanNumeralPair GetNumberPairInstance(RomanNumeralsType value)
        {
            return new RomanNumeralPair
            {
                NumericValue = Convert.ToInt32(value),
                RomanNumeralRepresentation = value.ToString()
            };
        }
        #endregion

        public RomanNumeralConverter()
        {
            InitialiseLookup();
        }

        public string ConvertRomanNumeral(int number)
        {
            if (number < 1 || number > 3000)
            {
                throw  new IndexOutOfRangeException("The number supplied is out of the expected range (1 - 3000).");
            }

            var builder = new StringBuilder();

            foreach (var currentPair in _romanNumeralList)
            {
                while (number >= currentPair.NumericValue)
                {
                    builder.Append(currentPair.RomanNumeralRepresentation);
                    number -= currentPair.NumericValue;
                }
            }

            return builder.ToString();
        }
    }
}
