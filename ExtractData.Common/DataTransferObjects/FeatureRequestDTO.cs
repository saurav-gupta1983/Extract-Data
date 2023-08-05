using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtractData.Common.DataTransferObjects
{
    public class FeatureRequestDTO
    {
        #region Variables

        private string name;
        private string emailAddress;
        private string company;
        private string product;
        private string productVersion;
        private string productLanguage;
        private string feedback;
        private string requestedDate;
        private string requestType;
        private string os;
        private string osVersion;
        private string osLanguage;

        #endregion

        #region Public Properties

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// EmailAddress
        /// </summary>
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
            }
        }

        /// <summary>
        /// Company
        /// </summary>
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
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
        /// productVersion
        /// </summary>
        public string ProductVersion
        {
            get
            {
                return productVersion;
            }
            set
            {
                productVersion = value;
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
        /// feedback
        /// </summary>
        public string Feedback
        {
            get
            {
                return feedback;
            }
            set
            {
                feedback = value;
            }
        }

        /// <summary>
        /// requestedDate
        /// </summary>
        public string RequestedDate
        {
            get
            {
                return requestedDate;
            }
            set
            {
                requestedDate = value;
            }
        }

        /// <summary>
        /// requestType
        /// </summary>
        public string RequestType
        {
            get
            {
                return requestType;
            }
            set
            {
                requestType = value;
            }
        }

        /// <summary>
        /// os
        /// </summary>
        public string Platform
        {
            get
            {
                return os;
            }
            set
            {
                os = value;
            }
        }

        /// <summary>
        /// osVersion
        /// </summary>
        public string OSVersion
        {
            get
            {
                return osVersion;
            }
            set
            {
                osVersion = value;
            }
        }

        /// <summary>
        /// osLanguage
        /// </summary>
        public string OSLanguage
        {
            get
            {
                return osLanguage;
            }
            set
            {
                osLanguage = value;
            }
        }

        #endregion

    }
}
