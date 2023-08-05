using System;
using System.Data;
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
    /// FetchTestSuiteRunDetailsExAPI
    /// </summary>
    public class FetchTestSuiteRunDetailsExAPI
    {
        #region Public Members

        /// <summary>
        /// FetchTestSuiteRunDetailsEx
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="suiteID"></param>
        public DTO.TestSudio FetchTestSuiteRunDetailsEx(DTO.TestSudio ts)
        {
            TestStudioService.TestStudio service = new TestStudioService.TestStudioClient();

            TestStudioService.fetchTestSuiteDetailsEx logObj = new TestStudioService.fetchTestSuiteDetailsEx();
            logObj.ts_id = Convert.ToInt32(ts.TestSuiteID.Replace("TS_", ""));
            logObj.fetchChildTC = true;
            logObj.fetchChildTS = false;
            logObj.fetchTCConfig = true;
            logObj.pageNumber = 1;
            logObj.pageSize = ts.TestCasesCount;
            logObj.SessionID = ts.SessionID;

            TestStudioService.fetchTestSuiteDetailsExRequest request = new TestStudioService.fetchTestSuiteDetailsExRequest(logObj);
            TestStudioService.fetchTestSuiteDetailsExResponse1 response = null;

            try
            {
                response = service.fetchTestSuiteDetailsEx(request);

                DataTable dtTestCaseDetails = new DataTable();
                dtTestCaseDetails.Columns.Add(new DataColumn("TestCasesID"));
                dtTestCaseDetails.Columns.Add(new DataColumn("TestCasesStep"));
 
                foreach (TestStudioService.TSEntity data in response.fetchTestSuiteDetailsExResponse.@return.list)
                {
                    if (data.tc != null)
                    {
                        DataRow drTCDetails = dtTestCaseDetails.NewRow();
                        drTCDetails[0] = data.tc.id;

                        if (data.tc.product.Length > 0 && data.tc.product[0].versionList.Length > 0 && data.tc.product[0].versionList[0].subArea != null)
                        {
                            if (data.tc.product[0].versionList[0].subArea.Length > 1)
                            {
                                drTCDetails[1] = data.tc.product[0].versionList[0].subArea[0].name;
                                drTCDetails[2] = data.tc.product[0].versionList[0].subArea[1].name;
                            }
                            else if (data.tc.product[0].versionList[0].subArea.Length == 1)
                                drTCDetails[1] = data.tc.product[0].versionList[0].subArea[0].name;
                        }
                        dtTestCaseDetails.Rows.Add(drTCDetails);
                    }
                }

                DataView dvTestCases = dtTestCaseDetails.DefaultView;
                dvTestCases.Sort = "ProductArea ASC, SubArea ASC";

                ts.TestSuiteDetails = dvTestCases.ToTable();
                ts.TestCasesCount = dtTestCaseDetails.Rows.Count;
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
