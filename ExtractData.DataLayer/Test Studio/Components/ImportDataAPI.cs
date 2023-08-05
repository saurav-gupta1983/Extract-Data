using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Adobe.Localization.Insights.Common;
using DTO = Adobe.Localization.Insights.Common.DataTransferObjects;

namespace Adobe.Localization.Insights.DataLayer.TestStudioComponents
{
    /// <summary>
    /// ExportDataAPI
    /// </summary>
    class ImportDataAPI
    {
        #region Public Members

        ///// <summary>
        ///// ImportTC
        ///// </summary>
        ///// <param name="loggerObj"></param>
        ///// <param name="OptionalParams"></param>
        //public void ImportTC(string sessionID)
        //{
        //    #region Read ScriptData

        //    int entitytype = 0;
        //    int Action = 0;

        //    // Read test Input Data
        //    TextReader tr = new StreamReader(file);
        //    string xmlin = tr.ReadToEnd();
        //    tr.Close();

        //    //Load Test Input Data into XML Doc

        //    XmlDocument doc = new XmlDocument();
        //    try
        //    {
        //        doc.LoadXml(xmlin);

        //    }
        //    catch (Exception)
        //    {
        //        //    Console.WriteLine("\nSEVERE ERROR : Input Script - '" + file + "' is Not a Valid XML File!");
        //        //    continue;
        //    }

        //    //Read ScriptData Tags
        //    XmlNode inputxml = doc.GetElementsByTagName("InputXML")[0];

        //    XmlNode sessionid = doc.GetElementsByTagName("sessionID")[0];
        //    sessionID = sessionid.InnerText;

        //    XmlNode entityType = doc.GetElementsByTagName("EntityType")[0];
        //    Int32.TryParse(entityType.InnerText, out entitytype);
        //    XmlNode action = doc.GetElementsByTagName("Action")[0];
        //    Int32.TryParse(action.InnerText, out Action);

        //    #endregion

        //    TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();

        //    TestStudioService.importData expdObj = new TestStudioService.importData();
        //    expdObj.SessionID = sessionID;
        //    expdObj.strData = inputxml.InnerXml;
        //    expdObj.ielementType = entitytype;
        //    expdObj.iAction = Action;

        //    TestStudioService.importDataRequest request = new TestStudioService.importDataRequest();
        //    request.importData = expdObj;
        //    TestStudioService.importDataResponse1 response = null;

        //    try
        //    {
        //        response = service.importData(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        /// <summary>
        /// ImportTR
        /// </summary>
        /// <param name="loggerObj"></param>
        /// <param name="OptionalParams"></param>
        public DTO.TestSudio ImportTR(DTO.TestSudio ts)
        {
            string xmlin = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlin);

            }
            catch (Exception)
            {
                //Console.WriteLine("\nSEVERE ERROR : Input Script - '" + file + "' is Not a Valid XML File!");
                //continue;
            }


            XmlNode inputxml = doc.GetElementsByTagName("InputXML")[0];
            XmlNode entityType = doc.GetElementsByTagName("EntityType")[0];
            //Int32.TryParse(entityType.InnerText, out entitytype);

            XmlNode action = doc.GetElementsByTagName("Action")[0];
            //Int32.TryParse(action.InnerText, out Action);

            TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();
            TestStudioService.importData impdObj = new TestStudioService.importData();

            impdObj.SessionID = ts.SessionID;
            impdObj.strData = inputxml.InnerXml;
            impdObj.ielementType = 2;
            impdObj.iAction = 1;

            TestStudioService.importDataRequest request = new TestStudioService.importDataRequest();
            request.importData = impdObj;
            TestStudioService.importDataResponse1 response = null;

            try
            {
                response = service.importData(request);
                ts.TestSuiteID = response.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return ts;
        }

        #endregion
    }
}
