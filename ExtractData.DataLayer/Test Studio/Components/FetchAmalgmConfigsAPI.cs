using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Adobe.Localization.Insights.Common;
using DTO = Adobe.Localization.Insights.Common.DataTransferObjects;

namespace Adobe.Localization.Insights.DataLayer.TestStudioComponents
{
    /// <summary>
    /// FetchAmalgmConfigsAPI
    /// </summary>
    class FetchAmalgmConfigsAPI
    {
        #region Public Members

        /// <summary>
        /// FetchAmalgmConfigs
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public DTO.TestSudio FetchAmalgmConfigs(DTO.TestSudio ts)
        {
            //#region Execute

            //#region Read ScriptData

            ////Variables
            //string UserName = string.Empty;
            //string Password = string.Empty;
            //string ExpectedResult = string.Empty;
            //string sessionID = string.Empty;
            //bool useScList = true; //setting default search by sclist
            //bool useidList = false;
            //bool useTS_ID = false;

            //// Read test Input Data
            //TextReader tr = new StreamReader(file);
            //string xmlin = tr.ReadToEnd();
            //tr.Close();

            ////Load Test Input Data into XML Doc

            //XmlDocument doc = new XmlDocument();
            //try
            //{
            //    doc.LoadXml(xmlin);

            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("\nSEVERE ERROR : Input Script - '" + file + "' is Not a Valid XML File!");
            //    continue;
            //}

            ////Read ScriptData Tags

            //XmlNode testcaseID = doc.GetElementsByTagName("TestCaseID")[0];
            //TestCaseID = testcaseID.InnerText;

            //XmlNode testcaseScenario = doc.GetElementsByTagName("TestCaseScenario")[0];
            //ScenarioDescription = testcaseScenario.InnerText;

            //XmlNode username = doc.GetElementsByTagName("username")[0];
            //UserName = username.InnerText;

            //XmlNode password = doc.GetElementsByTagName("password")[0];
            //Password = password.InnerText;

            //XmlNode sessionid = doc.GetElementsByTagName("sessionID")[0];
            //sessionID = sessionid.InnerText;

            //XmlNode expectedResult = doc.GetElementsByTagName("ExpectedResult")[0];
            //ExpectedResult = expectedResult.InnerText;

            //XmlNode inputxml = doc.GetElementsByTagName("InputXML")[0];

            //XmlNodeList SearchList = inputxml.SelectNodes("/TestCase/InputXML/SearchList/SearchObject");
            //int count = SearchList.Count;

            //XmlNode SearchObject = null;
            ////SearchCriterion[] sclist = new SearchCriterion[count];
            //int i = 0;
            //SearchObject = doc.GetElementsByTagName("SearchObject")[0];
            ////do
            ////{
            ////list of <SearchObject>
            //XmlNodeList SearchObjectChildren = SearchObject.ChildNodes;
            //SearchCriterion sc = new SearchCriterion();

            //TS_AutomationStudio.TSWSRef_PROD_Environment.fetchAmalgmConfigs logObj = new TS_AutomationStudio.TSWSRef_PROD_Environment.fetchAmalgmConfigs();

            ////for every <SearchObject>
            //for (int CCount = 0; CCount < SearchObjectChildren.Count; CCount++)
            //{
            //    //match the name of first (CCount = 0) child of <SearchObject>
            //    switch (SearchObjectChildren[CCount].Name)
            //    {
            //        case "useScList":
            //            bool.TryParse(SearchObjectChildren[CCount].InnerText, out useScList);
            //            break;
            //        case "useidList":
            //            bool.TryParse(SearchObjectChildren[CCount].InnerText, out useidList);
            //            break;
            //        case "useTS_ID":
            //            bool.TryParse(SearchObjectChildren[CCount].InnerText, out useTS_ID);
            //            break;
            //        case "idList":
            //            if (useScList && useidList && useTS_ID)
            //            {
            //                Console.WriteLine("\n  WARNING:Only one value out of (useScList,useidList,useTS_ID) should be TRUE !");
            //            }
            //            if (!useScList && useidList)
            //            {
            //                int[] idLIST = null;
            //                string idlist_str = SearchObjectChildren[CCount].InnerText;
            //                if (idlist_str.Equals(string.Empty))
            //                {
            //                    logObj.idList = null;
            //                    break;
            //                }

            //                string[] idlist_csv = idlist_str.Split(',');
            //                idLIST = new int[idlist_csv.Length];
            //                int idX = 0;
            //                foreach (string id in idlist_csv)
            //                {
            //                    idLIST[idX] = Int32.Parse(id.ToString());
            //                    idX++;
            //                }

            //                logObj.idList = idLIST;
            //            }
            //            else
            //            {
            //                logObj.idList = null;
            //            }
            //            break;
            //        case "TS_ID":
            //            if (useScList && useidList && useTS_ID)
            //            {
            //                Console.WriteLine("\n  WARNING:Only one value out of (useScList,useidList,useTS_ID) should be TRUE !");
            //            }

            //            if (!useScList && !useidList && useTS_ID)
            //            {
            //                string TSID = SearchObjectChildren[CCount].InnerText;
            //                logObj.ts_id = Int32.Parse(TSID);
            //            }
            //            //else
            //            //{
            //            //    logObj.ts_id = null;
            //            //}
            //            break;
            //        case "filterList":
            //            if (!useScList && useidList && !useTS_ID)
            //            {
            //                sc.filterList = null;
            //                break;
            //            }
            //            if (useScList && useidList && useTS_ID)
            //            {
            //                sc.filterList = null;
            //                break;
            //            }
            //            if (useScList && useidList && useTS_ID)
            //            {
            //                Console.WriteLine("\n  WARNING:Only one value out of (useScList,useidList,useTS_ID) should be TRUE !");
            //            }
            //            //gives all <filter> nodes
            //            XmlNodeList Filters = SearchObjectChildren[CCount].ChildNodes;
            //            int filterCount = Filters.Count;
            //            Filter[] filterList = new Filter[filterCount];

            //            int f = 0; // index of filterList

            //            //pick up each <filter> node
            //            foreach (XmlNode filterNode in Filters)
            //            {
            //                Filter filterObj = new Filter();

            //                //pickup each childnode of <filter>
            //                XmlNodeList filterNodeChildren = filterNode.ChildNodes;
            //                for (int filterNodeChild = 0; filterNodeChild < filterNodeChildren.Count; filterNodeChild++)
            //                {

            //                    switch (filterNodeChildren[filterNodeChild].Name)
            //                    {
            //                        case "fieldName":
            //                            filterObj.fieldName = filterNodeChildren[filterNodeChild].InnerText;
            //                            break;
            //                        case "operator":
            //                            filterObj.@operator = filterNodeChildren[filterNodeChild].InnerText;
            //                            break;
            //                        case "fieldValues":
            //                            XmlNodeList fieldValues = filterNodeChildren[filterNodeChild].ChildNodes;
            //                            string[] fieldVALUES = new string[fieldValues.Count];
            //                            int nFieldVal = 0;
            //                            foreach (XmlNode fieldValue in fieldValues)
            //                            {
            //                                fieldVALUES[nFieldVal] = fieldValue.InnerText;
            //                                nFieldVal++;
            //                            }
            //                            filterObj.fieldValue = fieldVALUES;
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                }

            //                filterList[f] = filterObj;
            //                f++;

            //            }

            //            sc.filterList = filterList;

            //            break;
            //        case "filterRelationship":
            //            if (!useScList && useidList && !useTS_ID)
            //            {
            //                sc.filterList = null;
            //                break;
            //            }
            //            if (useScList && useidList && useTS_ID)
            //            {
            //                sc.filterList = null;
            //                break;
            //            }
            //            sc.filterRelationship = SearchObjectChildren[CCount].InnerText;
            //            break;
            //        default:
            //            break;
            //    }



            //}

            //if (!useScList && useidList && !useTS_ID)
            //{
            //    logObj.sc = null;

            //}
            //if (useScList && useidList && useTS_ID)
            //{
            //    logObj.sc = null;

            //}
            //if (useScList && !useidList && !useTS_ID)
            //{
            //    logObj.sc = sc;

            //}
            ////sclist[i] = sc;
            //SearchObject = SearchObject.NextSibling;
            //i++;

            ////} while (i < count && SearchObject!=null);


            //#endregion

            //Initiate Login

            TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();
            TestStudioService.fetchAmalgmConfigs logObj = new TestStudioService.fetchAmalgmConfigs();
            logObj.SessionID = ts.SessionID;
            logObj.idList = new int[] { 3 };

            TestStudioService.fetchAmalgmConfigsRequest lr = new TestStudioService.fetchAmalgmConfigsRequest(logObj);
            TestStudioService.fetchAmalgmConfigsResponse1 lres = null;

            try
            {
                lres = service.fetchAmalgmConfigs(lr);
                ts.TestSuiteID = lres.ToString();
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
