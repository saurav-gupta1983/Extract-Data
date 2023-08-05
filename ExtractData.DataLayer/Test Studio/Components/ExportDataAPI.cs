using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ExtractData.Common;
using DTO = ExtractData.Common.DataTransferObjects;

namespace ExtractData.DataLayer.TestStudioComponents
{
    /// <summary>
    /// ExportDataAPI
    /// </summary>
    public class ExportDataAPI
    {
        #region Public Members

        /// <summary>
        /// ExportTR
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public DTO.TestSudio ExportTR(DTO.TestSudio ts)
        {
            StringBuilder xmlFile = new StringBuilder("<InputXML><searchCriteria>");
            xmlFile.Append("<filterList>");
            xmlFile.Append(String.Format("<filter><fieldName>TR_SUITE_RUN_DISPLAYNAME</fieldName><operator>=</operator><fieldValues><value>{0}</value></fieldValues></filter>", ts.TestSuiteRunID));
            xmlFile.Append(String.Format("<filter><fieldName>TR_STATUS</fieldName><operator>=</operator><fieldValues><value>{0}</value></fieldValues></filter>", ts.Status));
            xmlFile.Append("</filterList>");
            xmlFile.Append("<pageNumber>1</pageNumber>");
            xmlFile.Append("<pageSize>-1</pageSize>");
            xmlFile.Append("<fetchConfig>false</fetchConfig>");
            xmlFile.Append("<fetchUsers>false</fetchUsers>");
            xmlFile.Append("<fetchBugInfo>false</fetchBugInfo>");
            xmlFile.Append("<fetchFileInfo>false</fetchFileInfo>");
            xmlFile.Append("<fetchStepInfo>false</fetchStepInfo>");
            xmlFile.Append("<CountOnly>true</CountOnly>");
            xmlFile.Append("</searchCriteria></InputXML>");

            // Read test Input Data
            //TextReader tr = new StreamReader(xmlFile.ToString());
            //string xmlin = tr.ReadToEnd();
            //tr.Close();

            //Load Test Input Data into XML Doc

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlFile.ToString());

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            XmlNode inputxml = doc.GetElementsByTagName("InputXML")[0];

            //XmlNode entityType = doc.GetElementsByTagName("EntityType")[0];
            //Int32.TryParse(entityType.InnerText, out entitytype);

            TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();

            TestStudioService.exportData expdObj = new TestStudioService.exportData();
            expdObj.strData = inputxml.InnerXml;
            expdObj.ielementType = 2;
            expdObj.SessionID = ts.SessionID;

            TestStudioService.exportDataRequest request = new TestStudioService.exportDataRequest(expdObj);
            TestStudioService.exportDataResponse1 response = null;

            try
            {
                response = service.exportData(request);
                doc.LoadXml(response.exportDataResponse.@return.ToString());
                ts.TestCasesCount = Convert.ToInt32((doc.GetElementsByTagName("testrunlist")[0]).Attributes[0].Value);
            }
            catch (Exception ex)
            {
                ts.ErrorCode = "-1";
                ts.ErrorMessage = ex.Message;
            }

            return ts;
        }

        /// <summary>
        /// ExportTC
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public DTO.TestSudio ExportTC(DTO.TestSudio ts)
        {
            StringBuilder xmlFile = new StringBuilder("<InputXML><searchCriteria>");
            xmlFile.Append("<filterList>");
            xmlFile.Append(String.Format("<filter><fieldName>TS_DISPLAYNAME</fieldName><operator>=</operator><fieldValues><value>{0}</value></fieldValues></filter>", ts.TestSuiteID));
            xmlFile.Append("</filterList>");
            xmlFile.Append("<pageNumber>-1</pageNumber>");
            xmlFile.Append("<pageSize>100</pageSize>");
            xmlFile.Append("<fetchConfig>true</fetchConfig>");
            xmlFile.Append("<fetchHistory>true</fetchHistory>");
            xmlFile.Append("<fetchFileInfo>true</fetchFileInfo>");
            xmlFile.Append("<fetchStepInfo>true</fetchStepInfo>");
            xmlFile.Append("<CountOnly>false</CountOnly>");
            xmlFile.Append("</searchCriteria></InputXML>");

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xmlFile.ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            XmlNode inputxml = doc.GetElementsByTagName("InputXML")[0];

            TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();

            TestStudioService.exportData expdObj = new TestStudioService.exportData();
            expdObj.strData = inputxml.InnerXml;
            expdObj.ielementType = 1;
            expdObj.SessionID = ts.SessionID;

            TestStudioService.exportDataRequest request = new TestStudioService.exportDataRequest(expdObj);
            TestStudioService.exportDataResponse1 response = null;

            try
            {
                response = service.exportData(request);

                DataTable dtTestCaseDetails = new DataTable();
                dtTestCaseDetails.Columns.Add(new DataColumn("TestCasesID"));
                dtTestCaseDetails.Columns.Add(new DataColumn("TestCasesStep"));
                dtTestCaseDetails.Columns.Add(new DataColumn("ExecutionResult"));

                string responseXML = response.exportDataResponse.@return.ToString();
                responseXML = responseXML.Replace("<testcaselist", "<DataList xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><testcaselist").Replace("</testcaselist>", "</testcaselist></DataList>");
                //doc.LoadXml(responseXML);

                //DTO.DataList tclist = new DTO.DataList();
                //tclist.testcaselist = new List<DTO.testcase>();
                //DTO.testcase tc1 = new DTO.testcase();
                //tc1.displayid = "displayID1";
                //tc1.tcsteplist = new List<DTO.tcstep>();

                //DTO.tcstep step1 = new DTO.tcstep();
                //step1.desc = "Desc1";
                //step1.exresult = "exresult1";
                //tc1.tcsteplist.Add(step1);

                //DTO.tcstep step2 = new DTO.tcstep();
                //step2.desc = "Desc2";
                //step2.exresult = "exresult2";
                //tc1.tcsteplist.Add(step2);

                //tclist.testcaselist.Add(tc1);

                //DTO.testcase tc2 = new DTO.testcase();
                //tc2.displayid = "displayID2";
                //tclist.testcaselist.Add(tc2);

                //string xml = Serialize(tclist);
                DTO.DataList tcList = (DTO.DataList)Deserialize(typeof(DTO.DataList), responseXML);

                foreach (DTO.testcase tc in tcList.testcaselist)
                    foreach (DTO.tcstep step in tc.tcsteplist)
                    {
                        DataRow dr = dtTestCaseDetails.NewRow();
                        dr[0] = tc.displayid;
                        dr[1] = step.desc;
                        dr[2] = step.exresult;

                        dtTestCaseDetails.Rows.Add(dr);
                    }

                ts.TestSuiteDetails = dtTestCaseDetails;
            }
            catch (Exception ex)
            {
                ts.ErrorCode = "-1";
                ts.ErrorMessage = ex.Message;
            }

            return ts;
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public string Serialize(object objectToSerialize)
        {
            MemoryStream mem = new MemoryStream();
            XmlSerializer ser = new XmlSerializer(objectToSerialize.GetType());
            ser.Serialize(mem, objectToSerialize);
            ASCIIEncoding ascii = new ASCIIEncoding();
            return ascii.GetString(mem.ToArray());
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="typeToDeserialize"></param>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        private object Deserialize(Type typeToDeserialize, string xmlString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream mem = new MemoryStream(bytes);
            XmlSerializer ser = new XmlSerializer(typeToDeserialize);
            return ser.Deserialize(mem);
        }

        #endregion
    }
}
