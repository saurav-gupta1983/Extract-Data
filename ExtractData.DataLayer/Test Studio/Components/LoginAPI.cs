using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using ExtractData.Common;
using DTO = ExtractData.Common.DataTransferObjects;

namespace ExtractData.DataLayer.TestStudioComponents
{
    /// <summary>
    /// LoginAPI
    /// </summary>
    public class LoginAPI
    {
        #region Private Variables

        private string userLoginID;
        private string userPassword;

        #endregion

        #region Public Members

        /// <summary>
        /// Login
        /// </summary>
        public DTO.TestSudio Login(DTO.TestSudio ts)
        {
            userLoginID = "tsuser1";
            userPassword = "Te5t$tud";

            TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();

            TestStudioService.login loginObj = new TestStudioService.login();
            loginObj.ldapID = userLoginID;
            loginObj.ldapPasswd = userPassword;

            TestStudioService.loginRequest request = new TestStudioService.loginRequest(loginObj);
            TestStudioService.loginResponse1 response = null;
            try
            {
                response = service.login(request);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response.loginResponse.@return);

                XmlNodeList sessionID = doc.GetElementsByTagName("sessionid");

                if (sessionID != null && sessionID.Count > 0)
                    ts.SessionID = sessionID[0].InnerText;
            }

            catch (Exception ex)
            {
                ts.ErrorCode = "-1";
                ts.ErrorMessage = ex.Message;
            }

            return ts;
        }

        #endregion
    }
}
