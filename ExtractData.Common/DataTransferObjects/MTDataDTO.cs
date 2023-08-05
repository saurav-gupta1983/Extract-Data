using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtractData.Common.DataTransferObjects
{
    public class MTDataDTO
    {
        #region Variables

        private string fileName;
        private string product;
        private string productLanguage;
        private string handOff;
        private string handOffDate;
        private string total;
        private string iCEMatch;
        private string hundredMatch;
        private string ninetyMatch;
        private string seventyMatch;
        private string zeroMatch;
        private string repeatitions;
        private string fuzzyWords;

        #endregion

        #region Public Properties

        /// <summary>
        /// fileName
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        /// <summary>
        /// handOff
        /// </summary>
        public string HandOff
        {
            get
            {
                return handOff;
            }
            set
            {
                handOff = value;
            }
        }

        /// <summary>
        /// handOffDate
        /// </summary>
        public string HandOffDate
        {
            get
            {
                return handOffDate;
            }
            set
            {
                handOffDate = value;
            }
        }


        /// <summary>
        /// total
        /// </summary>
        public string Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        /// <summary>
        /// iCEMatch
        /// </summary>
        public string ICEMatch
        {
            get
            {
                return iCEMatch;
            }
            set
            {
                iCEMatch = value;
            }
        }

        /// <summary>
        /// product
        /// </summary>
        public string Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
            }
        }

        /// <summary>
        /// hundredMatch
        /// </summary>
        public string HundredMatch
        {
            get
            {
                return hundredMatch;
            }
            set
            {
                hundredMatch = value;
            }
        }

        /// <summary>
        /// productLanguage
        /// </summary>
        public string ProductLanguage
        {
            get
            {
                return productLanguage;
            }
            set
            {
                productLanguage = value;
            }
        }

        /// <summary>
        /// ninetyMatch
        /// </summary>
        public string NinetyMatch
        {
            get
            {
                return ninetyMatch;
            }
            set
            {
                ninetyMatch = value;
            }
        }

        /// <summary>
        /// seventyMatch
        /// </summary>
        public string SeventyMatch
        {
            get
            {
                return seventyMatch;
            }
            set
            {
                seventyMatch = value;
            }
        }

        /// <summary>
        /// zeroMatch
        /// </summary>
        public string ZeroMatch
        {
            get
            {
                return zeroMatch;
            }
            set
            {
                zeroMatch = value;
            }
        }

        /// <summary>
        /// repeatitions
        /// </summary>
        public string Repeatitions
        {
            get
            {
                return repeatitions;
            }
            set
            {
                repeatitions = value;
            }
        }

        /// <summary>
        /// fuzzyWords
        /// </summary>
        public string FuzzyWords
        {
            get
            {
                return fuzzyWords;
            }
            set
            {
                fuzzyWords = value;
            }
        }

        #endregion

    }
}
