using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = ExtractData.Common.DataTransferObjects;
using DAO = ExtractData.DataLayer;
using TS = ExtractData.DataLayer.TestStudioComponents;

namespace ExtractData.BusinessLayer
{
    public class ExtractDataBO
    {
        public static bool SaveFeatureRequestDataToXLS(string filePath, DTO.FeatureRequestDTO featureReqDTO)
        {
            if (featureReqDTO.RequestType == "Bug Report")
            {
                return DAO.ExtractDataDL.SaveFeatureRequestToXLS(filePath, DAO.QueryFormation.BugReportQuery("Users reported Bugs", featureReqDTO));
            }
            else
            {
                return DAO.ExtractDataDL.SaveFeatureRequestToXLS(filePath, DAO.QueryFormation.FeatureRequestQuery("Features Requested", featureReqDTO));
            }
        }

        public static bool SaveDataToXLS(string filePath, DTO.MTDataDTO data)
        {
            return DAO.ExtractDataDL.SaveDataToXLS(filePath, DAO.QueryFormation.MTDataQuery("Sheet1", data));
        }

        public static string[] ReadMTDatafromCSV(string filePath, DTO.MTDataDTO data)
        {
            return DAO.ExtractDataDL.ReadMTDatafromCSV(filePath, data);
        }

        public static DataTable ReadZStringsfromCSV(string filePath)
        {
            return DAO.ExtractDataDL.ReadZStringsfromCSV(filePath);
        }

        public static DataTable ReadExcludedZStringsfromCSV(string filePath)
        {
            return DAO.ExtractDataDL.ReadExcludedZStringsfromCSV(filePath);
        }

        public static DataTable ReadExcludedZStringsfromCSV(string filePath, bool ignore)
        {
            return DAO.ExtractDataDL.ReadExcludedZStringsfromCSV(filePath, ignore);
        }

        /// <summary>
        /// GetLoginSessionID
        /// </summary>
        /// <returns></returns>
        public static DTO.TestSudio GetLoginSessionID(DTO.TestSudio ts)
        {
            TS.LoginAPI login = new TS.LoginAPI();
            return login.Login(ts);
        }

        /// <summary>
        /// GetTestSuiteDetails
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DTO.TestSudio GetTestSuiteDetails(DTO.TestSudio ts)
        {
            TS.ExportDataAPI fetchSuiteData = new TS.ExportDataAPI();

            return fetchSuiteData.ExportTC(ts);
        }

    }
}
